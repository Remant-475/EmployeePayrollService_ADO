
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
                Console.WriteLine("5: For DateRange ");
                Console.WriteLine("6: For Add Employee Details");
                Console.WriteLine("0: For Exit");
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
                    case 5:
                        Console.WriteLine("Enter From Date");
                        string FromDate = Console.ReadLine();
                        DateTime dateTime_1 = DateTime.Parse(FromDate);
                        Console.WriteLine("Enter End Date");
                        string endDate = Console.ReadLine();
                        DateTime dateTime_2 = DateTime.Parse(endDate);
                        details.GetDetailsEmployees_FromDateRange(dateTime_1, dateTime_2);
                        break;
                    case 6:
                        Employee employee = new Employee();
                        Console.WriteLine("Enter Employee Name");
                        string employee_name = Console.ReadLine();
                        employee.Name = employee_name;
                        Console.WriteLine("Enter Employee PhoneNumber");
                        Int64 employeephone = Int64.Parse(Console.ReadLine());
                        employee.Phonenumber = employeephone;
                        Console.WriteLine("Enter Start Date");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        employee.StartDate = date;
                        Console.WriteLine("Enter Gender");
                        string gender = Console.ReadLine();
                        employee.Gender = gender;
                        Console.WriteLine("Enter Basic Pay");
                        double basicpay = double.Parse(Console.ReadLine());
                        employee.BasicPay = basicpay;
                        EmployeeDetails.InsertNewEmployee(employee);
                        break;

                }
            }
            while (option != 0);
        }
    }
}