USE ex_table_relations1;

DROP TABLE IF EXISTS models;

DROP TABLE IF EXISTS manufacturers;

CREATE TABLE manufacturers
(
    manufacturer_id INT PRIMARY KEY AUTO_INCREMENT,
    name NVARCHAR(30) NOT NULL,
    established_on DATE NOT NULL
);

CREATE TABLE models
(
    model_id INT PRIMARY KEY AUTO_INCREMENT,
    name NVARCHAR(30) NOT NULL,
    manufacturer_id INT,
    FOREIGN KEY (manufacturer_id) REFERENCES manufacturers(manufacturer_id)
);

INSERT INTO manufacturers (name, established_on)
VALUES
    ('BMW', '1916-03-07'),
    ('Tesla', '2003-01-01'),
    ('Lada', '1966-05-01');

INSERT INTO models (name, manufacturer_id)
VALUES
    ('X1', 1),
    ('i6', 1),
    ('Model S', 2),
    ('Model X', 2),
    ('Model 3', 2),
    ('Nova', 3);
