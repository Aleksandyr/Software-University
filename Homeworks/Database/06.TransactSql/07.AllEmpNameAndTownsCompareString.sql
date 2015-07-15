ALTER FUNCTION fn_ComprisedStringInGivenLetters(@string NVARCHAR(50), @word NVARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @index int, @len int, @char CHAR
	SET @index = 1
	SET @len = LEN(@word)
	
	WHILE @index <= @len
	BEGIN
		
		SET @char = SUBSTRING(@word, @index, 1)
		
		IF CHARINDEX(@char, @string) = 0
		BEGIN 
			RETURN 0
		END

		SET @index = @index + 1
	END

	RETURN 1
END

GO

DECLARE empCursor CURSOR READ_ONLY FOR
(
	SELECT e.FirstName, e.LastName, t.Name
		FROM Employees e
		INNER JOIN Addresses a
			ON e.AddressID = a.AddressID
		INNER JOIN Towns t
			ON t.TownID = a.TownID
)

OPEN empCursor
DECLARE @firstName NVARCHAR(50), @lastName NVARCHAR(50), @town NVARCHAR(50), @string NVARCHAR(50)
FETCH NEXT FROM empCursor INTO @firstName, @lastName, @town

SET @string = 'oistmiahf'

WHILE @@FETCH_STATUS = 0
BEGIN
	FETCH NEXT FROM empCursor INTO @firstName, @lastName, @town

	IF dbo.fn_ComprisedStringInGivenLetters(@string, @firstName) = 1
	BEGIN 
		PRINT @firstName
	END
	
	IF dbo.fn_ComprisedStringInGivenLetters(@string, @lastName) = 1
	BEGIN 
		PRINT @lastName
	END
	
	IF dbo.fn_ComprisedStringInGivenLetters(@string, @town) = 1
	BEGIN 
		PRINT @town
	END
END

CLOSE empCursor
DEALLOCATE empCursor