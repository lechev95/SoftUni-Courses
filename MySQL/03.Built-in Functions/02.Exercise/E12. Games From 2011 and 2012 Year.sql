USE diablo2;

SELECT name, DATE_FORMAT(start, "%Y-%m-%d") AS start
FROM games
WHERE EXTRACT(YEAR FROM start) 
BETWEEN 2011 AND 2012
ORDER BY start, name
LIMIT 50;