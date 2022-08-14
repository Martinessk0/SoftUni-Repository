CREATE DATABASE [Hotel]

USE [Hotel]

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Title] NVARCHAR(15) NOT NULL,
	[Notes] VARCHAR(25)
)

CREATE TABLE [Customers](
	[AccountNumber] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[PhoneNumber] VARCHAR(10) NOT NULL,
	[EmergencyName] NVARCHAR(30),
	[EmergencyNumber] NVARCHAR(10),
	[Notes] VARCHAR(25)
)

CREATE TABLE [RoomStatus](
	[RoomStatus] BIT NOT NULL,
	[Notes] VARCHAR(25)
)

CREATE TABLE [RoomTypes](
	[RoomType] NVARCHAR(30) NOT NULL,
	[Notes] VARCHAR(25)
)

CREATE TABLE [BedTypes](
	[BedType] NVARCHAR(30) NOT NULL,
	[Notes] VARCHAR(25)
)

CREATE TABLE [Rooms](
	[RoomNumber] INT PRIMARY KEY,
	[RoomType] NVARCHAR(30) NOT NULL,
	[BedType] NVARCHAR(30) NOT NULL,
	[Rate]	INT,
	[RoomStatus] BIT NOT NULL,
	[Notes] VARCHAR(25),
)

CREATE TABLE [Payments](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	[PaymentDate] DATETIME2 NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber) NOT NULL,
	[FirstDateOccupied] DATETIME2,
	[LastDateOccupied] DATETIME2,
	[TotalDays] INT,
	[AmountCharged] DECIMAL(15,2),
	[TaxRate] INT,
	[TaxAmount] INT,
	[PaymentTotal] DECIMAL(15,2),
	[Notes] VARCHAR(25)
)

CREATE TABLE [Occupancies] (
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	[DateOccupied] DATETIME2 NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber) NOT NULL,
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms](RoomNumber) NOT NULL,
	[RateApplied] INT,
	[PhoneCharge] DECIMAL(15,2),
	[Notes] VARCHAR(25)
)

INSERT INTO [Employees] ([FirstName],[LastName],[Title]) VALUES
('Petur','Petrov','CEO'),
('Georgi','Ivanov','Worker'),
('Mariq','Marinova','Cleaner')

INSERT INTO [Customers] ([FirstName],[LastName],[PhoneNumber]) VALUES
('Ivan','Ivanov','0887866066'),
('Mario','Nikolov','0887866066'),
('Bojidar','Kolev','0887866066')

INSERT INTO [RoomStatus] ([RoomStatus]) VALUES
(0),
(0),
(1)

INSERT INTO [RoomTypes] ([RoomType]) VALUES
('apartament'),
('single room'),
('double room')

INSERT INTO [BedTypes] ([BedType]) VALUES
('single bed'),
('double bed')

INSERT INTO [Rooms] ([RoomNumber],[RoomType],[BedType],[RoomStatus]) VALUES
('102','single room','single bed',0),
('103','apartament'	,'double bed',0),
('104','double room','double bed',0)

INSERT INTO [Payments] ([EmployeeId],[PaymentDate],[AccountNumber]) VALUES
(1,GETDATE(),1),
(2,GETDATE(),2),
(3,GETDATE(),3)

INSERT INTO [Occupancies] ([EmployeeId],[DateOccupied],[AccountNumber],[RoomNumber]) VALUES
(1,GETDATE(),1,102),
(2,GETDATE(),2,103),
(3,GETDATE(),3,104)