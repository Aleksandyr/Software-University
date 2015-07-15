--Problem 1. Create a table in SQL Server

CREATE TABLE MilionEtries
(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME NOT NULL,
	[Text] NVARCHAR(50) NOT NULL 
)

GO

BEGIN TRAN
	DECLARE @n INT = 5000000
	WHILE @n > 0
		BEGIN
			INSERT INTO MilionEtries
			VALUES(GETDATE(), 'Text' + CONVERT(nvarchar, @n))
			SET @n = @n - 1
		END
COMMIT TRAN

GO

SELECT m.Date FROM MilionEtries m

GO

--Problem 2. Add an index to speed-up the search by date 

DBCC DROPCLEANBUFFERS
DBCC FREEPROCCACHE

GO

CREATE NONCLUSTERED INDEX dateIndex
ON MilionEtries ([Date])

GO

SELECT [Date] FROM MilionEtries