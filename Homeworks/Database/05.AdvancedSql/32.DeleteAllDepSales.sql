BEGIN TRAN
DELETE Employees
	WHERE DepartmentID = (
		SELECT DepartmentID 
		FROM Departments AS d
		WHERE d.Name LIKE 'sales'
	)

SELECT * FROM Employees AS e
	JOIN Departments AS d
		ON e.DepartmentID = d.DepartmentID
	WHERE d.Name LIKE 'sales'
ROLLBACK TRAN