SELECT m.EmployeeID, m.FirstName, m.LastName, COUNT(m.EmployeeID) FROM Employees AS e
	INNER JOIN Employees AS m
	ON e.ManagerID = m.EmployeeID
	GROUP BY m.FirstName, m.LastName, m.EmployeeID
		HAVING COUNT(m.EmployeeID) = 5
	ORDER BY m.LastName
