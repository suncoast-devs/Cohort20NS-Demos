CREATE TABLE "Employees" (
  "Id" SERIAL PRIMARY KEY,
  "FullName" TEXT NOT NULL,
  "Salary" INT,
  "JobPosition" TEXT,
  "PhoneExtension" VARCHAR(4), 
  "IsPartTime" BOOL DEFAULT FALSE
);

INSERT INTO "Employees" ("FullName",  "Salary", "JobPosition", "PhoneExtension", "IsPartTime", "DepartmentId")
VALUES ('Joe Myers', 120000, 'Senior Software Engineer', '', FALSE, 1),
('Brendan Einhorn', 7500000, 'Accountant', '', FALSE, 2),
('Dee Dee McPherson', 75000, 'Grunt', '106', False, 1),
('Suki Gorman', 90000, 'Office Cat', '111', True, 2),  
('Sly Marbo',260000, 'Manager', '100', False, 2),
('Johnny Awesome', 42345, 'Junior Software Engineer', '', FALSE, 1),
('Sally Jones', 500000, 'Jr Accountant', '', FALSE, 2),
('Frank Gorman', 90000, 'Sensei', '321', True, 1),  
('Barry Foo', 234563, 'Programmer II', '120', False, 1),
('Dee Dee McPherson', 1200000000, 'Hero', '777', False, 2),
('Do Dee McDonald', 75000, 'Cook', '106', False, 2),
('Lazy Larry', 275000, '???', '', TRUE, 1);

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

CREATE TABLE "Departments" (
"Id" SERIAL PRIMARY KEY,
"DepartmentName" TEXT,
"Building" TEXT
);

ALTER TABLE "Employees" ADD COLUMN "DepartmentId" INTEGER NULL REFERENCES "Departments" ("Id");

CREATE TABLE "Products" ( 
  "Id" SERIAL PRIMARY KEY, 
  "Price" MONEY,
  "Name" TEXT, 
  "Description" TEXT, 
  "QuantityInStock" INT
  ); 

CREATE TABLE "Orders" (
    "Id" SERIAL PRIMARY KEY,
    "OrderNumber" TEXT,
    "DatePlaced" TIMESTAMP,
    "Email" TEXT
  );

CREATE TABLE "ProductOrders" (
  "OrderQuantity" INT,
  "ProductId" INTEGER REFERENCES "Products" ("Id"),
  "OrderId" INTEGER REFERENCES "Orders" ("Id")
  );

INSERT INTO "Departments" ("DepartmentName", "Building")
VALUES ('Development', 'Main'), ('Marketing', 'North');

INSERT INTO "Employees" ("FullName",  "Salary", "JobPosition", "PhoneExtension", "IsPartTime", "DepartmentId")
VALUES ('Tim Smith', 40000, 'Programmer', '123', FALSE, 1),
('Barbara Ramsey', 80000, 'Manager', '234', FALSE, 1),
('Tom Jones', 32000, 'Admin', '456', TRUE, 2);

INSERT INTO "Products"("Price", "Name", "Description", "QuantityInStock")
VALUES (12.45, 'Widget', 'The Original Widget', 100),
(99.99, 'Flowbee', 'Perfect for haircuts', 3);

INSERT INTO "Orders"("OrderNumber", "DatePlaced", "Email")
VALUES ('X529', '2020-01-01 16:55:00', 'person@example.com');

INSERT INTO "ProductOrders" ("OrderQuantity", "ProductId", "OrderId")
VALUES (3, 1, 1),
       (2, 2, 1);

SELECT *
FROM "Employees"
JOIN "Departments" ON "Employees"."DepartmentId" = "Departments"."Id" 
WHERE "Departments"."Building" = 'North Side';

SELECT *
FROM "Employees"
JOIN "Departments" ON "Employees"."DepartmentId" = "Departments"."Id" 
WHERE "Departments"."Building" = 'East Side';

SELECT *
FROM "Employees"
JOIN "Departments" ON "Employees"."DepartmentId" = "Departments"."Id" 
WHERE "Departments"."Building" = 'Main';

-- SELECT *
-- FROM "Employees"
-- JOIN "Departments" ON "Employees"."DepartmentId" = "Departments"."Id" 
-- WHERE "Departments"."Building" IN ('Main', 'North', 'East Side');

SELECT *
FROM "Orders"
JOIN "ProductOrders" ON "ProductOrders"."OrderId" = "Orders"."Id" 
WHERE "ProductOrders"."ProductId" = 2;

SELECT "OrderQuantity"
FROM "ProductOrders"
JOIN "Products" ON "ProductOrders"."ProductId" = "Products"."Id" 
WHERE "Products"."Name" = 'Flowbee';

SELECT SUM("OrderQuantity"), "Products"."Name"
FROM "ProductOrders"
JOIN "Products" ON "ProductOrders"."ProductId" = "Products"."Id" 
GROUP BY "Products"."Name";