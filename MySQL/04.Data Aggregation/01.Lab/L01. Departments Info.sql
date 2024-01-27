USE restaurant;

SELECT e.department_id,
COUNT(e.department_id) AS number_of_employees
FROM employees AS e
GROUP BY department_id
ORDER BY department_id, number_of_employees;