USE minions;

ALTER TABLE users
DROP PRIMARY KEY,
ADD PRIMARY KEY (id,username);