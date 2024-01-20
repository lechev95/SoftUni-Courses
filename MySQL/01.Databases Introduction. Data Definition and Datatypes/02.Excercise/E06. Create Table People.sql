USE minions;

CREATE TABLE people(
id INT PRIMARY KEY AUTO_INCREMENT,
name VARCHAR(200) NOT NULL,
picture BLOB,
height DOUBLE(6,2),
weight DOUBLE(6,2),
gender CHAR(1) NOT NULL,
birthdate DATE NOT NULL,
biography BLOB
);

INSERT INTO people VALUES
(1, "name1", null, null, null, "m", "1976-02-12", "test"),
(2, "name1", null, null, null, "m", "1976-02-12", "test"),
(3, "name1", null, null, null, "m", "1976-02-12", "test"),
(4, "name1", null, null, null, "m", "1976-02-12", "test"),
(5, "name1", null, null, null, "m", "1976-02-12", "test");