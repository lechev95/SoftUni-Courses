SELECT TOP(5)
c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
ON CR.RiverId = R.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName ASC