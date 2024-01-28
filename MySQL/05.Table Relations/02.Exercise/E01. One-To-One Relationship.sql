CREATE DATABASE IF NOT EXISTS ex_table_relations1;

USE ex_table_relations1;

CREATE TABLE passports(
passport_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
passport_number VARCHAR(20) NOT NULL
);

CREATE TABLE people(
person_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
first_name VARCHAR(50) NOT NULL,
salary DOUBLE(10,2) NOT NULL,
passport_id INT,
CONSTRAINT fk_passport_id
FOREIGN KEY (passport_id)
REFERENCES passports(passport_id)
);

INSERT INTO passports
(
    passport_number
)
VALUES
( 
    'N34FG21B'
),
( 
    'K65LO4R7'
),
( 
    'ZE657QP2'
);

INSERT INTO people
( 
    first_name
    , salary
    , passport_id
)
VALUES
(
    'Roberto'
    , 43300.00
    , 2
),
( 
    'Tom'
    , 56100.00
    , 3
),
( 
    'Yana'
    , 60200.00
    , 1
);
