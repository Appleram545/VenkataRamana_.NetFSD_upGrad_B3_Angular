day 15

CREATE DATABASE EcommDb;


USE EcommDb;


-- problem 1 ---

CREATE TABLE categories
(
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);

CREATE TABLE brands
(
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50)
);

CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE customers
(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    city VARCHAR(50),
    phone VARCHAR(20),
    email VARCHAR(100)
);

CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50),
    phone VARCHAR(20)
);


INSERT INTO categories
VALUES
    (1, 'Mountain Bikes'),
    (2, 'Road Bikes'),
    (3, 'Electric Bikes'),
    (4, 'Children Bikes'),
    (5, 'Hybrid Bikes');

INSERT INTO brands
VALUES
    (1, 'Trek'),
    (2, 'Giant'),
    (3, 'Specialized'),
    (4, 'Cannondale'),
    (5, 'Scott');

INSERT INTO products
VALUES
    (1, 'Trek Marlin 7', 1, 1, 2023, 850.00),
    (2, 'Giant Escape 3', 2, 5, 2022, 650.00),
    (3, 'Specialized Allez', 3, 2, 2023, 1200.00),
    (4, 'Cannondale Trail 5', 4, 1, 2022, 900.00),
    (5, 'Scott Voltage eRide', 5, 3, 2023, 2200.00);

INSERT INTO customers
VALUES
    (1, 'Rahul', 'Sharma', 'Hyderabad', '9876543210', 'rahul@gmail.com'),
    (2, 'Anita', 'Reddy', 'Chennai', '9876543211', 'anita@gmail.com'),
    (3, 'Kiran', 'Kumar', 'Hyderabad', '9876543212', 'kiran@gmail.com'),
    (4, 'Priya', 'Singh', 'Delhi', '9876543213', 'priya@gmail.com'),
    (5, 'Arjun', 'Varma', 'Bangalore', '9876543214', 'arjun@gmail.com');

INSERT INTO stores
VALUES
    (1, 'Bike World', 'Hyderabad', '9000000001'),
    (2, 'Speed Cycles', 'Chennai', '9000000002'),
    (3, 'Urban Bikes', 'Delhi', '9000000003'),
    (4, 'Cycle Hub', 'Bangalore', '9000000004'),
    (5, 'Pro Riders', 'Mumbai', '9000000005');


-- 1. Retrieve All Products with Brand and Category

SELECT
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
    JOIN brands b ON p.brand_id = b.brand_id
    JOIN categories c ON p.category_id = c.category_id;


-- 2. Retrieve Customers from a Specific City

SELECT *
FROM customers
WHERE city = 'Hyderabad';


-- 3. Total Number of Products in Each Category

SELECT
    c.category_name,
    COUNT(p.product_id) AS total_products
FROM categories c
    LEFT JOIN products p
    ON c.category_id = p.category_id
GROUP BY c.category_name;




-- 2 problem 

-- 1.  Create a view that shows product name, brand name, category name, model year and list price.

CREATE VIEW vw_ProductDetails
AS
    SELECT
        p.product_name,
        b.brand_name,
        c.category_name,
        p.model_year,
        p.list_price
    FROM products p
        JOIN brands b
        ON p.brand_id = b.brand_id
        JOIN categories c
        ON p.category_id = c.category_id;

SELECT *
FROM vw_ProductDetails;



-- 2. View: Order Details

CREATE TABLE staffs
(
    staff_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100),
    phone VARCHAR(20),
    store_id INT,
    manager_id INT
);

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status INT,
    order_date DATE,
    store_id INT,
    staff_id INT,

    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (staff_id) REFERENCES staffs(staff_id)
);

INSERT INTO staffs
VALUES
    (1, 'Raj', 'Kumar', 'raj@gmail.com', '9001111111', 1, NULL),
    (2, 'Sita', 'Reddy', 'sita@gmail.com', '9002222222', 2, 1),
    (3, 'Amit', 'Sharma', 'amit@gmail.com', '9003333333', 3, 1),
    (4, 'Neha', 'Verma', 'neha@gmail.com', '9004444444', 4, 2),
    (5, 'Vikram', 'Singh', 'vikram@gmail.com', '9005555555', 5, 3);

INSERT INTO orders
VALUES
    (1, 1, 1, '2024-01-10', 1, 1),
    (2, 2, 1, '2024-01-12', 2, 2),
    (3, 3, 1, '2024-01-15', 3, 3),
    (4, 4, 1, '2024-01-18', 4, 4),
    (5, 5, 1, '2024-01-20', 5, 5);


CREATE VIEW vw_OrderDetails
AS
    SELECT
        o.order_id,
        c.first_name + ' ' + c.last_name AS customer_name,
        s.store_name,
        st.first_name + ' ' + st.last_name AS staff_name,
        o.order_date
    FROM orders o
        JOIN customers c
        ON o.customer_id = c.customer_id
        JOIN stores s
        ON o.store_id = s.store_id
        JOIN staffs st
        ON o.staff_id = st.staff_id;

SELECT *
FROM vw_OrderDetails;


-- 3. Create Indexes on Foreign Key Columns


CREATE INDEX idx_products_brand
ON products(brand_id);

CREATE INDEX idx_products_category
ON products(category_id);

CREATE INDEX idx_orders_customer
ON orders(customer_id);

CREATE INDEX idx_orders_store
ON orders(store_id);

CREATE INDEX idx_orders_staff
ON orders(staff_id);

