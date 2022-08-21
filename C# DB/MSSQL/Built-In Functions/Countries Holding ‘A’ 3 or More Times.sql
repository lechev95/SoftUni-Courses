SELECT CountryName AS [Country Name], ISOCode as [ISO Code] 
FROM Countries
WHERE LEN(CountryName) - LEN(REPLACE(CountryName, 'a', '')) >= 3
ORDER BY [ISO Code]