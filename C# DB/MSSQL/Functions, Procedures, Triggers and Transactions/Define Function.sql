CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters VARCHAR(50), @Word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @CurrIdx INT = 1
	WHILE(@CurrIdx <= LEN(@Word))
		BEGIN
			DECLARE @CurrLetter VARCHAR(1) = SUBSTRING(@Word, @CurrIdx, 1)

			IF(CHARINDEX(@CurrLetter, @SetOfLetters)) = 0
			BEGIN
				RETURN 0
			END

			SET @CurrIdx += 1
		END
	RETURN 1
END