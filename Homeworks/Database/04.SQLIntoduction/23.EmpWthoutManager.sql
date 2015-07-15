SELECT e.FirstName, [Manager] = m.FirstName FROM Employees e
	LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID 