USE restaurant;

SELECT e.department_id,
ROUND(MIN(e.salary), 2) AS min_salary
FROM employees AS e
WHERE e.salary > 800
GROUP BY department_id
LIMIT 1;