SELECT e.FirstName, e.LastName, e.Salary FROM Employees e
	WHERE e.Salary <= (
		SELECT MIN(m.Salary) + MIN(m.Salary) * 0.1
		FROM Employees m
		)