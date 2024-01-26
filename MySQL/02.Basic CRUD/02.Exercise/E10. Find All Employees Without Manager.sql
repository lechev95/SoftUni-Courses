USE soft_uni2;

SELECT first_name, last_name 
FROM employees
WHERE manager_id IS NULL;