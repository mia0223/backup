using System;
using System.Linq;
using System.Collections.Generic;

using TEK.SeatPlan.Common;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.ResourceAccess.Contract;
using TEK.SeatPlan.BusinessLogic.Mappers;

namespace TEK.SeatPlan.BusinessLogic
{
    public class EmployeeComponent : DataComponentBase, IEmployeeComponent
    {
        private readonly IRepository<Entity.Seat> seatRepository;
        private readonly IRepository<Entity.Employee> employeeRepository;
        private readonly IRepository<Entity.EmployeeStatus> statusRepository;
        private readonly IRepository<Entity.Project> projectRepository;
        private readonly IMoveComponent moveComponent;

        public EmployeeComponent(
            IRepository<Entity.Seat> seatRepository,
            IRepository<Entity.Employee> employeeRepository,
            IRepository<Entity.EmployeeStatus> employeeStatusRepository,
            IRepository<Entity.Project> projectRepository,
            IMoveComponent moveComponent) : base()
        {
            this.seatRepository = seatRepository;
            this.employeeRepository = employeeRepository;
            this.statusRepository = employeeStatusRepository;
            this.projectRepository = projectRepository;
            this.moveComponent = moveComponent;
        }

        public Dto.Employee GetEmployee(int id)
        {
            var employeeEntity = this.employeeRepository.Get(
                x => x.Id == id, y => y.Project, y => y.Seat, y => y.Status);

            return employeeEntity?.ToDto();
        }

        public IEnumerable<Dto.Employee> GetEmployee()
        {
            return this.employeeRepository.Find(
                x => x.Active, y => y.OrderBy(z => z.LastName), x => x.Project, x => x.Seat, x => x.Status)?
                .ToDto();
        }

        public Dto.Employee SoftDeleteEmployee(int employeeId)
        {
            var employeeEntity = this.employeeRepository.Find(x => x.Id == employeeId, null).FirstOrDefault();
            if (employeeEntity == null) throw new InvalidOperationException($"[{employeeId}] wrong Employee Id");

            var employeeSeat = this.seatRepository.Find(x => x.EmployeeId == employeeEntity.Id, null).FirstOrDefault();
            if (employeeSeat == null) throw new InvalidOperationException($"Employee is not assigned a seat");

            employeeEntity.Active = false;
            employeeSeat.Employee = null;
            employeeSeat.EmployeeId = null;

            this.seatRepository.Update(employeeSeat);
            this.employeeRepository.Update(employeeEntity);
            this.employeeRepository.SaveChanges();

            this.Logger.DebugFormat("employee with ID=[{0}] has been soft-deleted",
                employeeId);

            return employeeEntity.ToDto();
        }

        public Dto.Employee CreateEmployee(Dto.Employee employee)
        {
            Requires.ArgumentNotNull(employee, "employee");

            var employeeEntity = employee.ToEntity(null);

            employeeRepository.Attach(employeeEntity.Project);
            employeeRepository.Attach(employeeEntity.Status);
            employeeRepository.Attach(employeeEntity.Seat);

            this.CheckTargetSeat(employeeEntity.Seat);

            var newEmployeeEntity = this.employeeRepository.Add(employeeEntity);
            this.employeeRepository.SaveChanges();

            return newEmployeeEntity.ToDto();
        }

        public Dto.Employee UpdateEmployee(Dto.Employee employee)
        {
            Requires.ArgumentNotNull(employee, "employee");

            var employeeEntity = this.employeeRepository.Get(x => x.Id == employee.Id && x.Active,
                x => x.Project, x => x.Seat, x => x.Status);

            if (employeeEntity == null) throw new InvalidOperationException($"[{employee.Id}] wrong Employee Id");

            if (employee.Seat != null)
            {
                var targetSeat = this.seatRepository.Get(x => x.Id == employee.Seat.Id && x.Active, x => x.Employee);

                if (targetSeat.Id != employee.Seat.Id)
                {
                    if (targetSeat == null) throw new InvalidOperationException($"[{employee.Seat.Id}] wrong Seat Id");

                    if (targetSeat.Employee == null)
                    {
                        // todo: ChangeLog
                        targetSeat.EmployeeId = employee.Id;
                        this.seatRepository.Update(targetSeat);
                    }
                    else
                    {
                        if (targetSeat.Employee.Id != employee.Id)
                        {
                            // todo: (Move, and then assign), ChangeLog
                            targetSeat.EmployeeId = employee.Id;
                            this.seatRepository.Update(targetSeat);
                        }
                    }
                    this.seatRepository.SaveChanges();
                }
            }

            if (employee.Status != null)
            {
                var employeeStatus = this.statusRepository.Get(x => x.Id == employee.Status.Id);

                if (employeeStatus == null)
                {
                    throw new InvalidOperationException($"Status Id = [{employee.Status.Id}] not found");
                }

                employeeEntity.Status = employeeStatus;

                if (employeeStatus.Name == "On Leave")
                {
                    if (employee.Seat.Number < 9000)
                    {
                        var currentSeat = this.seatRepository.Get(x => x.Id == employee.Seat.Id && x.Active, x => x.Employee);
                        currentSeat.EmployeeId = employee.Id;
                        var inTransitSeat = this.moveComponent.CreateTransitSeat();
                        var seatPair = new SeatPair(currentSeat, inTransitSeat);
                        this.moveComponent.Move(seatPair, true);
                    }
                }
            }

            if (employee.Project != null)
            {
                var employeeProject = this.projectRepository.Get(x => x.Id == employee.Project.Id && x.Active);

                if (employeeProject == null)
                {
                    throw new InvalidOperationException($"[{employee.Project.Id}] wrong Project Id");
                }

                employeeEntity.Project = employeeProject;
            }

            employeeEntity.FirstName = employee.FirstName;
            employeeEntity.LastName = employee.LastName;
            employeeEntity.Email = employee.Email;
            employeeEntity.Description = employee.Description;

            var modifiedEmployee = this.employeeRepository.Update(employeeEntity);
            this.employeeRepository.SaveChanges();

            return modifiedEmployee.ToDto();
        }

        private void CheckTargetSeat(Entity.Seat seat)
        {
            if (seat == null) return;

            var targetSeat = this.seatRepository.Get(x => x.Id == seat.Id && x.Active, y => y.Employee);

            if (targetSeat == null)
            {
                throw new InvalidOperationException($"[{seat.Id}] wrong Seat Id");
            }

            if (targetSeat.Employee != null && targetSeat.Employee.Id != seat.Employee.Id)
            {
                throw new InvalidOperationException(
                    $"Seat {seat.Number} is not empty, occupied by {targetSeat.Employee.FirstName},{targetSeat.Employee.LastName}");
            }
        }
    }
}