--Problem 1
select c.Name from Characters c
ORDER BY c.Name

go

--Problem 2

select top 50 g.Name as Game, cast(g.Start as DATE) as Start from Games g
WHERE year(g.Start) between '2011' and '2012'
order by Start, g.Name

go

--Problem 3

select u.Username, 
substring(u.Email, CHARINDEX('@', u.Email) + 1, LEN(u.Email)) as [Email Provider]
from Users u
order by [Email Provider], u.Username

go

--Problem 4

select u.Username, u.IpAddress as [IP Address] from Users u
where u.IpAddress like '___.1%.%.___'
order by u.Username

go

--Problem 5
select 
	g.Name as Game, 
	CASE when datepart(hh, g.Start) >= 0 and datepart(hh, g.Start) < 12 
			THEN 'Morning'
		 when datepart(hh, g.Start) >= 12 and datepart(hh, g.Start) < 18 
			then 'Afternoon'
		when datepart(hh, g.Start) >= 18 and datepart(hh, g.Start) < 24 
			then 'Evening'
		end as [Part of the Day],
	
	case when g.Duration <= 3
			then 'Extra Short'
		when g.Duration >= 4 and g.Duration <= 6
			then 'Short'
		when g.Duration > 6
			then 'Long'
		when g.Duration IS NULL
			then 'Extra Long'
		end as Duration
	
	from Games g
order by Game, Duration, [Part of the day]

go


--problem 6 emailprovider asc

select substring(u.Email, CHARINDEX('@', u.Email) + 1, LEN(u.Email)) as [Email Provider],
 Count(u.Username) as [Number Of Users] 

	from Users u
	
	GROUP BY substring(u.Email, CHARINDEX('@', u.Email) + 1, LEN(u.Email))
	order by count(u.id) DESC, [Email Provider]

--Probme 7 

select g.Name as Game, gt.Name as [Game Type], u.Username, ug.Level, ug.Cash, c.Name as Character from Games g
	join GameTypes gt
		on gt.Id = g.GameTypeId
	join UsersGames ug
		on ug.GameId = g.Id
	join Users u
		on u.Id = ug.UserId
	join Characters c
		on c.Id = ug.CharacterId
order by ug.Level desc, u.Username, g.Name

go

--Problem 8

select u.Username, g.Name as Game, count(i.Id) as [Items Count], sum(i.Price) as [Items Price] from Users u
	join UsersGames ug
		on ug.UserId = u.Id
	join Games g
		on ug.GameId = g.Id
	join UserGameItems ugt
		on ug.Id = ugt.UserGameId
	join Items i
		on i.Id = ugt.ItemId
GROUP BY u.Username, g.Name
having count(i.Id) >= 10
order by [Items Count] desc, [Items Price] desc, u.Username

--Problem 9

go

--problem 10

select i.Name, i.Price, i.MinLevel, s.Strength, s.Defence, s.Speed, s.Luck, s.Mind from Items i
	INNER join [Statistics] s	
		on s.Id = i.StatisticId
	where s.Speed > (select avg(Speed) from [Statistics]) AND 
	s.Luck > (select avg(Luck) from [Statistics]) AND 
	s.Mind > (select avg(Mind) from [Statistics])
order by i.Name

--Problem 11

select i.Name as Item, i.Price, i.MinLevel, gt.Name as [Forbidden Game Type] from Items i
	left join GameTypeForbiddenItems gtf
		on gtf.ItemId = i.Id
	left join GameTypes gt
		on gt.Id = gtf.GameTypeId
order by [Forbidden Game Type] desc, Item asc

go

--problem 12

select u.Username, sum(ug.Cash) from Users u
	join UsersGames ug
		on ug.UserId = u.id
	join Games g
		on g.Id = ug.GameId
	group by u.Username
	having u.Username like 'Alex'

begin tran
update table UsersGames
(
	SET Cash = sum(ug.Cash) 
	from Users u
	join UsersGames ug
		on ug.UserId = u.id
	join Games g
		on g.Id = ug.GameId
	where u.Username like 'Alex'
)

go