CREATE TABLE Users(
	[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Username] [varchar](30) NOT NULL,
	[Password] [varchar](26) NOT NULL,
	[ProfilePicture] [varbinary](max) NULL,
	[LastLoginTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
)

INSERT INTO Users ([Username],[Password],[IsDeleted]) VALUES
('ASDSASD','ASSD123',1),
('DAS','ASSD123',1),
('ASDSGFGDFSFASD','ASSD123',0),
('fadas','1234556',0),
('ssda','ASSD123',1)