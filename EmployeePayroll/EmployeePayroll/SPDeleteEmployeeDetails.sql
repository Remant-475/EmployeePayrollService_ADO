USE [Payroll_Services]
GO
/****** Object:  StoredProcedure [dbo].[DeleteRecord]    Script Date: 09-05-2022 05:30:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[DeleteRecord]
(
@Name varchar(200)
)
As
Begin
delete Employee from Employee

left join DepartmentTable on Department=Department left join Payroll on BasicPay=BasicPay where Name = @Name;

end