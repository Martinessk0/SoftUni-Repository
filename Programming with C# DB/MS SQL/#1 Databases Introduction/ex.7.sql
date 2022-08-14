CREATE TABLE People(
	[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Picture] VARBINARY(MAX) NULL CHECK(DATALENGTH([Picture])<= 2000000),
	[Height] DECIMAL(3, 2) NULL,
	[Weight] DECIMAL(5, 2) NULL,
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATETIME2(7) NOT NULL,
	[Biography] NVARCHAR(max) NULL
)

INSERT INTO People ([Name],[Gender],[Birthdate]) VALUES
('Ivan','m','2000-03-16'),
('Georgi','m','2005-03-26'),
('Pesho','m','2014-10-13'),
('Ivana','f','2004-02-15'),
('Mariq','f','2010-05-01')