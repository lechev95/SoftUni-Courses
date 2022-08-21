CREATE PROC usp_EmployeesBySalaryLevel(@Value VARCHAR(20))
AS
SELECT
FirstName, LastName
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @Value