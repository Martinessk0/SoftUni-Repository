CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(30) NOT NULL,
	[DailyRate] INT,
	[WeeklyRate] INT,
	[MonthlyRate] INT,
	[WeekendRate] INT
)

CREATE TABLE [Cars](
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] VARCHAR(15) NOT NULL,
	[Manufacturer] VARCHAR(30) NOT NULL,
	[Model] VARCHAR(15) NOT NULL,
	[CarYear] INT,
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
	[Doors] INT,
	[Picture] VARBINARY(MAX) CHECK(DATALENGTH([Picture]) <= 2000000),
	[Condition] VARCHAR(15),
	[Available] BIT,
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(20) NOT NULL,
	[Title] VARCHAR(25),
	[Notes] VARCHAR(25)
)

CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] VARCHAR(15) NOT NULL,
	[FullName] VARCHAR(40) NOT NULL,
	[Address] VARCHAR(50) NOT NULL,
	[City] VARCHAR(25) NOT NULL,
	[ZIPCode] VARCHAR(10) NOT NULL,
	[Notes] VARCHAR(25)
)

CREATE TABLE [RentalOrders](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id),
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers](Id),
	[CarId] INT FOREIGN KEY REFERENCES [Cars](Id),
	[TankLevel] INT,
	[KilometrageStart] INT,
	[KilometrageEnd] INT,
	[TotalKilometrage] INT,
	[StartDate] DATETIME2,
	[EndDate] DATETIME2,
	[TotalDays] DATETIME2,
	[RateApplied] INT,
	[TaxRate] INT,
	[OrderStatus] VARCHAR(20),
	[Notes] VARCHAR(25),
)

INSERT INTO [Categories]([CategoryName]) VALUES
('Sport'),
('Performance'),
('Advanced')

INSERT INTO [Cars]([PlateNumber],[Manufacturer],[Model],[CarYear],[CategoryId],Available) VALUES
('E 7777 ME'	,'Audi'	,'A5'	,2021,2,1),
('E 8066 MB'	,'BMW'	,'M5'	,2014,1,1),
('E EEEE CE'	,'Audi'	,'s5'	,2004,3,0)

INSERT INTO [Employees]([FirstName],[LastName],[Title]) VALUES
('Ivan','Ivanov','Worker'),
('Mario','Mariov','Boss'),
('Pesho','Georgiev','Cleaner')

INSERT INTO [Customers]([DriverLicenceNumber],[FullName],[Address],[City],[ZIPCode]) VALUES
('E 7685 BP','Dimitur Krumov','Vasil Levski 15','Sandanski','2800'),
('E 3124 MP','Georgi Ivanov','Ivan Vazov 115','Blagoevgrad','2700'),
('E 1123 CP','Oleg Vasilev','Hristo Botev 5','Blagoevgrad','2700')

INSERT INTO [RentalOrders]([EmployeeId],[CustomerId],[CarId],[OrderStatus]) VALUES
(1,1,2,'waiting'),
(1,2,1,'waiting'),
(1,3,3,'waiting')