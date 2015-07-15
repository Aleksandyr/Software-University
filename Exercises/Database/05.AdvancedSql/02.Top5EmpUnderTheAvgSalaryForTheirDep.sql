SELECT TOP 5 e.FirstName, e.LastName, e.Salary, d.Name
	FROM Employees e
		INNER JOIN Departments d
			ON e.DepartmentID = d.DepartmentID
		WHERE e.Salary <
		(
			SELECT AVG(m.Salary)
				FROM Employees m
				WHERE DepartmentID = d.DepartmentID
		)
	ORDER BY e.Salary DESC
