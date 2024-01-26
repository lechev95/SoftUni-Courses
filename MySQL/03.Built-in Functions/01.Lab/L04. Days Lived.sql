USE book_library;

SELECT CONCAT(first_name, " ", last_name), 
TIMESTAMPDIFF(DAY, born, died) AS days_lived
FROM authors;