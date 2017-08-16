using System;
using System.Collections.Generic;
using System.Linq;
using Structure.Models;
using Structure.Resources;

namespace Structure.Business
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IADEmployeeRepo _ADRepo;

        public EmployeeService()
        {
            _ADRepo = new ADEmployeeRepo();
        }

        // if partialName is empty, then get the whole list; else return matched employees
        private List<EmployeeInfo> getEmployeesFromAD(string department, string partialName)
        {
            return partialName.CompareTo("") == 0 ? _ADRepo.ByDepartment(department) : _ADRepo.ByDepartmentAndPartialName(department, partialName);
        }

        private List<EmployeeInfo> getEmployeesFromDB()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeInfo> GetEmployees(string department, string partialName)
        {
           return (List<EmployeeInfo>) getEmployeesFromAD(department, partialName).Concat(getEmployeesFromDB());
        }
    }
}