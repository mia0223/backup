using System;
using Castle.Core.Logging;

using TEK.SeatPlan.Common;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.ResourceAccess.Contract;

namespace TEK.SeatPlan.BusinessLogic
{
	public class EmployeeSeatComponent : DataComponentBase, IEmployeeSeatComponent
	{
		private readonly IRepository<Entity.Seat> seatRepository;
		private readonly IRepository<Entity.Project> projectRepository;
	    private readonly IMoveComponent moveComponent;

        public EmployeeSeatComponent(
			IRepository<Entity.Seat> seatRepository,
			IRepository<Entity.Project> projectRepository,
            IMoveComponent moveComponent) : base()
		{
			this.seatRepository = seatRepository;
			this.projectRepository = projectRepository;
		    this.moveComponent = moveComponent;
		}

		public Entity.Seat GetSeatByNumber(int seatNumber)
		{
			var seat = this.seatRepository.Get(x => x.Active && x.Number == seatNumber, x => x.Employee);

			if (seat == null) throw new ArgumentException($"Seat [{seatNumber}] not found");

			return seat;
		}

		public Entity.Seat GetSeatByEmployeeId(int employeeId)
		{
			var seat = this.seatRepository.Get(
				x => x.Active && x.Employee.Id == employeeId,
				x => x.Employee,
				x => x.Employee.Project,
                x => x.Employee.Status);

			if (seat == null)
			{
				throw new ArgumentException($"Seat for Employee with Id=[{employeeId}] not found");
			}

			return seat;
		}

		public Entity.Seat CreateSeat(Entity.Seat seat)
		{
			Requires.ArgumentNotNull(seat, "seat");

			var newSeat = this.seatRepository.Add(seat);
			this.seatRepository.SaveChanges();

			return newSeat;
		}

		public Dto.EmployeeSeatProject UpdateEmployeeSeatProject(Dto.EmployeeSeatProject employeeSeatProject)
		{
			Requires.ArgumentNotNull(employeeSeatProject, "employeeSeatProject");

			var currentSeat = this.GetSeatByEmployeeId(employeeSeatProject.EmployeeId);

			if (currentSeat.Employee.Project.Id != employeeSeatProject.ProjectId)
			{
				this.Logger.DebugFormat("Updating project for Employee ID=[{0}] to [{1}]",
					currentSeat.Employee.Id, employeeSeatProject.ProjectId);

				var newProject = this.projectRepository.Get(x => x.Id == employeeSeatProject.ProjectId);

				if (newProject == null)
				{
					throw new ArgumentException($"Project with ID=[{employeeSeatProject.ProjectId}] not found");
				}

				currentSeat.Employee.Project = newProject;
				currentSeat = this.seatRepository.Update(currentSeat);
			}

			if (currentSeat.Number != employeeSeatProject.TargetSeatNumber)
			{
				this.Logger.DebugFormat("Moving employee with ID=[{0}] to seat [{1}]",
					employeeSeatProject.EmployeeId, employeeSeatProject.TargetSeatNumber);

				var seatPairEntity = this.moveComponent.MoveValidate(new Dto.SeatPair
				{
					SourceSeatNumber = currentSeat.Number,
					TargetSeatNumber = employeeSeatProject.TargetSeatNumber
				});

				if (seatPairEntity.Target.EmployeeId != null && employeeSeatProject.FirstTry)
				{
					employeeSeatProject.Completed = false;

					employeeSeatProject.ConcurrentEmployeeName = 
						$"{seatPairEntity.Target.Employee.LastName}, {seatPairEntity.Target.Employee.FirstName}";

					return employeeSeatProject;
				}

			    this.moveComponent.Move(seatPairEntity, false);
			}

			this.seatRepository.SaveChanges();
			this.Logger.Info("Update-Employee-Seat-Project completed");

			employeeSeatProject.Completed = true;
			return employeeSeatProject;
		}
	}
}