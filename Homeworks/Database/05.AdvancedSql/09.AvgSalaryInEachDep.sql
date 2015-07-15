SELECT d.Name, AVG(e.Salary) FROM Employees as e
	JOIN Departments as d
	ON e.DepartmentID = d.DepartmentID
	GROUP BY d.DepartmentID, d.Name
	ORDER BY d.Name