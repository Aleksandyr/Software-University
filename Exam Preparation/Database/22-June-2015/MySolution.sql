--Problem 1
SELECT TeamName FROM Teams
ORDER BY TeamName

GO

--Problem 2

SELECT TOP 50 c.CountryName, c.Population 
	FROM Countries c
ORDER BY c.Population DESC

GO

--Problem 3

SELECT c.CountryName, 
	c.CountryCode, 
	CAST(
		CASE WHEN c.CurrencyCode = 'EUR' 
		THEN 'Inside' 
		ELSE 'Outside' 
		END AS NVARCHAR(50)) AS Eurozone  
	FROM Countries c
ORDER BY c.CountryName

GO

--Problem 4

SELECT t.TeamName AS [Team Name], t.CountryCode AS [Country Code] 
	FROM Teams t 
	WHERE t.TeamName LIKE '%[0-9]'

GO
 --Problem 5

SELECT 
	 c1.CountryName AS [Home Team], 
	 c2.CountryName AS [Away Team],
	 im.MatchDate AS [Match Date]
FROM InternationalMatches im
	JOIN Countries c1
		ON c1.CountryCode = im.HomeCountryCode
	JOIN Countries c2
		ON c2.CountryCode = im.AwayCountryCode
ORDER BY im.MatchDate DESC

GO

--Problem 6
SELECT t.TeamName AS [Team Name], 
	l.LeagueName AS [League],  
	(CASE WHEN l.CountryCode IS NULL THEN 'International' ELSE c.CountryName END) AS [League Country]
	FROM Teams t
	JOIN Leagues_Teams lt
		ON lt.TeamId = t.Id
	JOIN Leagues l
		ON l.Id = lt.LeagueId
	LEFT JOIN Countries c
		ON c.CountryCode = l.CountryCode
ORDER BY t.TeamName, l.LeagueName

GO

--Problem 7

SELECT 
	t.TeamName AS [Team],
	(SELECT COUNT(tm.Id) 
		FROM TeamMatches tm
		WHERE tm.HomeTeamId = t.Id OR tm.AwayTeamId = t.Id) AS [Matches Count]
	FROM Teams t
	WHERE (SELECT COUNT(tm.Id) FROM TeamMatches tm WHERE tm.HomeTeamId = t.Id OR tm.AwayTeamId = t.Id) > 1
ORDER BY TeamName

GO

--Problem 8

SELECT l.LeagueName AS [League Name],
		COUNT(DISTINCT lt.TeamId) AS Teams,
		COUNT(DISTINCT tm.Id) AS Matches,
		ISNULL(AVG(tm.HomeGoals + tm.AwayGoals), 0) AS [Average Goals]
	FROM Leagues l
	LEFT JOIN Leagues_Teams lt
		ON l.Id = lt.LeagueId
	LEFT JOIN TeamMatches tm
		ON tm.LeagueId = l.Id
GROUP BY l.LeagueName
ORDER BY Teams DESC, Matches Desc

GO

--Problem 9

SELECT t.TeamName, ISNULL(SUM(tm1.HomeGoals), 0) + ISNULL(SUM(tm2.AwayGoals), 0) AS [Total Goals] FROM Teams t
	LEFT JOIN TeamMatches tm1
		ON t.Id = tm1.HomeTeamId
	LEFT JOIN TeamMatches tm2
		ON t.Id = tm2.AwayTeamId
GROUP BY t.TeamName
ORDER BY [Total Goals] DESC, t.TeamName ASC

GO

--Problem 10

SELECT tm1.MatchDate AS [First Date], tm2.MatchDate AS [Second Date] 
	FROM TeamMatches tm1, TeamMatches tm2
	WHERE DATEPART(DAY, tm1.MatchDate) = DATEPART(DAY, tm2.MatchDate) AND
		DATEPART(HOUR, tm1.MatchDate) < DATEPART(HOUR, tm2.MatchDate)
ORDER BY tm1.MatchDate DESC, tm2.MatchDate DESC

