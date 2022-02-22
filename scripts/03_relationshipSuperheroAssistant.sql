USE [SuperheroDB]
GO

ALTER TABLE Assistant
ADD CONSTRAINT FK_Assistant_Superhero FOREIGN KEY (SuperheroID) REFERENCES Superhero(ID);

