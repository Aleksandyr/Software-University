INSERT INTO Users
	SELECT e.FirstName + ' ' + e.LastName AS FullName, 
	LOWER(SUBSTRING(e.FirstName, 1, 1)) + '' +LOWER(SUBSTRING(e.LastName, 1, 1)) AS PasswordUser,
	LOWER(SUBSTRING(e.FirstName, 1, 1)) + '' +LOWER(SUBSTRING(e.LastName, 1, 1)) AS Username,
	NULL AS LastTimeLog,
	3 AS GroupId
FROM Employees AS e
