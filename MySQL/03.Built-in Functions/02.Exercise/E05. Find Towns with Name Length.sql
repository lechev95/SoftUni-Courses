USE soft_uni3;

SELECT name
FROM towns
WHERE LENGTH(name) 
BETWEEN 5 AND 6
ORDER BY name;