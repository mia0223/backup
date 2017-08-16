using System;
using System.Linq;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Common;
using TEK.SeatPlan.ResourceAccess.Contract;

namespace TEK.SeatPlan.BusinessLogic
{
    public class MoveComponent : DataComponentBase, IMoveComponent
    {
        private readonly IRepository<Entity.Seat> seatRepository;
        private readonly IRepository<Entity.SeatChangeLog> seatChangeLogRepository;

        private readonly int transitSeatNumber;

        public MoveComponent(IRepository<Entity.Seat> seatRepository,
            IRepository<Entity.SeatChangeLog> seatChangeLogRepository) : base()
        {
            this.seatRepository = seatRepository;
            this.seatChangeLogRepository = seatChangeLogRepository;

            this.transitSeatNumber = 9000;
        }

        public Entity.Seat CreateTransitSeat()
        {
            var transitSeat = this.seatRepository.Get(x => x.Transit && x.EmployeeId == null && x.Number != 9000);

            if (transitSeat == null)
            {
                var maxTransitSeat = (this.seatRepository.Find(x => x.Transit, null).FirstOrDefault() == null)
                    ? 9000 : this.seatRepository.Find(x => x.Transit, null).Max(x => x.Number);

                transitSeat = this.seatRepository.Add
                (
                    new Entity.Seat
                    {
                        Transit = true,
                        LocationId = 1,
                        Number = maxTransitSeat + 1
                    }
                );

                this.Logger.DebugFormat("New transit seat [{0}] will be created", transitSeat.Number);
            }
            else
            {
                transitSeat.Active = true;
                this.Logger.DebugFormat("Re-use existing transit seat [{0}]", transitSeat.Number);
            }

            return transitSeat;
        }

        public void Move(Dto.SeatPair seatPair)
        {
            var seatPairEntity = this.MoveValidate(seatPair);
            this.Move(seatPairEntity, false);

            this.Logger.DebugFormat("Drag/Drop move employee with ID=[{0}] from seat [{1}] to seat [{2}] completed",
                seatPairEntity.Target.EmployeeId,
                seatPairEntity.Source.Number,
                seatPairEntity.Target.Number);
        }

        public void Move(SeatPair seatPair, bool isAutoTransit)
        {
            Requires.ArgumentNotNull(seatPair, "seatPair");

            this.Logger.DebugFormat("{0}Move employee with ID=[{1}] from seat [{2}] to {3}seat [{4}] started",
                isAutoTransit ? "Auto-Transit-" : string.Empty,
                seatPair.Source.EmployeeId,
                seatPair.Source.Number,
                isAutoTransit ? "transit-" : string.Empty,
                seatPair.Target.Number);

            if (seatPair.Target.EmployeeId != null)
            {
                this.Logger.DebugFormat(
                    "Target seat [{0}] is not empty, occupied by employee with ID=[{1}] (transit move expected)",
                    seatPair.Target.Number,
                    seatPair.Target.EmployeeId);

                this.Move(new SeatPair(seatPair.Target, this.CreateTransitSeat()), true);
            }

            seatPair.Target.EmployeeId = seatPair.Source.EmployeeId;
            seatPair.Source.EmployeeId = null;

            if (!seatPair.Target.IsNew)
            {
                this.seatRepository.Update(seatPair.Target);
            }

            if (seatPair.Source.Transit && seatPair.Source.EmployeeId == null)
            {
                seatPair.Source.Active = false;
                this.Logger.DebugFormat("Transit seat [{0}] soft-delete", seatPair.Source.Number);
            }

            this.seatRepository.Update(seatPair.Source);

            seatChangeLogRepository.Add(new Entity.SeatChangeLog
            {
                ActionDate = DateTime.Now,
                Employee = seatPair.Target.Employee,
                SourceSeat = seatPair.Source,
                TargetSeat = seatPair.Target
            });
            seatRepository.SaveChanges();
        }

        public SeatPair MoveValidate(Dto.SeatPair seatPair)
        {
            Requires.ArgumentNotNull(seatPair, "seatPair");

            if (seatPair.SourceSeatNumber == seatPair.TargetSeatNumber)
            {
                throw new ArgumentException($"Source and Target seat [{seatPair.SourceSeatNumber}] should not be the same");
            }

            var targetSeat = (seatPair.TargetSeatNumber == this.transitSeatNumber)
                ? this.CreateTransitSeat()
                : this.GetSeatByNumber(seatPair.TargetSeatNumber);

            var sourceSeat = this.GetSeatByNumber(seatPair.SourceSeatNumber);

            if (sourceSeat.EmployeeId == null)
            {
                throw new ArgumentException($"No Employee found at source seat [{sourceSeat.Number}]");
            }

            return new SeatPair(sourceSeat, targetSeat);
        }

        public Entity.Seat GetSeatByNumber(int seatNumber)
        {
            var seat = this.seatRepository.Get(x => x.Active && x.Number == seatNumber, x => x.Employee);

            if (seat == null) throw new ArgumentException($"Seat [{seatNumber}] not found");
            if (seat.Employee != null)
            {
                seat.EmployeeId = seat.Employee.Id;
            }
            return seat;
        }
    }
}