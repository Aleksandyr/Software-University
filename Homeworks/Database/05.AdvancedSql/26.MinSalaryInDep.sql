SELECT d.Name, e.JobTitle, e.FirstName, e.Salary AS [Min salary] FROM Employees AS e
	JOIN Departments AS d
	ON d.DepartmentID = e.DepartmentID
	WHERE e.Salary = (
		SELECT MIN(m.Salary)
		FROM Employees AS m
		WHERE DepartmentID = e.DepartmentID
	)
GROUP BY d.Name, e.JobTitle, e.FirstName, e.Salary