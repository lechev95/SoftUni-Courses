USE master
GO
CREATE DATABASE Hotel
GO 
USE Hotel
GO

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(10) NOT NULL,
LastName VARCHAR(10) NOT NULL,
Title VARCHAR(10) NOT NULL,
Notes VARCHAR(250)
)

CREATE TABLE Customers(
AccountNumber VARCHAR(10) PRIMARY KEY NOT NULL,
FirstName VARCHAR(10) NOT NULL,
LastName VARCHAR(10) NOT NULL,
PhoneNumber VARCHAR(10),
EmergencyName VARCHAR(10),
EmergencyNumber VARCHAR(10),
Notes VARCHAR(250),
)

CREATE TABLE RoomStatus(
RoomStatus VARCHAR(10) PRIMARY KEY NOT NULL,
Notes VARCHAR(250)
)

CREATE TABLE RoomTypes(
RoomType VARCHAR(10) PRIMARY KEY NOT NULL,
Notes VARCHAR(250)
)

CREATE TABLE BedTypes(
BedType VARCHAR(10) PRIMARY KEY NOT NULL,
Notes VARCHAR(250)
)

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY IDENTITY,
RoomType VARCHAR(10) FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType VARCHAR(10) FOREIGN KEY REFERENCES BedTypes(BedType),
Rate DECIMAL,
RoomStatus VARCHAR(10) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
Notes VARCHAR(250)
)

CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATETIME2,
AccountNumber VARCHAR(10) FOREIGN KEY REFERENCES Customers(AccountNumber),
FirstDateOccupied DATETIME2,
LastDateOccupied DATETIME2,
TotalDays INT,
AmountCharged DECIMAL,
TaxRate DECIMAL,
TaxAmount DECIMAL,
PaymentTotal DECIMAL,
Notes VARCHAR(250)
)

CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATETIME2,
AccountNumber VARCHAR(10) FOREIGN KEY REFERENCES Customers(AccountNumber),
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied DECIMAL,
PhoneCharge DECIMAL,
Notes VARCHAR(250)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Lecho', 'Lechev', 'Manager', Null),
('Lecho', 'Lechev', 'Manager', Null),
('Lecho', 'Lechev', 'Manager', Null)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName,
EmergencyNumber, Notes) VALUES
('Acc', 'Lecho', 'Lechev', Null, Null, Null, Null),
('Acc2', 'Lecho', 'Lechev', Null, Null, Null, Null),
('Acc3', 'Lecho', 'Lechev', Null, Null, Null, Null)

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
('occupied', Null),
('free', Null),
('new', Null)

INSERT INTO RoomTypes(RoomType, Notes) VALUES
('occupied', Null),
('free', Null),
('new', Null)

INSERT INTO BedTypes(BedType, Notes) VALUES
('occupied', Null),
('free', Null),
('new', Null)

INSERT INTO Rooms(RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(Null, Null, Null, Null, Null),
(Null, Null, Null, Null, Null),
(Null, Null, Null, Null, Null)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied,LastDateOccupied, TotalDays,
AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null),
(Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null),
(Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(Null, Null, Null, Null, Null, Null, Null),
(Null, Null, Null, Null, Null, Null, Null),
(Null, Null, Null, Null, Null, Null, Null)