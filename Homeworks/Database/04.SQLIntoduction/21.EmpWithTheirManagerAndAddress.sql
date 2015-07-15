SELECT e.FirstName, e.LastName, e.Salary, [Manager] = emp.FirstName, [Address] = a.AddressText FROM Employees e
	INNER JOIN Employees emp
	ON e.ManagerID = emp.EmployeeID
	Inner JOIN Addresses a
	ON emp.EmployeeID = a.AddressID