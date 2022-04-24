using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public class EmployeeException : Exception
    {
        public enum ExceptionType
        {
          
            Connection_Failed
        }
        ExceptionType exceptionType;

        public EmployeeException(ExceptionType exceptionType,string message): base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
