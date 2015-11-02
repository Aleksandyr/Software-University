--Problem 1
select p.PeakName  from Peaks p
	order by p.PeakName

go

--Problem 2
select top 30 CountryName, [Population] from Countries c
	where c.ContinentCode LIKE 'EU'
	order by [Population] desc, CountryName

go

--Problem 3

select 
	c.CountryName, 
	c.CountryCode,
	cast(case when c.CurrencyCode = 'EUR' then 'Euro' else 'Not Euro' end as nvarchar) as [Currency]
from 
	Countries c
order by
	c.CountryName

go

--Problem 4

select CountryName as [Country Name], IsoCode as [ISO Code]
from 
	Countries
where 
	CountryName LIKE '%a%a%a%'
order by 
	isoCode

go

--Problem 5

select p.PeakName, m.MountainRange as [Mountain], p.Elevation from Peaks p
	join
		Mountains m
	ON
		p.MountainId = m.Id
	order by
		p.Elevation desc, PeakName

go

--Problem 6

select p.PeakName, m.MountainRange as [Mountain], c.CountryName, cnt.ContinentName from Peaks p
	join 
		Mountains m 
	on 
		m.Id = p.MountainId
	join 
		MountainsCountries mc
	on 
		mc.MountainId = m.Id
	join
		Countries c 
	on
		c.CountryCode = mc.CountryCode
	join
		Continents cnt
	on
		cnt.ContinentCode = c.ContinentCode
	order by
		p.PeakName, c.CountryName

go

--Problem 7

select 
	r.RiverName as [River], 
	(select COUNT(DISTINCT cr.CountryCode)
		from CountriesRivers cr
		where RiverId = r.Id) as [Countries Count]
from
	Rivers r
where (select COUNT(DISTINCT criv.CountryCode) 
			from CountriesRivers criv
			where RiverId = r.Id ) >= 3
order by r.RiverName

--Problem 8

select 
	MAX(p.Elevation) as [MaxElevation], 
	MIN(p.Elevation) as [MinElevation], 
	AVG(p.Elevation) as [AverageElevation]
from 
	Peaks p

go

--Problem 9
select 
	c.CountryName, 
	cnt.ContinentName, 
	COUNT(r.RiverName) as [RiversCount], 
	isnull(SUM(r.Length), 0) as [TotalLength] 
	from 
		Countries c
	
	left join 
		Continents cnt
	on 
		c.ContinentCode = cnt.ContinentCode
	left join 
		CountriesRivers cntriv
	on 
		cntriv.CountryCode = c.CountryCode
	left join 
		Rivers r
	on 
		r.Id = cntriv.RiverId
group by c.CountryName, cnt.ContinentName
order by COUNT(r.RiverName) desc, SUM(r.Length) desc, c.CountryName 

GO

--Problem 10

SELECT 
	cur.CurrencyCode, 
	cur.Description AS Currency,
	COUNT(c.CountryName) AS NumberOfCountries
FROM 
	Currencies cur
LEFT JOIN 
	Countries c
ON	
	c.CurrencyCode = cur.CurrencyCode
GROUP BY
	cur.CurrencyCode, cur.Description
ORDER BY
	COUNT(c.CurrencyCode) DESC, cur.Description 

GO

--Problem 11
SELECT 
	c.ContinentName, 
	SUM(cnt.AreaInSqKm) AS CountriesArea,  
	SUM(CONVERT(Numeric, cnt.Population)) AS CountriesPopulation
FROM 
	Continents c
JOIN 
	Countries cnt
ON
	c.ContinentCode = cnt.ContinentCode
GROUP BY c.ContinentName
ORDER BY CountriesPopulation DESC

GO

--Problem 12
SELECT 
	c.CountryName, 
	MAX(p.Elevation) AS HighestPeakElevation, 
	MAX(r.Length) AS LongestRiverLength
FROM 
	Countries c
	
	LEFT JOIN CountriesRivers cr
		ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers r
		ON r.Id = cr.RiverId
	LEFT JOIN MountainsCountries mc
		ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains m
		ON m.Id = mc.MountainId
	LEFT JOIN Peaks p
		ON p.MountainId = m.Id

 GROUP BY c.CountryName
 ORDER BY MAX(p.Elevation) DESC, MAX(r.Length) DESC, c.CountryName 

 GO

 --Problem 13

