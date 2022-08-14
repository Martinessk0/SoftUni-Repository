CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL
)

CREATE TABLE [Addresses](
	[Id] INT PRIMARY KEY IDENTITY,
	[AddressTest] NVARCHAR(50) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns](Id)
)

CREATE TABLE [Departments](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(25) NOT NULL,
	[MiddleName] NVARCHAR(25) NOT NULL,
	[LastName] NVARCHAR(25) NOT NULL,
	[JobTitle] NVARCHAR(25) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments](Id) NOT NULL,
	[HireDate] DATETIME2 NOT NULL,
	[Salary] DECIMAL(15,2) ,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id) 
)


INSERT INTO [Towns] ([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO [Departments] ([Name]) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO [Employees] ([FirstName],[MiddleName],[LastName],[JobTitle],[DepartmentId],[HireDate],[Salary]) VALUES
('Ivan','Ivanov','Ivanov','.NET Developer',4,'2013-02-01',3500.00),
('Petar','Petrov','Petrov','Senior Engineer',1,'2004-03-02',4000.00),
('Maria','Petrova','Ivanova','Intern',5,'2016-08-28',525.25),
('Georgi','Terziev','Ivanov','CEO',4,'2007-12-09',3000.00),
('Peter','Pan','Pan','Intern',4,'2016-08-28',599.88)
