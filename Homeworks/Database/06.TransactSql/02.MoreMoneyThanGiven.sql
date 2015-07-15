ALTER PROC usp_MoreThanGivenMoney(@money float = 5000)
AS
	SELECT p.FirstName, p.LastName, a.Balance FROM Persons p
	JOIN Accounts a
	ON p.Id = a.PersonId
	WHERE a.Balance > @money
GO