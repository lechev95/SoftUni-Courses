USE diablo2;

SELECT name AS game,
CASE 
	WHEN EXTRACT(HOUR FROM start)
		BETWEEN 0 AND 11
        THEN "Morning"
	WHEN EXTRACT(HOUR FROM start)
		BETWEEN 12 AND 17
        THEN "Afternoon"
	ELSE "Evening"
END AS part_of_the_day,
CASE
	WHEN duration <= 3
		THEN "Extra Short"
	WHEN duration 
		BETWEEN 4 AND 6
        THEN "Short"
	WHEN duration 
		BETWEEN 7 AND 10
		THEN "Long"
	ELSE "Extra Long"
END AS duration
FROM games AS g
ORDER BY g.name ASC, duration ASC, part_of_the_day ASC;