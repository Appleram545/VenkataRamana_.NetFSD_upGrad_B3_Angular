
-- problem 1

CREATE DATABASE DAY14;


use DAY14;

CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    model_year INT,
    list_price DECIMAL(10,2),
    category_id INT
);


INSERT INTO products
    (product_id, product_name, model_year, list_price, category_id)
VALUES
    (1, 'Yamaha', 2017, 1200, 1),
    (2, 'Triumph', 2018, 1500, 1),
    (3, 'Himalayan', 2017, 1000, 2),
    (4, 'Continental GT', 2019, 2000, 2),
    (5, 'Yezedi', 2018, 800, 3),
    (6, 'Aprilla', 2019, 1100, 3),
    (7, 'Ninja', 2020, 2500, 4),
    (8, 'Harley DavaidSon', 2021, 3000, 4);


-- QUERIES 

-- 1. Retrieve product details (product_name, model_year, list_price)

SELECT product_name, model_year, list_price
FROM products;


-- 2. Compare each product’s price with the average price of products in the same category (Nested Query)

SELECT product_name, model_year, list_price
FROM products p1
where list_price >(select AVG(list_price)
from products p2
where p2.product_id = p1.category_id);


-- 3. Display only products whose price is greater than the category average


SELECT product_name, model_year, list_price,
    list_price -(select avg(list_price)
    from products p2
    where p2.category_id=p1.category_id)as DIF
from products p1;


-- 4.  Concatenate product name and model year

select CONCAT(product_name,'-',model_year)as product_details
from products;



-- 2. problem

