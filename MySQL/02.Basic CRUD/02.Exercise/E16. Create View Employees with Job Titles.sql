USE soft_uni2;

CREATE OR REPLACE VIEW v_employees_job_titles AS
SELECT CONCAT(first_name, " ",
IF(middle_name IS NULL,"",CONCAT(middle_name," ")), last_name) AS full_name, job_title
FROM employees;