GO

--Problem 11

SELECT LOWER(t1.TeamName + SUBSTRING(REVERSE(t2.TeamName), 2, LEN(t2.TeamName))) AS [Mix] FROM Teams t1, Teams t2
	WHERE SUBSTRING(t1.TeamName, LEN(t1.TeamName), 1) = SUBSTRING(REVERSE(t2.TeamName), 1, 1)
ORDER BY Mix

GO

--Problem 12

SELECT c.CountryName AS [Country Name],  
	COUNT(DISTINCT im1.Id) + COUNT(DISTINCT im2.Id) AS [International Matches], 
	COUNT(DISTINCT tm.Id) AS [Team Matches]
	FROM Countries c
	LEFT JOIN InternationalMatches im1
		ON c.CountryCode = im1.HomeCountryCode
	LEFT JOIN InternationalMatches im2
		ON c.CountryCode = im2.AwayCountryCode
	LEFT JOIN Leagues l
		ON c.CountryCode = l.CountryCode
	LEFT JOIN TeamMatches tm
		ON tm.LeagueId = l.Id
GROUP BY c.CountryName
HAVING COUNT(DISTINCT im1.Id) + COUNT(DISTINCT im2.Id) != 0 OR COUNT(DISTINCT tm.Id) != 0
ORDER BY [International Matches] DESC, [Team Matches] DESC, c.CountryName

GO

--Problem 13

INSERT INTO Teams(TeamName) VALUES
 ('US All Stars'),
 ('Formula 1 Drivers'),
 ('Actors'),
 ('FIFA Legends'),
 ('UEFA Legends'),
 ('Svetlio & The Legends')
GO

INSERT INTO FriendlyMatches(
  HomeTeamId, AwayTeamId, MatchDate) VALUES
  
((SELECT Id FROM Teams WHERE TeamName='US All Stars'), 
 (SELECT Id FROM Teams WHERE TeamName='Liverpool'),
 '30-Jun-2015 17:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Formula 1 Drivers'), 
 (SELECT Id FROM Teams WHERE TeamName='Porto'),
 '12-May-2015 10:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Actors'), 
 (SELECT Id FROM Teams WHERE TeamName='Manchester United'),
 '30-Jan-2015 17:00'),

