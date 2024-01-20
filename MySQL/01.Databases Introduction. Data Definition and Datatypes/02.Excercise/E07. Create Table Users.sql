CREATE TABLE users(
id INT PRIMARY KEY AUTO_INCREMENT,
username NVARCHAR(30) UNIQUE NOT NULL,
password NVARCHAR(26) NOT NULL,
profile_picture BLOB,
last_login_time TIMESTAMP,
is_deleted BOOL
);

INSERT INTO users(username, password, profile_picture, last_login_time, is_deleted) VALUES
("heroku", "12@3", "pic", "2024-01-20", false),
("sda", "12@3", "pic", "2024-01-20", true),
("gfd", "12@3", "pic", "2024-01-20", false),
("324", "12@3", "pic", "2024-01-20", true),
("acbhyj", "12@3", null, "2024-01-20", false);