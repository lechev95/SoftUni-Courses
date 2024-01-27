USE soft_uni4;

SELECT COUNT(e.salary) AS ""
FROM employees AS e
WHERE manager_id IS NULL;