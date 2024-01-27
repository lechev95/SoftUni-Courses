USE diablo2;

SELECT user_name,
SUBSTRING(email, LOCATE("@", email) + 1,
LENGTH(email) - LOCATE("@", email)) AS email_provider
FROM users
ORDER BY email_provider ASC, user_name ASC;