USE [SuperheroDB]
GO

CREATE TABLE [dbo].[Assistant](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[SuperheroID] [int] NULL,
    CONSTRAINT PK_Assistant PRIMARY KEY (ID),
);

CREATE TABLE [dbo].[Superhero](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Alias] [nvarchar](50) NULL,
	[Origin] [nvarchar](50) NULL,
    CONSTRAINT PK_Superhero PRIMARY KEY (ID),
	
);

CREATE TABLE [dbo].[Power](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](MAX) NULL,
    CONSTRAINT PK_Power PRIMARY KEY (ID),
);

