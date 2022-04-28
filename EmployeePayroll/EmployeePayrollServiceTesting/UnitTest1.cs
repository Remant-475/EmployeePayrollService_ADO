using NUnit.Framework;
using EmployeePayroll;
using System.Collections.Generic;
using System;

namespace EmployeePayrollServiceTesting
{
    public class Tests

    {
        EmployeeDetails details;

        [SetUp]
        public void Setup()
        {
            details = new EmployeeDetails();

        }
        [Test]
        public void Retrive_Details_Database()

        {
            List<Employee> employees = new List<Employee>();
            employees = details.GetAllEmployeePayrollData();
            Assert.IsNotNull(employees);

        }

        [Test]
        public void UpdateEmployeeSalary_ShouldReturn_True_AfterUpdate()
        {
            bool expected = true;
            Employee employee = new Employee();
            employee.ID = 1;
            employee.Name = "Sachin";
            employee.BasicPay = 500000000;

            bool result = details.UpdateSalary(employee);
            Assert.AreEqual(expected, result);
        }


    }
}