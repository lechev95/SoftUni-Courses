USE soft_uni5;

SELECT e.employee_id, e.first_name, e.last_name, d.name AS department_name
FROM employees AS e
JOIN departments AS d
ON d.department_id = e.department_id
WHERE d.name LIKE "Sales"
ORDER BY e.employee_id DESC;