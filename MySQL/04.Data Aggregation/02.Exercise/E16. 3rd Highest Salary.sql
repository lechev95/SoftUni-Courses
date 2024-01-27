USE soft_uni4;

SELECT
    department_id,
    salary AS third_highest_salary
FROM (
    SELECT
        department_id,
        salary,
        DENSE_RANK() OVER (PARTITION BY department_id ORDER BY salary DESC) AS `Rank`
    FROM
        employees
) AS rank_subquery
WHERE `Rank` = 3
GROUP BY department_id, third_highest_salary
ORDER BY department_id;
