CREATE FUNCTION ufn_CalculateFutureValue(@Sum MONEY, @YIR FLOAT, @Years INT)
RETURNS DECIMAL(10,4)
AS
BEGIN
RETURN @Sum * POWER((1+@YIR), @Years)
END
