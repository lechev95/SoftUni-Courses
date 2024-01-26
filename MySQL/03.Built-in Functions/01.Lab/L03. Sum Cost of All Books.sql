USE book_library;

SELECT ROUND(SUM(cost), 2) AS total_cost
FROM books;