USE soft_uni5;

SELECT t.town_id, t.name AS town_name, a.address_text
FROM towns AS t
RIGHT JOIN addresses AS a
ON a.town_id = t.town_id
WHERE t.name = "San Francisco"
OR t.name = "Carnation"
OR t.name = "Sofia"
ORDER BY t.town_id, a.address_id;