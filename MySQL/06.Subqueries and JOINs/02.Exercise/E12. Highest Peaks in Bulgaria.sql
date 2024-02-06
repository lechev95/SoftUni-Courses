USE geography3;

SELECT cou.country_code, m.mountain_range, p.peak_name, p.elevation
FROM countries AS cou
JOIN mountains_countries AS mc
ON cou.country_code = mc.country_code
JOIN mountains AS m
ON mc.mountain_id = m.id
JOIN peaks AS p 
ON p.mountain_id = m.id
WHERE p.elevation > 2835
AND cou.country_code LIKE "BG"
ORDER BY p.elevation DESC;