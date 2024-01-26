USE soft_uni2;

CREATE OR REPLACE VIEW v_employees_salaries AS 
SELECT first_name, last_name, salary
FROM employees;