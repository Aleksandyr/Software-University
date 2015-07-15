CREATE VIEW	UserHasBeenInTheSysToday AS
	SELECT u.FullName FROM Users AS u
	WHERE DAY(u.LastTimeLog) = DAY(GETDATE())