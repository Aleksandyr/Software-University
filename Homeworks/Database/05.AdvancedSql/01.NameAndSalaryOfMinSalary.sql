select e.FirstName, e.LastName, e.Salary from Employees e
	where e.Salary  = (
		select MIN(m.Salary)
		from Employees m
	)
