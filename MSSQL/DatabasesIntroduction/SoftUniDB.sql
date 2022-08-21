----USE master
----GO 
----CREATE DATABASE SoftUni
----GO
----USE SoftUni
----GO

--CREATE TABLE Towns(
--Id INT PRIMARY KEY IDENTITY,
--[Name] VARCHAR(50) NOT NULL,
--)

--CREATE TABLE Addresses(
--Id INT PRIMARY KEY IDENTITY,
--AddressText VARCHAR(100),
--TownId INT FOREIGN KEY REFERENCES Towns(Id)
--)

--CREATE TABLE Departments(
--Id INT PRIMARY KEY IDENTITY,
--[Name] VARCHAR(50)
--)

--CREATE TABLE Employees(
--Id INT PRIMARY KEY IDENTITY,
--FirstName VARCHAR(10),
--MiddleName VARCHAR(10),
--LastName VARCHAR(10),
--JobTitle VARCHAR(50),
--DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
--HireDate DATETIME2,
--Salary DECIMAL,
--AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
--)

--INSERT INTO Towns([Name]) VALUES
--('Sofia'),
--('Plovdiv'),
--('Varna'),
--('Burgas')

--INSERT INTO Departments([Name]) VALUES
--('Engineering'),
--('Sales'),
--('Marketing'),
--('Software Development'),
--('Quality Assurance')

--INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
--('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013/02/01', 3500.00),
--('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004/03/02', 4000.00),
--('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016/08/28',	525.25),
--('Georgi', 'Teziev', 'Ivanov', 'CEO', 2,'2007/12/09', 3000.00),
--('Peter', 'Pan', 'Pan',	'Intern', 3, '2016/08/28', 599.88)

SELECT [Name] FROM Towns ORDER BY [Name]
SELECT [Name] FROM Departments ORDER BY [Name]
SELECT FirstName, MiddleName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC