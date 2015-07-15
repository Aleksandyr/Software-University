CREATE PROC usp_WithdrawMoney(@accountId INT, @money FLOAT)
AS
	BEGIN TRAN
	
	DECLARE @currBalance MONEY = (
		SELECT a.Balance 
			FROM Accounts a
			WHERE a.Id = @accountId
	)
	IF(@currBalance < @money)
	BEGIN
		ROLLBACK TRAN 
	END
	ELSE
	BEGIN
		UPDATE Accounts
		SET Balance = Balance - @money
		WHERE @accountId = Id
		COMMIT TRAN
	END
GO

CREATE PROC usp_DepositeMoney(@accountId INT, @money FLOAT)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance + @money
		WHERE @accountId = Id
	COMMIT TRAN 
GO