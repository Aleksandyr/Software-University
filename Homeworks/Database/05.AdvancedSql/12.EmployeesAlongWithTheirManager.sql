SELECT e.FirstName + ' ' + e.LastName AS [Employee FULL Name], ISNULL(m.FirstName + ' ' + m.LastName, 'no manager') 
AS [Manager] 
	FROM Employees AS e
		LEFT OUTER JOIN Employees AS m
		ON e.ManagerID = m.EmployeeID