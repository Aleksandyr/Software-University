ALTER FUNCTION fn_CalcSumWithGivenInterestAndMonths (@sum float, @interest float, @months int)
RETURNS float
AS
BEGIN
	RETURN @sum * POWER((1 + (@interest / 100) / 12), @months / 12)
END
