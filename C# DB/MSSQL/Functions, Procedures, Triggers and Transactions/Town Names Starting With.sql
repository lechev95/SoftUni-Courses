CREATE PROC usp_GetTownsStartingWith(@string VARCHAR(10))
AS
SELECT Name AS Town
FROM Towns
WHERE SUBSTRING(Name, 1, LEN(@string)) = @string

GO

EXEC dbo.usp_GetTownsStartingWith 'b'