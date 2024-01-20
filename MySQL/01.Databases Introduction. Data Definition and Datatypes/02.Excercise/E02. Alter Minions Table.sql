USE minions;

ALTER TABLE minions
ADD COLUMN town_id INT NOT NULL AFTER age,
ADD CONSTRAINT fk_town_id
FOREIGN KEY (town_id)
REFERENCES towns(id);