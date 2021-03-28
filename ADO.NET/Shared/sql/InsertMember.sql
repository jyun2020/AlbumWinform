Create PROCEDURE dbo.InsertMember
(
	@UserName nvarchar(16),
	@Password nvarchar(40)
)
AS

INSERT INTO [dbo].[Member] ([UserName], [Password]) VALUES (@UserName, @Password);




================================================
CREATE PROCEDURE GetImmediateManager  
   @employeeID INT,  
   @managerID INT OUTPUT  
AS  
BEGIN  
   SELECT @managerID = ReportsTo
   FROM Employees
   WHERE EmployeeID = @employeeID  
END

	