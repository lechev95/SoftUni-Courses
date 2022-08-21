create database Airport;
go 

use Airport

go 

-- task 1
create table Passengers(
Id int primary key Identity,
FullName varchar(100) UNIQUE not null,
Email varchar(50) UNIQUE not null
)

create table Pilots(
Id int primary key Identity,
FirstName varchar(30) UNIQUE not null,
LastName varchar(30) UNIQUE not null,
Age tinyint NOT NULL CHECK (Age >= 21 AND Age <= 62),
Rating REAL CHECK (Rating >= 0.0 AND Rating <= 10.0)
)

create table AircraftTypes(
Id int primary key Identity,
TypeName varchar(30) UNIQUE not null
)

create table Aircraft(
Id int primary key Identity,
Manufacturer varchar(25) not null,
Model varchar(30) not null,
[Year] int not null,
FlightHours int ,
Condition char not null,
TypeId int NOT NULL FOREIGN KEY REFERENCES AircraftTypes(Id)
)


create table PilotsAircraft(
AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
PilotId INT NOT NULL FOREIGN KEY REFERENCES Pilots(Id),
PRIMARY KEY (AircraftId, PilotId)
)


create table Airports(
Id int primary key Identity,
AirportName varchar(70) UNIQUE not null,
Country varchar(100) UNIQUE not null
)


create table FlightDestinations(
Id int primary key Identity,
AirportId INT NOT NULL FOREIGN KEY REFERENCES Airports(Id),
Start datetime not null,
AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
TicketPrice DECIMAL(18,2) not null DEFAULT (15)
)

-- task 2
insert into Passengers (FullName,Email) 
SELECT 
	concat([FirstName],' ',[LastName]),
	concat([FirstName],[LastName],'@gmail.com') 
FROM Pilots where id between 5 and 15


-- task 3

update Aircraft set condition='A' 
where condition in ('C','B')
and (FlightHours is Null or FlightHours <= 100 )
and [Year] >='2013'

-- task 4

delete Passengers where len(FullName) <=10

-- task 5

select Manufacturer, Model, FlightHours, Condition from Aircraft order by 3 desc

-- task 6

select 
	p.FirstName, 
	p.LastName, 
	a.Manufacturer, 
	a.Model, 
	a.FlightHours 
from Pilots p, PilotsAircraft pa, Aircraft a
where p.Id=pa.PilotId
and pa.AircraftId=a.Id
and a.FlightHours is not null
and a.FlightHours <304 
order by FlightHours desc, FirstName

-- task 7

select top 20  
	fd.Id as  DestinationId, 
	fd.Start,
	p.FullName, 
	a.AirportName, 
	fd.TicketPrice 
from FlightDestinations fd, Airports a, Passengers p
where fd.AirportId=a.Id
and fd.PassengerId=p.Id
and format(fd.Start,'dd') % 2 = 0
order by fd.TicketPrice desc, a.AirportName

-- task 8

select 
	a.Id as AircraftId,
	a.Manufacturer,
	a.FlightHours,
	count(*) as FlightDestinationsCount,
	round(avg(fd.TicketPrice),2) as AvgPrice 
from Aircraft a, FlightDestinations fd
where a.Id=fd.AircraftId
group by a.Id, a.Manufacturer,a.FlightHours
having count(*)>1
order by FlightDestinationsCount desc, a.Id 

-- task 9

select 
	p.FullName,
	count(*) as CountOfAircraft,
	sum(TicketPrice) as  TotalPayed 
from Passengers p, FlightDestinations fd
where p.Id=fd.PassengerId
group by p.FullName
having count(*) >1 and SUBSTRING(FullName,2,1)='a' 
order by 1

-- task 10 

select 
	a.AirportName,
	concat(format(fd.Start,'yyyy-MM-dd HH:mm:ss'),'.000') as DayTime,
	fd.TicketPrice,
	p.FullName,
	ac.Manufacturer,
	ac.Model
from FlightDestinations fd, Airports a, Passengers p, Aircraft ac
where fd.AirportId=a.Id
and fd.PassengerId=p.Id
and fd.AircraftId=ac.Id
and format(fd.Start,'HH:mm:ss')>='06:00:00'
and format(fd.Start,'HH:mm:ss')<='20:59:59'
and fd.TicketPrice>2500
order by ac.Model

go
-- end batch

-- task 11


create function udf_FlightDestinationsByEmail(@email varchar(50)) 
returns int  
as 

begin
	 DECLARE @result int
		set @result = (select count(*) from FlightDestinations where PassengerId in (select id from Passengers where Email=@email))
	 return @result 
end

--test    select  fullname,  dbo.udf_FlightDestinationsByEmail(email) from Passengers where email in ('PierretteDunmuir@gmail.com','Montacute@gmail.com','MerisShale@gmail.com')

-- task 12
go
-- end batch
create procedure usp_SearchByAirportName @airportName varchar(70)
as 
begin
select 
	a.AirportName, 
	p.FullName, 
	case 
		when fd.TicketPrice<=400 then'Low' 
		when  fd.TicketPrice>400 and fd.TicketPrice<=1500 then 'Medium'
		when  fd.TicketPrice>1500  then 'High'
	end as LevelOfTickerPrice, 
	ac.Manufacturer, 
	ac.Condition, 
	at.TypeName 
from Airports a,FlightDestinations fd, Passengers p,Aircraft ac,AircraftTypes at
where a.AirportName=@airportName
and a.Id=fd.AirportId
and fd.PassengerId=p.Id
and fd.AircraftId=ac.Id
and ac.TypeId=at.Id
order by ac.Manufacturer, p.FullName
end 


EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'