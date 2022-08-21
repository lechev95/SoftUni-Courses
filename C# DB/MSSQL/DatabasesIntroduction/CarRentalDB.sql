USE master
GO
CREATE DATABASE CarRentals
GO
USE CarRentals
GO

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(10) NOT NULL,
DailyRate DECIMAL(2,2),
WeeklyRate DECIMAL(2,2),
MonthlyRate DECIMAL(2,2),
WeekendRate DECIMAL(2,2)
)

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY,
PlateNumber NVARCHAR(10) UNIQUE NOT NULL,
Manufacturer NVARCHAR(20),
Model NVARCHAR(20),
CarYear INT NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Doors INT,
Picture VARBINARY(MAX),
CHECK (DATALENGTH(Picture) <= 900000),
Condition NVARCHAR(10),
Available CHAR(1),
CHECK (Available = 'y' OR Available = 'n')
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(10),
LastName NVARCHAR(10),
Title NVARCHAR(10),
Notes NVARCHAR(250)
)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY,
DriverLicenseNumber BIGINT UNIQUE NOT NULL,
FullName NVARCHAR(50),
[Address] NVARCHAR(50), 
City NVARCHAR(50),
ZIPCode INT,
Notes NVARCHAR(250)
)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
CarId INT FOREIGN KEY REFERENCES Cars(Id),
TankLevel DECIMAL(2,2),
KilometrageStart BIGINT,
KilometrageEnd BIGINT,
TotalKilometrage INT,
StartDate DATETIME2,
EndDate DATETIME2,
TotalDays INT,
RateApplied DECIMAL(2,2),
TaxRate DECIMAL(2,2),
OrderStatus NVARCHAR(10),
Notes NVARCHAR(250)
)

GO

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Car', Null, Null, Null, Null),
('Van', Null, Null, Null, Null),
('Microbus', Null, Null, Null, Null)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('CH4541AT', 'VW', 'BORA', 2001, 1, 4, Null, 'GOOD', 'y'),
('CH1084CH', 'CITROEN', 'JUMPER', 2010, 3, 8, Null, 'GOOD', 'y'),
('CB8631KP', 'CITROEN', 'BERLINGO', 2021, 2, 4, Null, 'GOOD', 'n')

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Lecho', 'Lechev', 'Manager', Null),
('Zlatina', 'Mihaylova', 'Seller', Null),
('Mariyan', 'Davidkov', 'Mechanic', Null)

INSERT INTO Customers(DriverLicenseNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
(2122212210, 'Petko Mihaylov', 'Stefan Egarov Str. 7', 'Sliven', '8801', Null),
(1210151790, 'Nikol Hristova', 'Polski Venets Str. 10, ap. 2', 'Sofia', '1710', Null),
(5056120301, 'Ralitsa Davidkova', 'Rakovska Str. 55', 'Sliven', '8804', Null)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart,
KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate,
OrderStatus, Notes) VALUES
(1, 1, 3, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null),
(2, 1, 3, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null),
(3, 1, 3, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null, Null)

