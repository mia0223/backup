using System;
using TEK.SeatPlan.Entity;

namespace TEK.SeatPlan.Tests.Shared
{
    public class CreateEntities
    {
        public static Employee CreateNewEmployeeEntity(string description = "test description",string email = "test email",
            string firstName = "testFirstName", int id = 2, string lastName= "testLastName")
        {
            return new Employee( )
            {
                Description = description,
                Email = email,
                FirstName = firstName,
                Id = id,
                LastName = lastName,
            };
        }

        public static Project CreateNewProjectEntity(Boolean active=false,string color = "test color", string description = "test description",
            int id = 3, Boolean inter = true, string name = "test name")
        {
            return new Project()
            {
                Active = active,
                BackgroundColor = color,
                Description = description,
                Id = id,
                Internal = inter,
                Name = name
            };
        }

        public static Location CreateNewLocationEntity(Boolean active = false, int cols=23,int floorlevel=2, int id = 3, string name = "test name",
            int rows =14)
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

        public static Seat CreateNewSeatEntity(int? employeeId=0, int row = 14, int col = 9, string description = "test description", int number = 12)
        {
            return new Seat()
            {
                Row = row,
                Col = col,
                Description = description,
                Number = number,
                Active = true,
                EmployeeId = employeeId
            };
        }

        public static Seat CreateNewTransitSeatEntity(int row, int col, string description, int number)
        {
            return new Seat()
            {
                Row = row,
                Col = col,
                Description = description,
                Number = number,
                Active = true,
                EmployeeId = null,
                Transit = true
            };
        }
    }
}
