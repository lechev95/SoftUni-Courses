USE soft_uni5;

SELECT e.employee_id, e.first_name, e.last_name, d.department_id, e.salary
FROM employees AS e
INNER JOIN departments AS d
ON e.department_id = d.department_id
WHERE e.manager_id IS NULL; 