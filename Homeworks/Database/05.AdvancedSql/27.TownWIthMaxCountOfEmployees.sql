SELECT TOP 1 t.Name, COUNT(t.TownID) FROM Employees AS e
	JOIN Addresses AS a
		ON a.AddressID = e.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name, t.TownID
ORDER BY COUNT(t.TownID) desc
