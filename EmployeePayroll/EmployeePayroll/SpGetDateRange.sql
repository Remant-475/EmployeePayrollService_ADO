USE [Payroll_Services]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure GetDetails_DateRange
(@FromDate Date,
@ToDate Date
)
As
Begin
SELECT EmpID,Name,StartDate,PhoneNumber,Address,Gender,BasicPay,Deduction,TaxablePay,IncomeTax,NetPay,Department
FROM Employee
left JOIN Payroll on Payroll.ID=Employee.EmpID
left JOIN DepartmentTable on Employee.EmpID=DepartmentTable.ID where StartDate between @FromDate and @ToDate;
end