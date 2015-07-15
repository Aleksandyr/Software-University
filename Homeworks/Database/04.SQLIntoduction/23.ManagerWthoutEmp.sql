SELECT e.FirstName, [Manager] = m.FirstName FROM Employees e
	RIGHT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID 