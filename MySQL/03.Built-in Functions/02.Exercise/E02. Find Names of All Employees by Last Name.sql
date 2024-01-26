USE soft_uni3;

SELECT first_name, last_name 
FROM employees
WHERE last_name LIKE "%ei%"
ORDER BY employee_id;