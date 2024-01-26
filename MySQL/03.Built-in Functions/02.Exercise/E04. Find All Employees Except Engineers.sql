USE soft_uni3;

SELECT first_name, last_name
FROM employees
WHERE job_title NOT LIKE "%Engineer%"
ORDER BY employee_id;