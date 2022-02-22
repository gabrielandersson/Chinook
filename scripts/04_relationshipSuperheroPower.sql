USE [SuperheroDB]
GO

CREATE TABLE [dbo].[SuperheroPowers](
	[SuperheroID] [int] NOT NULL,
	[PowerID] [int] NOT NULL,
	CONSTRAINT FK_Superhero FOREIGN KEY (SuperheroID) REFERENCES Superhero (ID),
	CONSTRAINT FK_Powers FOREIGN KEY (PowerID) REFERENCES Power(ID),
);