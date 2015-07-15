ALTER PROC usp_GiveInterestSumInGivenPerson(@accountId INT, @interest float)
AS
	SELECT p.FirstName, p.LastName, a.Balance,
	dbo.fn_CalcSumWithGivenInterestAndMonths(CAST(a.Balance AS float), @interest, 1) AS [Money with interest]
	FROM Persons p
		JOIN Accounts a
		ON p.Id = a.PersonId
		WHERE @accountId = a.Id
GO