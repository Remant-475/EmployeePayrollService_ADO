﻿
using System;

namespace EmployeePayroll
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in EmployeePayroll Ado.Net");
            EmployeeDetails details = new EmployeeDetails();
            int option = 0;
            do
            {
                Console.WriteLine("1: For Establish Connection");
                Console.WriteLine("2: For Close Connection");
                Console.WriteLine("3: For All Employee Details");
                Console.WriteLine("4: For Update EmployeeDetails");

                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        details.EstablishConnection();
                        Console.WriteLine("Connection is Open");
                        break;
                    case 2:
                        details.CloseConnection();
                        Console.WriteLine("Connection is closed");
                        break;
                    case 3:
                        details.GetAllEmployeePayrollData();
                        break;
                    case 4:
                        Employee empPayroll = new Employee();
                        Console.WriteLine("Enter Employee Id");
                        int EmployeeId = int.Parse(Console.ReadLine());
                        empPayroll.ID = EmployeeId;
                        Console.WriteLine("Enter Employee Name");
                        string Employee_name = Console.ReadLine();
                        empPayroll.Name = Employee_name;
                        Console.WriteLine("Enter Basic Pay");
                        int Basicpay = int.Parse(Console.ReadLine());
                        empPayroll.BasicPay = Basicpay;
                        details.UpdateSalary(empPayroll);
                        break;


                }
            }
            while (option != 0);
        }
    }
}