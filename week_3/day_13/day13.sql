

CREATE DATABASE Upgrad;

use Upgrad;



-- problem 1 ---
-- Retrieve customer first name, last name, order_id, order_date, and order_status.
-- 2. Display only orders with status Pending (1) or Completed (4).
-- 3. Sort the results by order_date in descending order.


CREATE TABLE customers
(
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100)
);

INSERT INTO customers
    (first_name, last_name, email)
VALUES
    ('Jai', 'Babu', 'babu@gmail.com'),
    ('Mahesh', 'Babu', 'mahesh@gmail.com'),
    ('Raju', 'King', 'raju@gmail.com'),
    ('Priya', 'Will', 'priya@gmail.com');



CREATE TABLE orders
(
    order_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT,
    order_date DATE,
    order_status INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);


INSERT INTO orders
    (customer_id, order_date, order_status)
VALUES
    (1, '2026-03-01', 1),
    (2, '2026-03-02', 4),
    (3, '2026-02-28', 2),
    (1, '2026-02-27', 4),
    (4, '2026-03-03', 1);


-- QUEREY for 1 

SELECT
    c.first_name, c.last_name, o.order_id, o.order_date, o.order_status
from customers c
    inner join orders o
    on c.customer_id = o.customer_id
where order_status in(1,4)
ORDER by order_date DESC;


--------------------------------------------------------

-- problem 2 ---- 

-- 1. Display product_name, brand_name, category_name, model_year, and list_price.
-- 2. Filter products with list_price greater than 500.
-- 3. Sort results by list_price in ascending order.

CREATE TABLE categories
(
    category_id INT PRIMARY KEY IDENTITY(1,1),
    category_name VARCHAR(50)
);


INSERT INTO categories
    (category_name)
VALUES
    ('Interceptor '),
    ('Continental'),
    ('Himalayan');


CREATE TABLE brands
(
    brand_id INT PRIMARY KEY IDENTITY(1,1),
    brand_name VARCHAR(50)
);

INSERT INTO brands
    (brand_name)
VALUES
    ('Royal Enfield'),
    ('Jawa'),
    ('Yezedi');


CREATE TABLE products
(
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

INSERT INTO products
    (product_name, brand_id, category_id, model_year, list_price)
VALUES
    ('Triumph', 1, 1, 2023, 650),
    ('Royal Enfield', 2, 1, 2022, 480),
    ('Yezedi', 3, 2, 2023, 900),
    ('Jawa', 1, 2, 2022, 1200),
    ('Yamaha', 2, 3, 2024, 2100);




-- QUEREY for 2 

SELECT
    p.product_name, b.brand_name, c.category_name, p.model_year, p.list_price
from products p
    inner join brands b
    on p.brand_id=b.brand_id
    inner join categories c
    on p.category_id=c.category_id
where p.list_price >500
ORDER by p.list_price ASC;

--------------------------------------------------------


-- problem 3

-- 1. Display store_name and total sales amount.
-- 2. Calculate total sales using (quantity * list_price * (1 - discount)).
-- 3. Include only completed orders (order_status = 4).
-- 4. Group results by store_name.


CREATE TABLE stores
(
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100)
);

INSERT INTO stores
    (store_name)
VALUES
    ('Madhapur Store'),
    ('Kukatpally Store'),
    ('Banjara Hills Store');

CREATE TABLE orderss
(
    order_id INT PRIMARY KEY IDENTITY(1,1),
    store_id INT,
    order_status INT,

    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

INSERT INTO orderss
    (store_id, order_status)
VALUES
    (1, 4),
    (1, 4),
    (2, 2),
    (2, 4),
    (3, 4);

CREATE TABLE order_items
(
    item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),

    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);

INSERT INTO order_items
    (order_id, quantity, list_price, discount)
VALUES
    (1, 2, 500, 0.10),
    (1, 1, 800, 0.05),
    (2, 3, 600, 0.10),
    (3, 1, 700, 0.00),
    (4, 2, 900, 0.15),
    (5, 1, 1200, 0.10);


-- QUEREY for 3
select
    s.store_name , SUM(oi.quantity * oi.list_price *(1-oi.discount)) as Total_sales
from stores s
    INNER JOIN orderss O
    on s.store_id = o.store_id
    INNER JOIN order_items oi
    on o.order_id = oi.order_id
where o.order_status = 4
GROUP BY s.store_name
ORDER by Total_sales ;
 


-- problem - 4
-- . Display product_name, store_name, available stock quantity, and total quantity sold.
-- 2. Include products even if they have not been sold (use appropriate join).
-- 3. Group results by product_name and store_name.
-- 4. Sort results by product_name.



CREATE TABLE products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100)
);


INSERT INTO products (product_name)
VALUES
('Laptop'),
('Mobile'),
('Tablet'),
('Smart Watch');


CREATE TABLE stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100)
);

INSERT INTO stores (store_name)
VALUES
('Hyderabad Store'),
('Delhi Store'),
('Mumbai Store');



CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT,

    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);


INSERT INTO stocks (store_id, product_id, quantity)
VALUES
(1,1,50),
(1,2,40),
(2,1,30),
(2,3,20),
(3,2,25),
(3,4,15);



CREATE TABLE order_items (
    item_id INT PRIMARY KEY IDENTITY(1,1),
    product_id INT,
    store_id INT,
    quantity INT,

    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);


INSERT INTO order_items (product_id, store_id, quantity)
VALUES
(1,1,5),
(1,1,3),
(2,1,4),
(3,2,2),
(2,3,6);


-- QUEREY for 4      

SELECT 
p.product_name,
s.store_name,
st.quantity AS available_stock,
SUM(oi.quantity) AS total_quantity_sold
FROM stocks st
INNER JOIN products p
ON st.product_id = p.product_id
INNER JOIN stores s
ON st.store_id = s.store_id
LEFT JOIN order_items oi
ON st.product_id = oi.product_id
AND st.store_id = oi.store_id
GROUP BY p.product_name, s.store_name, st.quantity
ORDER BY p.product_name;