SELECT TOP(10)
FirstName, LastName, DepartmentID
FROM Employees AS e
WHERE Salary > (SELECT AVG(salary) FROM employees WHERE DepartmentID = e.DepartmentID GROUP BY DepartmentID)
ORDER BY DepartmentID
