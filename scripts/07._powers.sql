INSERT INTO Power(Name, Description)
VALUES ('Night Vision', 'User has excellent night vision, the ability to see in low light conditions or even total darkness.'),
('Telepathy', 'Users can perceive and interact with the mind, consciousness, and thoughts of themselves or others using their minds, thus being able to read & sense another person''s thoughts, communicate with them mentally, and a plethora of other capabilities through non-physical means.'),
('Summoning', 'Users can transport a person, creature, or object of choice by means of any type of Teleportation ability. This may also result from a previous summoning contract, which creates a connection between the summon and summoner.'),
('Immortality', 'Users possesses immortality: an endless lifespan, as they can never die, never age, never get sick, are completely self-sustaining, free from all bodily necessities, and can shrug off virtually any kind of physical damage.');

INSERT INTO SuperheroPowers (PowerID, SuperheroID)
SELECT Power.ID, Superhero.ID
FROM Power, Superhero
WHERE Power.Name ='Immortality' and Superhero.Alias = 'Iron Man';

INSERT INTO SuperheroPowers (PowerID, SuperheroID)
SELECT Power.ID, Superhero.ID
FROM Power, Superhero
WHERE Power.Name ='Immortality' and Superhero.Alias = 'Batman';

INSERT INTO SuperheroPowers (PowerID, SuperheroID)
SELECT Power.ID, Superhero.ID
FROM Power, Superhero
WHERE Power.Name ='Telepathy' and Superhero.Alias = 'Iron Man';

INSERT INTO SuperheroPowers (PowerID, SuperheroID)
SELECT Power.ID, Superhero.ID
FROM Power, Superhero
WHERE Power.Name ='Night Vision' and Superhero.Alias = 'Iron Man';
