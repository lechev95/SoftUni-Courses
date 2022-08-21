CREATE FUNCTION ufn_CashInUsersGames(@GameName VARCHAR(MAX))
RETURNS @ReturnedTable TABLE (
SumCash MONEY
)
AS
BEGIN
	DECLARE @Result MONEY

	SET @Result = 
		(SELECT SUM(ug.Cash) AS Cash
		FROM
			(SELECT Cash, GameId, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber
			FROM UsersGames
			WHERE GameId = (
				SELECT Id
				FROM Games
				WHERE Name = @GameName
				)
			)AS ug
		WHERE ug.RowNumber % 2 != 0
		)
	INSERT INTO @ReturnedTable SELECT @Result
	RETURN
END