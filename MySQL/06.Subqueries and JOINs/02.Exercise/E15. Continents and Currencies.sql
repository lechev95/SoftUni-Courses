 USE geography3;

 SELECT continent_code
	  , currency_code
	  , currency_usage
 FROM (
	                SELECT *,
			    DENSE_RANK() 
			         OVER (
			 PARTITION BY continent_code 
	             ORDER BY currency_usage DESC)
		               AS currency_rank
			         FROM (
								     SELECT c.continent_code
									      , co.currency_code
								    , COUNT(co.currency_code) AS currency_usage
								   	   FROM continents AS c
								 LEFT JOIN countries AS co
									    ON c.continent_code = co.continent_code
								  GROUP BY c.continent_code, co.currency_code
					 ) AS currency_usage_query
	 WHERE currency_usage > 1
    ) AS currency_ranking_query
   WHERE currency_rank = 1
ORDER BY continent_code ASC

