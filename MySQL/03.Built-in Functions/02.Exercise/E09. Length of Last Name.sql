USE soft_uni3;

SELECT first_name, last_name
FROM employees
WHERE LENGTH(last_name) = 5;