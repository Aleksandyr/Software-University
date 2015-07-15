SELECT e.FirstName, e.LastName, e.Salary, [Email] = e.FirstName + '.' + e.LastName + '@softuni.bg' FROM Employees e
	INNER JOIN Employees se
	ON e.EmployeeID = se.EmployeeID
