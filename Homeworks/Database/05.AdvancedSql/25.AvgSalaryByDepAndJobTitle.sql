SELECT d.Name, e.JobTitle, AVG(e.Salary) FROM Departments AS d
	INNER JOIN Employees e
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle