-- DAY 16


Create DATABASe Day16;

use day16;

CREATE TABLE stores
(
store_id INT PRIMARY KEY,
store_name VARCHAR(50)
);

CREATE TABLE products
(
product_id INT PRIMARY KEY,
product_name VARCHAR(50),
list_price DECIMAL(10,2)
);

CREATE TABLE orders
(
order_id INT PRIMARY KEY,
order_date DATE,
store_id INT,
FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items
(
order_item_id INT PRIMARY KEY,
order_id INT,
product_id INT,
quantity INT,
list_price DECIMAL(10,2),
discount DECIMAL(4,2),
FOREIGN KEY (order_id) REFERENCES orders(order_id),
FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO stores VALUES
(1,'Hyderabad Store'),
(2,'Delhi Store'),
(3,'Mumbai Store');


INSERT INTO products VALUES
(101,'Laptop',60000),
(102,'Mobile',25000),
(103,'Headphones',3000),
(104,'Keyboard',1500),
(105,'Mouse',800);


INSERT INTO orders VALUES
(1,'2024-01-10',1),
(2,'2024-02-05',2),
(3,'2024-03-12',1),
(4,'2024-03-18',3);


INSERT INTO order_items VALUES
(1,1,101,2,60000,0.10),
(2,1,103,3,3000,0.05),
(3,2,102,1,25000,0.08),
(4,3,101,1,60000,0.15),
(5,3,105,4,800,0),
(6,4,104,5,1500,0.05),
(7,4,103,2,3000,0.10);




-- 1.  Create a stored procedure to generate total sales amount per store.


Create procedure Total_sales_perStore
as
begin
select
s.store_name,sum(ISNULL(oi.quantity * oi.list_price *(1-oi.discount),0) )as total_sales
from stores s
LEFT join orders o  
on s.store_id=o.store_id
LEFT join order_items oi
on o.order_id = oi.order_id
Group by s.store_name
order by total_sales DESC
END

exec Total_sales_perStore;

-- 2.  Create a Stored Procedure to Retrieve Orders by Date Range

Create procedure date_range
@start_date DATE,
@end_date DATE
as 
begin
select
order_id,order_date,store_id
from orders
where order_date BETWEEN @start_date and @end_date
END

EXEC date_range '2024-01-01','2024-02-28';

-- 3. Create a Scalar Function to Calculate Total Price After Discount

Create Function total_price
(
    @price DECIMAL(10,2),
    @quantity int,
    @discount DECIMAL(4,2)


)
returns DECIMAL(10,2)
as 
begin
return ISNULL(@price,0)*ISNULL(@quantity,0)*(1-ISNULL(@discount,0))
END

select product_id,
dbo.total_price(list_price,quantity,discount) as final_price
from order_items          


-- 4. Create a Table-Valued Function to Return Top 5 Selling Products


CREATE FUNCTION fn_Top5SellingProducts()

RETURNS TABLE

AS

RETURN
(

SELECT TOP 5
p.product_name,
SUM(oi.quantity) AS total_quantity

FROM products p
JOIN order_items oi
ON p.product_id = oi.product_id

GROUP BY p.product_name
ORDER BY total_quantity DESC

)

SELECT * FROM dbo.fn_Top5SellingProducts()



-- problem 2 


create DATABASE day16_2;
use day16_2;


CREATE TABLE products
(
product_id INT PRIMARY KEY,
product_name VARCHAR(50)
)

CREATE TABLE stocks
(
product_id INT PRIMARY KEY,
quantity INT
)

CREATE TABLE orders
(
order_id INT PRIMARY KEY,
order_status INT,
shipped_date DATE
)

CREATE TABLE order_items
(
order_item_id INT PRIMARY KEY,
order_id INT,
product_id INT,
quantity INT
)


INSERT INTO products VALUES
(101,'Laptop'),
(102,'Mobile'),
(103,'Headphones')


INSERT INTO stocks VALUES
(101,10),
(102,20),
(103,15)


INSERT INTO orders VALUES
(1,1,NULL),
(2,1,NULL)


-- 1.  Create an AFTER UPDATE trigger on orders. at leat one row matcjes the condition


ALTER TRIGGER order_status
ON orders
AFTER UPDATE
AS
BEGIN

IF EXISTS
(
SELECT 1    
FROM inserted
WHERE order_status = 4
AND shipped_date IS NULL
)

BEGIN
ROLLBACK TRANSACTION;
THROW 50001, 'Shipped date must not be NULL when order is completed.',1
END

END


-- check data 

-- unvalid 

UPDATE orders
SET order_status = 4,
shipped_date=NULL
WHERE order_id = 1;


-- valid data 

UPDATE orders
SET order_status = 4,
shipped_date = '2024-04-10'
WHERE order_id = 1;

select * from orders;


-- problem 3 

create DATABASE day16_3;
use day16_3;

CREATE TABLE stores
(
store_id INT PRIMARY KEY,
store_name VARCHAR(50)
);

CREATE TABLE orders
(
order_id INT PRIMARY KEY,
store_id INT,
order_status INT,
order_date DATE
);

CREATE TABLE order_items
(
order_item_id INT PRIMARY KEY,
order_id INT,
product_id INT,
quantity INT,
list_price DECIMAL(10,2),
discount DECIMAL(4,2)
);


INSERT INTO stores VALUES
(1,'Hyderabad Store'),
(2,'Delhi Store'),
(3,'Mumbai Store');

INSERT INTO orders VALUES
(101,1,4,'2024-04-01'),
(102,1,4,'2024-04-05'),
(103,2,4,'2024-04-07'),
(104,3,1,'2024-04-10');

INSERT INTO order_items VALUES
(1,101,1,2,50000,0.10),
(2,101,2,1,20000,0.05),
(3,102,1,1,50000,0.15),
(4,103,3,3,3000,0.05),
(5,104,2,2,20000,0.10);

CREATE TABLE #OrderRevenue
(
order_id INT,
store_id INT,
revenue DECIMAL(12,2)
);


-- //   Cursor-Based Revenue Calculation

DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @revenue DECIMAL(12,2)

BEGIN TRY

BEGIN TRANSACTION

DECLARE order_cursor CURSOR FOR

SELECT order_id, store_id
FROM orders
WHERE order_status = 4

OPEN order_cursor

FETCH NEXT FROM order_cursor INTO @order_id, @store_id

WHILE @@FETCH_STATUS = 0
BEGIN

SELECT @revenue =
SUM(quantity * list_price * (1 - discount))
FROM order_items
WHERE order_id = @order_id


INSERT INTO #OrderRevenue
VALUES(@order_id,@store_id,@revenue)

FETCH NEXT FROM order_cursor INTO @order_id, @store_id

END

CLOSE order_cursor
DEALLOCATE order_cursor

COMMIT TRANSACTION

END TRY


BEGIN CATCH

ROLLBACK TRANSACTION
PRINT ERROR_MESSAGE()

END CATCH


SELECT
s.store_name,
SUM(r.revenue) AS total_revenue
FROM #OrderRevenue r
JOIN stores s
ON r.store_id = s.store_id
GROUP BY s.store_name
ORDER BY total_revenue DESC;