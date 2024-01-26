USE geography2;

SELECT p.peak_name, r.river_name,
LOWER(CONCAT
(
LEFT(p.peak_name, LENGTH(p.peak_name) - 1), r.river_name
)
) AS mix
FROM rivers AS r,
peaks AS p
WHERE RIGHT(p.peak_name, 1) = LEFT(r.river_name, 1)
ORDER BY mix;