CREATE TABLE details
(
    client_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

CREATE TABLE sales_orders
(
    order_id INT PRIMARY KEY,
    client_id INT,
    order_value DECIMAL(10,2)
);


INSERT INTO details
VALUES
    (1, 'Ravi', 'Kumar'),
    (2, 'Anita', 'Sharma'),
    (3, 'Rahul', 'Verma'),
    (4, 'Priya', 'Reddy'),
    (5, 'Arjun', 'Patel'),
    (6, 'Sneha', 'Iyer');

INSERT INTO sales_orders
VALUES
    (101, 1, 3000),
    (102, 1, 2500),
    (103, 2, 6000),
    (104, 2, 5000),
    (105, 3, 2000),
    (106, 4, 12000);


-- 1.  Nested Query to Calculate Total Order Value Per Customer

SELECT client_id,
    (SELECT SUM(order_value)
    FROM sales_orders s
    WHERE s.client_id = d.client_id) AS total_value
FROM details d;


-- 2. Classify Customers Using CASE

SELECT client_id,
    total_value,
    CASE
           WHEN total_value > 10000 THEN 'Premium'
           WHEN total_value BETWEEN 5000 AND 10000 THEN 'Regular'
           WHEN total_value < 5000 THEN 'Basic'
       END AS customer_type
FROM
    (
    SELECT client_id, SUM(order_value) AS total_value
    FROM sales_orders
    GROUP BY client_id
) t;


-- 3. Use UNION to Show Customers With Orders and Without Orders

    SELECT client_id
    FROM sales_orders

UNION

    SELECT client_id
    FROM details
    WHERE client_id NOT IN
(
    SELECT client_id
    FROM sales_orders
);


-- 4. Display Full Name Using String Concatenation

sELECT
    CONCAT(d.first_name,' ',d.last_name) AS full_name
from details d;

-- 5 . Handle NULL Cases 

SELECT d.client_id,
    COALESCE(SUM(s.order_value),0) AS total_order_value  
FROM details d
    LEFT JOIN sales_orders s
    ON d.client_id = s.client_id
GROUP BY d.client_id;





-- 3. problem  

CREATE TABLE stores_info (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);

CREATE TABLE products_info (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    list_price DECIMAL(10,2)
);


CREATE TABLE orders_info (
    order_id INT PRIMARY KEY,
    store_id INT
);

CREATE TABLE order_items_info (
    order_id INT,
    product_id INT,
    quantity INT,
    discount DECIMAL(10,2)
);

CREATE TABLE stock_info (
    store_id INT,
    product_id INT,
    quantity INT
); 

INSERT INTO stores_info VALUES
(1,'Hyderabad Store'),
(2,'Delhi Store'),
(3,'Mumbai Store');

INSERT INTO products_info VALUES
(101,'Mountain Bike',1200),
(102,'Road Bike',1000),
(103,'Hybrid Bike',800),
(104,'Electric Bike',2500);

INSERT INTO orders_info VALUES
(201,1),
(202,1),
(203,2),
(204,3);

INSERT INTO order_items_info VALUES
(201,101,2,100),
(201,102,1,50),
(202,103,3,0),
(203,101,1,0),
(204,104,2,200);


INSERT INTO stock_info VALUES
(1,101,5),
(1,102,0),
(1,103,10),
(2,101,0),
(3,104,4);


-- 1 . Identify Products Sold in Each Store Nested Query

SELECT o.store_id, oi.product_id
FROM orders_info o
JOIN order_items_info oi
ON o.order_id = oi.order_id;

-- 2. Compareing Sold Products With Current Stock

SELECT product_id
FROM order_items_info

INTERSECT

SELECT product_id
FROM stock_info;

------

SELECT product_id
FROM order_items_info

EXCEPT

SELECT product_id
FROM stock_info
WHERE quantity > 0;


-- 3. Display store_name, product_name, total quantity sold

SELECT s.store_name,
       p.product_name,
       SUM(oi.quantity) AS total_quantity_sold
FROM order_items_info oi
JOIN orders_info o
ON oi.order_id = o.order_id
JOIN stores_info s
ON o.store_id = s.store_id
JOIN products_info p
ON oi.product_id = p.product_id
GROUP BY s.store_name, p.product_name;

-- 4. Calculate Total Revenue per Product

SELECT p.product_name,
       SUM((oi.quantity * p.list_price) - oi.discount) AS total_revenue
FROM order_items_info oi
JOIN products_info p
ON oi.product_id = p.product_id
GROUP BY p.product_name;

-- 5. Update Stock Quantity to 0

UPDATE stock_info
SET quantity = 0
WHERE product_id = 101;

select * from stock_info;


-- problem 4 

CREATE TABLE customers_data (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

CREATE TABLE orders_data (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    order_status INT
);

CREATE TABLE archived_orders (
    order_id INT,
    customer_id INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    order_status INT
);

INSERT INTO customers_data VALUES
(1,'Ravi','Kumar'),
(2,'Anita','Sharma'),
(3,'Rahul','Verma'),
(4,'Priya','Reddy');

INSERT INTO orders_data VALUES
(101,1,'2023-01-10','2023-01-20','2023-01-18',2),
(102,1,'2022-02-15','2022-02-25','2022-02-28',3),
(103,2,'2023-03-12','2023-03-20','2023-03-19',2),
(104,3,'2021-04-10','2021-04-20','2021-04-25',3),
(105,4,'2023-06-01','2023-06-10','2023-06-08',2);

-- 1. Insert Archived Records (INSERT INTO SELECT)
INSERT INTO archived_orders
SELECT *
FROM orders_data
WHERE order_status = 3;

-- 2. Delete Rejected Orders Older Than 1 Year
DELETE FROM orders_data
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());


-- 3 .Customers Whose All Orders Are Completed (Nested Query)

SELECT customer_id
FROM customers_data
WHERE customer_id NOT IN
(
    SELECT customer_id
    FROM orders_data
    WHERE order_status <> 2
);

-- 4.Order Processing Delay

SELECT order_id,
       DATEDIFF(DAY, order_date, shipped_date) AS processing_delay
FROM orders_data;

-- 5. Mark Orders as Delayed or On Time

SELECT order_id,
       order_date,
       required_date,
       shipped_date,
       CASE
           WHEN shipped_date > required_date THEN 'Delayed'
           ELSE 'On Time'
       END AS delivery_status
FROM orders_data;