((SELECT Id FROM Teams WHERE TeamName='FIFA Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='UEFA Legends'),
 '23-Dec-2015 18:00'),

((SELECT Id FROM Teams WHERE TeamName='Svetlio & The Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='Ludogorets'),
 '22-Jun-2015 21:00')

GO

SELECT 
	t1.TeamName [Home Team],
	t2.TeamName [Away Team],
	fm.MatchDate [Match Date]
FROM FriendlyMatches fm
	JOIN Teams t1
		ON t1.Id = fm.HomeTeamId
	JOIN Teams t2
		ON t2.Id = fm.AwayTeamId
UNION
	SELECT 
	t1.TeamName [Home Team],
	t2.TeamName [Away Team],
	tm.MatchDate [Match Date]
FROM TeamMatches tm
	LEFT JOIN Teams t1
		ON t1.Id = tm.HomeTeamId
	LEFT JOIN Teams t2
		ON t2.Id = tm.AwayTeamId
ORDER BY fm.MatchDate DESC

--Problem 14

BEGIN TRAN
ALTER TABLE Leagues
ADD IsSeasonal INT NOT NULL DEFAULT 0
COMMIT

BEGIN TRAN
INSERT INTO TeamMatches(HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId)
VALUES
(
	(SELECT Id FROM Teams WHERE TeamName LIKE 'Empoli'),
	(SELECT Id FROM Teams WHERE TeamName LIKE 'Parma'),
	2,
	2,
	CAST('19-Apr-2015 16:00' AS DATETIME),
	(SELECT Id FROM Leagues WHERE LeagueName LIKE 'Italian Serie A')
)
COMMIT

BEGIN TRAN
INSERT INTO TeamMatches(HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId)
VALUES
(
	(SELECT Id FROM Teams WHERE TeamName LIKE 'Internazionale'),
	(SELECT Id FROM Teams WHERE TeamName LIKE 'AC Milan'),
	2,
	2,
	CAST('19-Apr-2015 21:45' AS DATETIME),
	(SELECT Id FROM Leagues WHERE LeagueName LIKE 'Italian Serie A')
)
COMMIT

UPDATE Leagues
SET IsSeasonal = 1
WHERE Id IN(
SELECT l.Id FROM Leagues l
	JOIN TeamMatches tm
		ON tm.LeagueId = l.Id
	GROUP BY l.Id
	HAVING COUNT(tm.Id) > 0
)


SELECT t1.TeamName AS [Home Team],
	tm.HomeGoals AS [Home Goals],
	t2.TeamName AS [Away Team], 
	tm.AwayGoals AS [Away Goals],
	l.LeagueName AS [League Name]
	FROM Leagues l
	
	JOIN TeamMatches tm
		ON l.Id = tm.LeagueId
	JOIN Teams t1
		ON t1.Id = tm.HomeTeamId
	JOIN Teams t2
		ON t2.Id = tm.AwayTeamId
WHERE tm.MatchDate > '2015-04-10'
ORDER BY l.LeagueName, tm.HomeGoals DESC, tm.AwayGoals DESC

GO

--Problem 15

ALTER FUNCTION fn_TeamJSON()
	RETURNS NVARCHAR(MAX)
BEGIN
	
	DECLARE @json NVARCHAR(MAX) = '{"teams":['

	DECLARE teamCursor CURSOR FOR
	SELECT Id, TeamName
	FROM Teams
	WHERE CountryCode = 'BG'
	ORDER BY TeamName

	OPEN teamCursor
	DECLARE @TeamName NVARCHAR(50)
	DECLARE @TeamId INT
	FETCH NEXT FROM teamCursor INTO @TeamId ,@TeamName
	WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @json = @json + '{"name":"'+ @TeamName + '","matches":['

			DECLARE matchesCursor CURSOR FOR
			SELECT t1.TeamName, HomeGoals, t2.TeamName, AwayGoals, MatchDate FROM TeamMatches tm
				JOIN Teams t1
					ON t1.Id = tm.HomeTeamId
				JOIN Teams t2
					ON t2.Id = tm.AwayTeamId
			WHERE tm.HomeTeamId = @TeamId OR tm.AwayTeamId = @TeamId 
			ORDER BY MatchDate DESC

			OPEN matchesCursor
			DECLARE @HomeTeam NVARCHAR(50)
			DECLARE @HomeGoals INT
			DECLARE @AwayTeam NVARCHAR(50)
			DECLARE @AwayGoals INT
			DECLARE @MatchDate DATETIME

			FETCH NEXT FROM matchesCursor INTO @HomeTeam, @HomeGoals, @AwayTeam, @AwayGoals, @MatchDate
			WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @json = @json + '{"'+ @homeTeam +'":'+ CONVERT(NVARCHAR(20), @HomeGoals) +',"'+ @AwayTeam +'":'+ CONVERT(NVARCHAR(50), @AwayGoals) +',"date":'+ CONVERT(NVARCHAR(50), @MatchDate, 103) +'}'
					FETCH NEXT FROM matchesCursor INTO @HomeTeam, @HomeGoals, @AwayTeam, @AwayGoals, @MatchDate
					IF @@FETCH_STATUS = 0
						BEGIN
							SET @json = @json + ','
						END
				END
			CLOSE matchesCursor
			DEALLOCATE matchesCursor

			
			SET @json = @json + ']}' 
			FETCH NEXT FROM teamCursor INTO @TeamId ,@TeamName
			IF @@FETCH_STATUS = 0
				BEGIN
					SET @json = @json + ','
				END
		END
	
	CLOSE teamCursor
	DEALLOCATE teamCursor

	SET @json = @json + ']}'
	RETURN @json
END
GO

SELECT dbo.fn_TeamJSON()


