USE geography;

SELECT country_name, population
FROM countries
WHERE continent_code = "EU"
ORDER BY population DESC, COUNTRY_NAME ASC
LIMIT 30;