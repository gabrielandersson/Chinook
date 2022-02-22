
INSERT INTO Assistant(Name, SuperheroID)
VALUES ('Alfred Pennyworth', (SELECT ID from Superhero WHERE Alias='Batman')),
('Karen', (SELECT ID from Superhero WHERE Alias='Spiderman')),
('Karen', (SELECT ID from Superhero WHERE Alias ='Iron Man')),
('Jarvis', Null);
