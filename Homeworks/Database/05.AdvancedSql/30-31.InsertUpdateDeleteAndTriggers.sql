CREATE TABLE WorkHoursLogs(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Message NVARCHAR(150) NOT NULL,
	DateOfChange DATETIME NOT NULL,
)

GO

CREATE TRIGGER tr_WorkHoursInsert
ON WorkHours
FOR INSERT
AS
	INSERT INTO WorkHoursLogs(Message, DateOfChange)
	VALUES('Added row', GETDATE())
GO

CREATE TRIGGER tr_WorkHoursDelete
ON WorkHours
FOR DELETE
AS
	INSERT INTO WorkHoursLogs(Message, DateOfChange)
	VALUES('Deleted row', GETDATE())
GO

CREATE TRIGGER tr_WorkHoursUpdate
ON WorkHours
FOR UPDATE
AS
	INSERT INTO WorkHoursLogs(Message, DateOfChange)
	VALUES('Update row', GETDATE())
GO

INSERT INTO WorkHours(EmployeeId, DateTask, Task, HoursTask)
VALUES(10, GETDATE(), 'LQLQLQ', 8)

INSERT INTO WorkHours(EmployeeId, DateTask, Task, HoursTask)
VALUES(7, GETDATE(), 'Brum brym', 10)

DELETE WorkHours
WHERE EmployeeId = 10

UPDATE WorkHours
SET Task = 'New task'
WHERE EmployeeId = 7

SELECT * FROM WorkHoursLogs