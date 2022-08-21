SELECT TOP(5) WITH TIES
c.CountryName AS Country, ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name], ISNULL(MAX(p.Elevation), 0) AS [Highest Peak Elevation],
ISNULL(m.MountainRange, '(no mountain)') AS [Mountain]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m
ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p
ON p.MountainId = m.Id
GROUP BY c.CountryName, p.PeakName, m.MountainRange
ORDER BY c.CountryName, p.PeakName