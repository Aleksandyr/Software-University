SELECT AVG(e.Salary) FROM Employees as e
	JOIN Departments as d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.Name LIKE 'sales'