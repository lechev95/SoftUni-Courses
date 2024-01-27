USE soft_uni4;

SELECT e.department_id,
MAX(e.salary) AS max_salary
FROM employees AS e
GROUP BY e.department_id
HAVING NOT max_salary BETWEEN 30000 AND 70000
ORDER BY e.department_id;