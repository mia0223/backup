using System;
using TEK.SeatPlan.Dto;

namespace TEK.SeatPlan.Tests.Shared
{
    public class CreateDtos
    {
        public static Employee CreateNewEmployeeDto(string description = "test description", string email = "test email",
            string firstName = "testFirstName", int id = 2, string lastName = "testLastName")
        {
            return new Employee()
            {
                Description = description,
                Email = email,
                FirstName = firstName,
                Id = id,
                LastName = lastName,
            };
        }

        public static Project CreateNewProjectDto(Boolean active = false, string color = "test color", string description = "test description",
            int id = 3, Boolean intern = true, string name = "test name")
        {
            return new Project()
            {
                Active = active,
                BackgroundColor = color,
                Description = description,
                Id = id,
                Internal = intern,
                Name = name
            };
        }

        public static Location CreateNewLocationDto(Boolean active = false, int cols = 23, int floorlevel = 2, int id = 3, string name = "test name",
            int rows = 14)
        {
            return new Location()
            {
                Active = active,
                Cols = cols,
                FloorLevel = floorlevel,
                Id = id,
                Name = name,
                Rows = rows,
            };
        }

        public static Seat CreateNewSeatDto(int row = 14, int col = 9, string description = "test description", int number = 12)
        {
            return new Seat()
            {
                Row = row,
                Col = col,
                Description = description,
                Number = number
            };
        }

        public static Dto.SeatPair CreateNewSeatPairDto(int source, int target)
        {
            return new Dto.SeatPair()
            {
                SourceSeatNumber = source,
                TargetSeatNumber = target
            };
        }

    }
}
