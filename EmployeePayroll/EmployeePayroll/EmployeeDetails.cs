using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayroll
{
    public class EmployeeDetails
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog =Payroll_Services; Integrated Security = True;";
        static SqlConnection connection = new SqlConnection(connectionString);
        public void EstablishConnection()
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
        public void CloseConnection()
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
        public List<Employee> GetAllEmployeePayrollData()
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
                        emp.ID = dr.GetInt32(0);
                        emp.Name = dr.GetString(1);
                        emp.StartDate = dr.GetDateTime(2).Date;
                        emp.Phonenumber = dr.GetInt64(3);
                        emp.Address = dr.GetString(4);
                        emp.Gender = dr.GetString(5);
                        emp.BasicPay = dr.GetInt64(6);
                        emp.Deduction = dr.GetInt64(7);
                        emp.TaxablePay = dr.GetInt64(8);
                        emp.IncomeTax = dr.GetInt64(9);
                        emp.NetPay = dr.GetInt64 (10);
                        emp.Department = dr.GetString(11);
                        employees.Add(emp);
                        Console.WriteLine(emp.ID + "," + emp.Name + "," + emp.Phonenumber + "," + emp.NetPay + "," + emp.Department);
                    }
                }
                connection.Close();
            }
            return employees;

        }
        public bool UpdateSalary(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("dbo.UpdateRecord", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", employee.ID);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@BasicPay", employee.BasicPay);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                throw new EmployeeException(EmployeeException.ExceptionType.BasicPay_Not_Updated, "Emplyoee BasicPay Not Updated");
                return false;
            }
        }
    }
} 
    

