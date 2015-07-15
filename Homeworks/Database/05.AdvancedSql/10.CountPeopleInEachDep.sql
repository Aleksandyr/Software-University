SELECT t.Name, d.Name, COUNT(*) FROM Employees as e
	JOIN Departments as d
		ON d.DepartmentID = e.DepartmentID
	JOIN Addresses a
		ON a.AddressID = e.AddressID
	JOIN Towns t 
		ON a.TownID = t.TownID
	GROUP BY t.Name, d.DepartmentID, d.Name
	ORDER BY d.Name