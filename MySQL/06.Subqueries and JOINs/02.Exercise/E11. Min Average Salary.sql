USE soft_uni5;

SELECT AVG(e.salary) AS min_average_salary
FROM employees AS e 
JOIN departments AS d
ON d.department_id = e.department_id
GROUP BY e.department_id
ORDER BY min_average_salary ASC
LIMIT 1;