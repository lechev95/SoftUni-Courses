USE soft_uni5;

SELECT COUNT(salary) AS count
FROM employees 
WHERE salary > (SELECT AVG(salary) FROM employees);