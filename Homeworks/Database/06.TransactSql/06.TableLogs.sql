ALTER TRIGGER tr_BalanceChanged 
ON Accounts
FOR UPDATE
AS
	INSERT INTO Logs(accountId, oldSum, newSum)
	SELECT d.Id, d.Balance, i.Balance
	FROM INSERTED i
		INNER JOIN DELETED d
		ON d.Id = i.Id
GO