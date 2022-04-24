using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayroll
{
    public class Program
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog =Payroll_Service; Integrated Security = True;";
        static SqlConnection connection = new SqlConnection(connectionString);
        static void EstablishConnection()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    throw new EmployeeException(EmployeeException.ExceptionType.Connection_Failed, "connection failed");

                }
                
            }
        }
        static void CloseConnection()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Open))
            {
                try
                {
                    connection.Close();
                }
                catch (Exception)
                {
                    throw new EmployeeException(EmployeeException.ExceptionType.Connection_Failed, "connection failed");
                }
            }
        }
        public static List<Employee> GetAllEmployeePayrollData()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp = new Employee();
            SqlConnection connection = new SqlConnection(connectionString);
            string Spname = "dbo.GetAllEmployeeDetails";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(Spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader dr = sqlCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        emp.EmployeeId = dr.GetInt32(0);
                        emp.EmployeeName = dr.GetString(1);
                        emp.EmployeeAddress = dr.GetString(2);
                        emp.EmployeePhonenumber = dr.GetInt64(3);
                        emp.StartDate = dr.GetDateTime(4).Date;
                        emp.Gender = dr.GetString(5);
                        emp.BasicPay = dr.GetDouble(6);
                        emp.Deductions = dr.GetDouble(7);
                        emp.TaxablePay = dr.GetDouble(8);
                        emp.IncomeTax = dr.GetDouble(9);
                        emp.NetPay = dr.GetDouble(10);
                        emp.DepartName = dr.GetString(11);
                        employees.Add(emp);
                        Console.WriteLine(emp.EmployeeId + "," + emp.EmployeeName + "," + emp.EmployeePhonenumber + "," + emp.NetPay + "," + emp.DepartName);
                    }
                }
                connection.Close();
            }
            return employees;
        }

        static void Main(String[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Service");
            EstablishConnection();
            CloseConnection();
            GetAllEmployeePayrollData();

        }
    }
}

