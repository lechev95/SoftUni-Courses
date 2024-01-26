CREATE DATABASE IF NOT EXISTS car_rental;

USE car_rental;

CREATE TABLE categories(
id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
category VARCHAR(255) NOT NULL,
daily_rate DOUBLE(6,2),
weekly_rate DOUBLE(6,2),
monthly_rate DOUBLE(6,2),
weekend_rate DOUBLE(6,2)
);

CREATE TABLE cars(
id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
plate_number VARCHAR(30) NOT NULL UNIQUE,
make VARCHAR(255) NOT NULL,
model VARCHAR(255) NOT NULL,
car_year DATE,
category_id INT,
doors INT,
picture BLOB,
car_condition VARCHAR(255),
available BOOL
);

CREATE TABLE employees(
id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
first_name VARCHAR(40) NOT NULL,
last_name VARCHAR(255) NOT NULL,
title VARCHAR(255) NOT NULL,
notes TEXT
);

CREATE TABLE customers(
id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
driver_license_number INT NOT NULL UNIQUE,
full_name VARCHAR(255) NOT NULL,
address VARCHAR(255) NOT NULL,
city VARCHAR(60) NOT NULL,
zip_code INT,
notes TEXT
);

CREATE TABLE rental_orders(
id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
employee_id INT NOT NULL,
customer_id INT NOT NULL,
car_id INT NOT NULL,
car_condition VARCHAR(255),
tank_level INT,
kilometrage_start INT NOT NULL,
kilometrage_end INT NOT NULL,
total_kilometrage INT NOT NULL,
start_date DATE,
end_date DATE,
total_days INT, 
rate_applied DOUBLE(6,2),
tax_rate DOUBLE(6,2),
order_status BOOL,
notes TEXT
);