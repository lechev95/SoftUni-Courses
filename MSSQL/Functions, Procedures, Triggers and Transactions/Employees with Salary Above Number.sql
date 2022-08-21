CREATE PROC usp_GetEmployeesSalaryAboveNumber(@salary DECIMAL(18,4))
AS 
SELECT FirstName, LastName
FROM Employees
WHERE Salary >= @salary

GO

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100