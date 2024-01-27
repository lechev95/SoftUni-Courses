USE soft_uni4;

CREATE TABLE temp_new_table
AS SELECT *
FROM employees
WHERE salary > 30000;

DELETE FROM temp_new_table
WHERE manager_id = 42;

UPDATE temp_new_table
SET salary = salary + 5000
WHERE department_id = 1;

SELECT tnt.department_id,
AVG(tnt.salary) AS avg_salary
FROM temp_new_table AS tnt
GROUP BY tnt.department_id
ORDER BY tnt.department_id;