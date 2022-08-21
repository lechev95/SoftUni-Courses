CREATE PROC usp_GetHoldersWithBalanceHigherThan(@Value DECIMAL(18, 4))
AS 
SELECT
ah.FirstName, ah.LastName
FROM AccountHolders AS ah
JOIN Accounts AS a
ON a.AccountHolderId = ah.Id
GROUP BY ah.FirstName, ah.LastName
HAVING SUM(a.Balance) > @Value
ORDER BY FirstName, LastName

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 200