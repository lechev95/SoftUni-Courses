USE restaurant;

SELECT p.category_id,
ROUND(AVG(p.price),2) AS average_price,
ROUND(MIN(p.price),2) AS cheapest_product,
ROUND(MAX(p.price),2) AS most_expensive_product
FROM products AS p
GROUP BY p.category_id;