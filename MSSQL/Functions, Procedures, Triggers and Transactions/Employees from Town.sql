CREATE PROC usp_GetEmployeesFromTown(@Town VARCHAR(20)) 
AS
SELECT FirstName, LastName
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
WHERE t.Name = @Town

GO

EXEC usp_GetEmployeesFromTown 'Sofia'