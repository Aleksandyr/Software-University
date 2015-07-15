SELECT e.FirstName, e.LastName, e.Salary, [Manager] = emp.FirstName FROM Employees e
	INNER JOIN Employees emp
	ON e.ManagerID = emp.EmployeeID