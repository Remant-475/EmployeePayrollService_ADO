﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public  class Employee
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public Int64 Phonenumber { get; set; }
        public string Address{ get; set; }
       
        public string Gender { get; set; }
   
        public double BasicPay { get; set; }
        public double Deduction { get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }
        public string Department { get; set; }
    }
}
