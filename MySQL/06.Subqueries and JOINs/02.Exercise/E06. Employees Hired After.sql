USE soft_uni5;

SELECT e.first_name, e.last_name, e.hire_date, d.name AS department_name
FROM employees AS e
JOIN departments AS d
ON d.department_id = e.department_id
WHERE e.hire_date > "1999-01-01"
AND d.name LIKE "%Finance%"
OR d.name LIKE "%Sales%"
ORDER BY e.hire_date;