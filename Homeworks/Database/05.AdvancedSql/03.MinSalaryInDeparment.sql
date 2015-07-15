SELECT e.FirstName + ' ' + e.LastName as [Full name], e.Salary, d.Name as [Deparment name] 
	FROM Employees as e
	JOIN Departments as d
	ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary = (
		SELECT MIN(m.Salary)
		FROM Employees m
		WHERE DepartmentID = d.DepartmentID
		)