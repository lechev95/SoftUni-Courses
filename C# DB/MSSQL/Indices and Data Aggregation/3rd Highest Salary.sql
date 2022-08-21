SELECT DISTINCT DepartmentID,Salary AS 'ThirdHighestSalary'
FROM(
SELECT Employees.DepartmentID, Employees.Salary, DENSE_RANK() OVER 
	(PARTITION BY Employees.DepartmentID ORDER BY Employees.Salary DESC) AS [Rank]
FROM Employees 
) AS Tbl
WHERE Tbl.[Rank] = 3