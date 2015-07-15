SELECT p.Name, SUM(e.Salary)
	FROM Projects p
		INNER JOIN EmployeesProjects ep
			ON p.ProjectID = ep.ProjectID
		INNER JOIN Employees e
			ON e.EmployeeID = ep.EmployeeID
	GROUP BY p.Name