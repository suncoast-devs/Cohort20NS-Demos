CREATE TABLE "Employees" (
  "Id" SERIAL PRIMARY KEY,
  "FullName" TEXT NOT NULL,
  "Salary" INT,
  "JobPosition" TEXT,
  "PhoneExtension" VARCHAR(4), 
  "IsPartTime" BOOL DEFAULT FALSE
);

INSERT INTO "Employees" ("FullName",  "Salary", "JobPosition", "PhoneExtension", "IsPartTime")
VALUES ('Joe Myers', 120000, 'Senior Software Engineer', '', FALSE);

INSERT INTO "Employees" ("FullName",  "Salary", "JobPosition", "PhoneExtension", "IsPartTime")
VALUES ('Brendan Einhorn', 7500000, 'Accountant', '', FALSE);

INSERT INTO "Employees" ( "FullName", "Salary", "JobPosition", "PhoneExtension", "IsPartTime")
VALUES ( 'Dee Dee McPherson', 75000, 'Grunt', '106', False);

INSERT INTO "Employees" ( "FullName", "Salary", "JobPosition", "PhoneExtension", "IsPartTime")
VALUES ( 'Suki Gorman', 90000, 'Office Cat', '111', True);  

INSERT INTO "Employees" ( "FullName", "Salary", "JobPosition", "PhoneExtension", "IsPartTime")
VALUES ( 'Sly Marbo',260000, 'Manager', '100', False);

INSERT INTO "Employees" ("FullName",  "Salary", "JobPosition", "PhoneExtension", "IsPartTime")
VALUES ('Johnny Awesome', 42345, 'Junior Software Engineer', '', FALSE);

INSERT INTO "Employees" ("FullName",  "Salary", "JobPosition", "PhoneExtension", "IsPartTime")
VALUES ('Sally Jones', 500000, 'Jr Accountant', '', FALSE);

INSERT INTO "Employees" ( "FullName", "Salary", "JobPosition", "PhoneExtension", "IsPartTime")
VALUES ( 'Frank Gorman', 90000, 'Sensei', '321', True);  

INSERT INTO "Employees" ( "FullName", "Salary", "JobPosition", "PhoneExtension", "IsPartTime")
VALUES ( 'Barry Foo', 234563, 'Programmer II', '120', False);

INSERT INTO "Employees" ( "FullName", "Salary", "JobPosition", "PhoneExtension", "IsPartTime")
VALUES ( 'Dee Dee McPherson', 1200000000, 'Hero', '777', False);

INSERT INTO "Employees" ( "FullName", "Salary", "JobPosition", "PhoneExtension", "IsPartTime")
VALUES ( 'Do Dee McDonald', 75000, 'Cook', '106', False);

INSERT INTO "Employees" ( "FullName", "Salary", "JobPosition", "PhoneExtension", "IsPartTime")
VALUES ( 'Lazy Larry', 275000, '???', '', TRUE);

SELECT * FROM "Employees";

--  Id |     FullName      |   Salary   |       JobPosition        | PhoneExtension | IsPartTime 
-- ----+-------------------+------------+--------------------------+----------------+------------
--   1 | Joe Myers         |     120000 | Senior Software Engineer |                | f
--   2 | Brendan Einhorn   |    7500000 | Accountant               |                | f
--   3 | Dee Dee McPherson |      75000 | Grunt                    | 106            | f
--   4 | Suki Gorman       |      90000 | Office Cat               | 111            | t
--   5 | Sly Marbo         |     260000 | Manager                  | 100            | f
--   6 | Johnny Awesome    |      42345 | Junior Software Engineer |                | f
--   7 | Sally Jones       |     500000 | Jr Accountant            |                | f
--   8 | Frank Gorman      |      90000 | Sensei                   | 321            | t
--   9 | Barry Foo         |     234563 | Programmer II            | 120            | f
--  10 | Dee Dee McPherson | 1200000000 | Hero                     | 777            | f
--  12 | Do Dee McDonald   |      75000 | Cook                     | 106            | f
--  13 | Lazy Larry        |     275000 | ???                      |                | t

-- Select only the full names and phone extensions for only full-time employees.

SELECT "FullName", "PhoneExtension" FROM "Employees" WHERE "IsPartTime" = FALSE;

--      FullName      | PhoneExtension 
-- -------------------+----------------
--  Joe Myers         | 
--  Brendan Einhorn   | 
--  Dee Dee McPherson | 106
--  Sly Marbo         | 100
--  Johnny Awesome    | 
--  Sally Jones       | 
--  Barry Foo         | 120
--  Dee Dee McPherson | 777

-- Insert a new part-time employee, as a software developer, with a salary of 450. Make up values for the other columns.

INSERT INTO "Employees" ("FullName",  "Salary", "JobPosition", "PhoneExtension", "IsPartTime")
VALUES ('Billy Gorman', 450, 'Software Developer', '420', TRUE);

-- Update all employees that are cooks to have a salary of 500.

UPDATE "Employees" SET "Salary" = 500 WHERE "JobPosition" = 'Cook';

--  Id |    FullName     | Salary | JobPosition | PhoneExtension | IsPartTime 
-- ----+-----------------+--------+-------------+----------------+------------
--  12 | Do Dee McDonald |    500 | Cook        | 106            | f

-- Delete all employees that have the full name of "Lazy Larry".

DELETE FROM "Employees" WHERE "FullName" = 'Lazy Larry';

-- DELETE 1

-- Add a column to the table: ParkingSpot as textual information that can store up to 10 characters.

ALTER TABLE "Employees" ADD COLUMN "ParkingSpot" VARCHAR(10);