SELECT 
	p.PeakName, 
	r.RiverName, 
	SUBSTRING(LOWER(p.PeakName), 0, LEN(p.PeakName)) + '' + LOWER(r.RiverName) AS Mix
FROM 
	Peaks p, 
	Rivers r
WHERE 
	SUBSTRING(p.PeakName, LEN(p.PeakName), 1) = SUBSTRING(r.RiverName, 1, 1)
ORDER BY Mix

GO

--Problem 14 TO DO...

SELECT c.CountryName, 
		CAST(CASE WHEN p.PeakName IS NULL THEN '(no highest peak)' END AS NVARCHAR) AS [Highest Peak Name] ,
		CAST(CASE WHEN MAX(p.Elevation) IS NULL THEN 0 END AS INT) AS [Highest Peak Elevation] ,
		CAST(CASE WHEN m.MountainRange IS NULL THEN '(no mountain)' END AS NVARCHAR) AS [Mountain]
	FROM Countries c
	LEFT JOIN MountainsCountries mc
		ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains m
		ON mc.MountainId = m.Id
	LEFT JOIN Peaks p
		ON m.Id = p.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange
ORDER BY c.CountryName, p.PeakName

GO

--Problem 15

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

ALTER TABLE Countries
	ADD IsDeleted INT NOT NULL DEFAULT 0

BEGIN TRAN
UPDATE Countries
SET IsDeleted = 1 
WHERE CountryCode IN (SELECT c.CountryCode FROM Countries c
	JOIN CountriesRivers cr
		ON c.CountryCode = cr.CountryCode
	JOIN Rivers r
		ON cr.RiverId = r.Id
	GROUP BY c.CountryCode
	HAVING COUNT(r.Id) > 3)
COMMIT

SELECT m.Name as Monastery, c.CountryName as Country FROM Countries c
	JOIN Monasteries m
		ON m.CountryCode = c.CountryCode
	WHERE c.IsDeleted != 1
ORDER BY m.Name

GO

--Problem 16

BEGIN TRAN
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'
COMMIT

INSERT INTO Monasteries (Name, CountryCode) VALUES
('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania'))


INSERT INTO Monasteries (Name, CountryCode) VALUES
('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Maynmar'))

SELECT cnt.ContinentName, c.CountryName, COUNT(m.Id) as MonasteriesCount
	FROM Countries c
		LEFT JOIN Continents cnt
			ON c.ContinentCode = cnt.ContinentCode
		LEFT JOIN Monasteries m
			ON m.CountryCode = c.CountryCode
	WHERE c.IsDeleted != 1
GROUP BY cnt.ContinentName, c.CountryName
ORDER BY COUNT(m.Id) DESC, c.CountryName

GO

--Problem 17

CREATE FUNCTION fn_MountainsPeaksJSON()
	RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @json NVARCHAR(MAX) = '{"mountains":['

	DECLARE montainsCursor CURSOR FOR
	SELECT Id, MountainRange FROM Mountains

	OPEN montainsCursor
	DECLARE @mountainName NVARCHAR(MAX)
	DECLARE @mountainId INT
	FETCH NEXT FROM montainsCursor INTO @mountainId, @mountainName
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @json = @json + '{"name":"' + @mountainName + '","peaks":['

		DECLARE peaksCursor CURSOR FOR
		SELECT PeakName, Elevation FROM Peaks
		WHERE MountainId = @mountainId

		OPEN peaksCursor
		DECLARE @peakName NVARCHAR(MAX)
		DECLARE @elevation INT
		FETCH NEXT FROM peaksCursor INTO @peakName, @elevation
		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @json = @json + '{"name":"' + @peakName + '",' +
				'"elevation":' + CONVERT(NVARCHAR(MAX), @elevation) + '}'
			FETCH NEXT FROM peaksCursor INTO @peakName, @elevation
			IF @@FETCH_STATUS = 0
				SET @json = @json + ','
		END
		CLOSE peaksCursor
		DEALLOCATE peaksCursor
		SET @json = @json + ']}'

		FETCH NEXT FROM montainsCursor INTO @mountainId, @mountainName
		IF @@FETCH_STATUS = 0
			SET @json = @json + ','
	END
	CLOSE montainsCursor
	DEALLOCATE montainsCursor

	SET @json = @json + ']}'
	RETURN @json
END
GO

SELECT dbo.fn_MountainsPeaksJSON()