select e.FirstName + ' ' + e.LastName as [Full name], m.FirstName + ' ' + m.LastName as [Manager], e.JobTitle
	from Employees e
	join Employees m
	on e.ManagerID = m.EmployeeID
where e.DepartmentID =
( 
	select d.DepartmentID
	from Departments d 
	where d.Name = 'sales'
)