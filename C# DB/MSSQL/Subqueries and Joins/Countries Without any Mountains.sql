SELECT
COUNT(c.CountryName) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m
ON m.Id = mc.MountainId
WHERE mc.MountainId IS NULL