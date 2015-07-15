CREATE PROC usp_FullName
AS
	SELECT p.FirstName + ' ' + p.LastName AS FullName FROM Persons p
GO