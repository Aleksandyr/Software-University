DECLARE @TempTalbe TABLE
(
	EmployeeId INT NOT NULL,
	ProjectId INT NOT NULL
)

INSERT INTO @TempTalbe
	SELECT EmployeeID, ProjectID FROM Employees
DROP TABLE EmployeesProjects
CREATE TABLE EmployeesProjects
(
	EmployeeID INT NOT NULL,
	ProjectID INT NOT NULL
)

INSERT INTO EmployeesProjects
	SELECT * FROM @TempTalbe
GO

SELECT * FROM EmployeesProjects