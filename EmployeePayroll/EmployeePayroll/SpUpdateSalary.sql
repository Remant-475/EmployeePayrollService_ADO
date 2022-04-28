USE [Payroll_Services]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure UpdateRecord
(@EmpID int,
@Name varchar(200),
@BasicPay Bigint
)
As
Begin
update Payroll set BasicPay=@BasicPay where ID=@EmpID
end

exec UpdateRecord 1,'Sachin',50000000