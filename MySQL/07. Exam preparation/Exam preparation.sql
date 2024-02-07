CREATE DATABASE IF NOT EXISTS colonial_journey_management_system_db;

USE colonial_journey_management_system_db;

-- 01. Table design
CREATE TABLE planets(
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(30) NOT NULL,
PRIMARY KEY (id)
);

CREATE TABLE spaceports(
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(50) NOT NULL,
planet_id INT, 
PRIMARY KEY (id),
FOREIGN KEY (planet_id) REFERENCES planets(id)
);

CREATE TABLE spaceships(
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(50) NOT NULL,
manufacturer VARCHAR(30) NOT NULL,
light_speed_rate INT DEFAULT 0,
PRIMARY KEY (id)
);

CREATE TABLE colonists(
id INT NOT NULL AUTO_INCREMENT,
first_name VARCHAR(20) NOT NULL,
last_name VARCHAR(20) NOT NULL,
ucn CHAR(10) NOT NULL UNIQUE,
birth_date DATE NOT NULL,
PRIMARY KEY (id)
);

CREATE TABLE journeys(
id INT NOT NULL AUTO_INCREMENT,
journey_start DATETIME NOT NULL,
journey_end DATETIME NOT NULL,
purpose ENUM('Medical', 'Technical', 'Educational', 'Military') NOT NULL,
destination_spaceport_id INT,
spaceship_id INT,
PRIMARY KEY (id),
FOREIGN KEY (destination_spaceport_id) REFERENCES spaceports(id),
FOREIGN KEY (spaceship_id) REFERENCES spaceships(id)
);

CREATE TABLE travel_cards(
id INT NOT NULL AUTO_INCREMENT,
card_number CHAR(10) UNIQUE NOT NULL,
job_during_journey ENUM('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook'),
colonist_id INT,
journey_id INT,
PRIMARY KEY (id),
FOREIGN KEY (colonist_id) REFERENCES colonists(id),
FOREIGN KEY (journey_id) REFERENCES journeys(id)
);