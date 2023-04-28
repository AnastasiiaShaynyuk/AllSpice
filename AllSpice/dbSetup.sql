-- Active: 1682439245094@@SG-codework-7502-mysql-master.servers.mongodirector.com@3306@codeworks-checkpoint-all-spice
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE recipes(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  title VARCHAR(50) NOT NULL,
  instruction VARCHAR(1000) NOT NULL,
  img VARCHAR(400) NOT NULL,
  category VARCHAR(50) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8mb4 COMMENT '';

ALTER TABLE recipes
ADD COLUMN createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
ADD COLUMN updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP;

INSERT INTO recipes
(title, instruction, img, category, creatorId)
VALUES
('Caprese Salad', 'Slice the cherry tomatoes in half and place them in a large bowl. Sprinkle with a little salt and drizzle with a bit of olive oil. Chiffonade the basil leaves into thin strips by stacking the basil leaves on top of each other, gently rolling it into a log and then slicing thinly into strips. Stir about ¾ of the basil into the tomatoes. Transfer tomatoes to a serving platter.', 'https://plus.unsplash.com/premium_photo-1677619680753-5407b8730d1c?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTl8fGNhcHJlc2UlMjBzYWxhZHxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60', 'Salads', '642db05b8ab8699ccab01f5b');

