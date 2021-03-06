USE [Payroll_Services]
GO
/****** Object:  StoredProcedure [dbo].[insertDetails]    Script Date: 28-04-2022 07:45:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[insertDetails]
(@Name varchar(50),
@StartDate datetime,
@PhoneNumber bigint,
@Address varchar(80),
@Gender varchar(1),
@BasicPay bigint,
@Deduction bigint,
@TaxablePay bigint,
@IncomeTax bigint,
@NetPay bigint,
@Department varchar(20)
)
As
Begin
declare @new_identity int = 0

Insert into Employee(Name,StartDate,PhoneNumber,Address,Gender) Values (@Name,@StartDate,@PhoneNumber,@Address,@Gender);
select @new_identity = @@IDENTITY

insert into Payroll(Payroll.ID,BasicPay,Deduction,TaxablePay,IncomeTax,NetPay) values (@new_identity,@BasicPay,@Deduction,@TaxablePay,@IncomeTax,@NetPay);
insert into DepartmentTable(DepartmentTable.ID,Department) values(@new_identity,@Department);

End