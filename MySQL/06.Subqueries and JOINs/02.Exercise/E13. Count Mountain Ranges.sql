USE geography3;

SELECT country_code, COUNT(mountain_id) AS mountain_range
FROM mountains_countries
WHERE country_code IN ("US", "RU", "BG")
GROUP BY country_code;