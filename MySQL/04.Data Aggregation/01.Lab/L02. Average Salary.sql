USE restaurant;

SELECT e.department_id,
ROUND(AVG(e.salary),2) AS average_salary
FROM employees AS e
GROUP BY department_id;