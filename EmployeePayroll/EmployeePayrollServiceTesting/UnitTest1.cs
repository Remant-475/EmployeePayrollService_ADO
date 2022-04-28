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
        [Test]
        public void Retrieve_Details_DateRnge()
        {
            List<Employee> employee = new List<Employee>();
            DateTime FromDate = DateTime.Parse("2018-01-01");
            DateTime EndDate = DateTime.Parse("2020-12-31");
            employee=details.GetDetailsEmployees_FromDateRange(FromDate, EndDate);
            Assert.AreEqual(2, employee.Count);
        }
        [Test]
        public void Insert_ReturnExpected()
        {
            EmployeeDetails employee = new EmployeeDetails();
            Employee empPayroll = new Employee
            {
                Name = "Renu",
                Phonenumber = 7894561211,
                StartDate = DateTime.Now,
                Address = "Nagpur",
            Gender = "F",
            BasicPay = 4000000,
            Department="IT"

        };
        int result = EmployeeDetails.InsertNewEmployee(empPayroll);
        Assert.AreEqual(0,result);
        }

}
        }


    
