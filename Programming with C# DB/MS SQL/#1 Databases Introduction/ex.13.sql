CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(50)
)

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(50)
)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(50)
)

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES Directors(Id),
	[CopyrightYear] DATETIME2,
	[Lenght] DECIMAL,
	[GenreId] INT FOREIGN KEY REFERENCES Genres(Id),
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
	[Rating] INT,
	[Notes] NVARCHAR(50)
)



INSERT INTO [Directors]([DirectorName],[Notes]) VALUES
('Joe Russo'	,'Infinity war'),
('Peyton Reed'	,NULL),
(' Ryan Fleck'	,'Captain Marvel'),
('Jon Favreau'	,'Iron Man'),
('Joe Johnston'	,NULL)

INSERT INTO [Genres]([GenreName],[Notes]) VALUES
('Action',NULL),
('SuperHeroes',NULL),
('Sci-fi',NULL),
('Action',NULL),
('Action',NULL)

INSERT INTO [Categories]([CategoryName],[Notes]) VALUES
('Phase 3',NULL),
('Phase 3',NULL),
('Phase 1',NULL),
('Phase 1',NULL),
('Phase 1',NULL)

INSERT INTO [Movies]([Title],[DirectorId],[CopyrightYear],[Lenght],[GenreId],[CategoryId],[Rating],[Notes]) VALUES
('Avengers: Infinity War'	,1	,'2018-04-27 00:00:00'	,2.5	,1	,1	,5	,NULL),
('Ant-Man and the Wasp'		,2	,'2018-07-06 00:00:00'	,2		,2	,2	,3	,NULL),
('Captain Marvel'			,3	,'2018-03-08 00:00:00'	,1.4	,3	,3	,4	,NULL),
('Iron Man'					,4	,'2008-05-02 00:00:00'	,2		,4	,4	,5	,NULL),
('Captain America'			,5	,'2011-07-22 00:00:00'	,1.55	,5	,5	,5	,NULL)
