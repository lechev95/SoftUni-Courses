CREATE DATABASE Zoo
GO
USE Zoo
GO

--Task 1
CREATE TABLE Owners(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes(
Id INT PRIMARY KEY IDENTITY,
AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
Id INT PRIMARY KEY IDENTITY,
AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE Animals(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
BirthDate DATE NOT NULL,
OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE AnimalsCages(
CageId INT FOREIGN KEY REFERENCES Cages(Id) NOT NULL,
AnimalId INT FOREIGN KEY REFERENCES Animals(Id) NOT NULL,
PRIMARY KEY (CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments(
Id INT PRIMARY KEY IDENTITY,
DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
[Address] VARCHAR(50),
AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL
)

--Task 2
INSERT INTO Volunteers([Name],PhoneNumber,[Address],AnimalId,DepartmentId)
VALUES
('Anita Kostova','0896365412','Sofia, 5 Rosa str.',15,1),
('Dimitur Stoev','0877564223',null,	42,	4),
('Kalina Evtimova','0896321112','Silistra, 21 Breza str.',9,7),
('Stoyan Tomov','0898564100','Montana, 1 Bor str.',18,8),
('Boryana Mileva','0888112233',null,31,5)

INSERT INTO Animals([Name],BirthDate,OwnerId,AnimalTypeId)
VALUES
('Giraffe',	'2018-09-21',	21,	1),
('Harpy Eagle',	'2015-04-17',15,	3),
('Hamadryas Baboon',	'2017-11-02',	null,	1),
('Tuatara',	'2021-06-30',	2,	4)

--Task 3
UPDATE Animals SET 
OwnerId = 4
WHERE OwnerId IS NULL

--Task 4
DELETE FROM Volunteers 
WHERE DepartmentId = 2
DELETE FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'

--Task 5
SELECT
[Name],	PhoneNumber,	[Address],	AnimalId,	DepartmentId
FROM Volunteers
ORDER BY [Name] ASC, AnimalId ASC, DepartmentId DESC

--Task 6
SELECT
a.[Name],	ant.AnimalType,	FORMAT(a.BirthDate, 'dd.MM.yyyy')
FROM Animals AS a
JOIN AnimalTypes as ant
ON a.AnimalTypeId = ant.Id
ORDER BY a.[Name]

--Task 7
SELECT TOP(5)
o.[Name] AS [Owner]
, COUNT(a.Id) AS CountOfAnimals
FROM Owners AS o
JOIN Animals AS a
ON o.Id = A.OwnerId
GROUP BY o.[Name]
ORDER BY CountOfAnimals DESC, [Owner] ASC

--Task 8
SELECT 
CONCAT(o.[Name],'-',a.[Name]) AS OwnersAnimals, o.PhoneNumber, c.Id AS CageId
FROM Owners AS o
JOIN Animals AS a
ON o.Id = a.OwnerId
JOIN AnimalTypes AS aty
ON a.AnimalTypeId = aty.Id
JOIN AnimalsCages AS ac
ON ac.AnimalId = a.Id
JOIN Cages AS c
ON c.Id = ac.CageId
WHERE aty.AnimalType = 'Mammals'
ORDER BY o.[Name] ASC, a.[Name] DESC

--Task 9
SELECT 
v.[Name], v.PhoneNumber, SUBSTRING(v.Address, CHARINDEX(', ', v.Address, 1)+2, LEN(v.Address)) AS Address
FROM Volunteers AS v
JOIN VolunteersDepartments AS vd
ON v.DepartmentId = vd.Id
WHERE vd.Id = 2 AND  CHARINDEX('Sofia', v.Address, 1) != 0
ORDER BY v.[Name] ASC

--Task 10
SELECT
a.[Name],YEAR(a.BirthDate) AS BirthYear,aty.AnimalType
FROM Animals AS a
JOIN AnimalTypes AS aty
ON a.AnimalTypeId = aty.Id
WHERE a.OwnerId IS NULL
AND aty.AnimalType != 'Birds'
AND a.BirthDate > '01/01/2018'
ORDER BY a.[Name]

--Task 11
CREATE OR ALTER FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @Department INT = (
							SELECT Id 
							FROM VolunteersDepartments
							WHERE DepartmentName = @VolunteersDepartment
							)
	DECLARE @Volunteers INT = (
									SELECT COUNT(Id)
									FROM Volunteers
									WHERE DepartmentId = @Department
									)
	RETURN @Volunteers
END
GO
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')

--Task 12
CREATE OR ALTER PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
DECLARE @OwnersName VARCHAR(30) = 'For adoption' 
SELECT 
a.[Name], OwnersName =
CASE
WHEN a.OwnerId IS NULL THEN @OwnersName
ELSE o.[Name] 
END
FROM Owners AS o
FULL OUTER JOIN Animals AS a
ON o.Id = a.OwnerId
WHERE a.Name LIKE @AnimalName
END
GO
EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'