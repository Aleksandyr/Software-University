DECLARE empCoursor CURSOR READ_ONLY FOR
(
	SELECT e.FirstName, e.LastName, t.Name
		FROM Employees e
			INNER JOIN Addresses a
				ON e.AddressID = a.AddressID
			INNER JOIN Towns t
				ON t.TownID = a.TownID
)
ORDER BY t.Name DESC

OPEN empCoursor
DECLARE @firstName NVARCHAR(50), @print NVARCHAR(max), 
	@lastName NVARCHAR(50), 
	@townName NVARCHAR(50), 
	@currTownName NVARCHAR(50)
FETCH NEXT FROM empCoursor INTO @firstName, @lastName, @townName

SET @currTownName = @townName
SET @print = @currTownName + ' -> '

WHILE @@FETCH_STATUS = 0
	BEGIN
		IF(@currTownName = @townName)
			BEGIN
				SET @print = @print + @firstName + ' ' + @lastName + ', '
			END	
		ELSE
			BEGIN
				PRINT SUBSTRING(@print, 1, LEN(@print) - 1)
				SET @currTownName = @townName
				SET @print = @currTownName + ' -> '
			END
		FETCH NEXT FROM empCoursor INTO @firstName, @lastName, @townName
	END

CLOSE empCoursor
DEALLOCATE empCoursor