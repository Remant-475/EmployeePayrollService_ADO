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
       
        static void Main(String[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Service");
            EstablishConnection();
            CloseConnection();
            
        }
    }
}

