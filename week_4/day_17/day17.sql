day 17::


-- problem .1.  Transactions and Trigger Implementation


CREATE DATABASE day17;
USE day17;


CREATE TABLE Products
(
ProductID INT PRIMARY KEY,
ProductName VARCHAR(100),
StockQty INT,
Price DECIMAL(10,2)
);


CREATE TABLE Orders
(
OrderID INT PRIMARY KEY,
OrderDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Order_Items
(
OrderItemID INT PRIMARY KEY,
OrderID INT,
ProductID INT,
Quantity INT,
FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Products VALUES
(1,'Car Tyre',50,3000),
(2,'Engine Oil',100,800),
(3,'Brake Pad',40,1500);

-- 1. Create Trigger to Reduce Stock

CREATE TRIGGER trg_UpdateStock
ON Order_Items
AFTER INSERT
AS
BEGIN

-- to Check the  stock availability
IF EXISTS
(
SELECT *
FROM Products p
JOIN inserted i
ON p.ProductID = i.ProductID
WHERE p.StockQty < i.Quantity
)

BEGIN
RAISERROR ('Insufficient Stock',16,1)
ROLLBACK TRANSACTION
RETURN
END

-- to Reduce stock
UPDATE p
SET p.StockQty = p.StockQty - i.Quantity
FROM Products p
JOIN inserted i
ON p.ProductID = i.ProductID

END




-- 2.  Transaction to Place Order

BEGIN TRANSACTION

BEGIN TRY

-- Insert order
INSERT INTO Orders(OrderID)
VALUES (101)

-- Insert order items
INSERT INTO Order_Items
VALUES
(1,101,1,5),
(2,101,2,10)

COMMIT TRANSACTION
PRINT 'Order Placed Successfully'

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION
PRINT 'Transaction Rolled Back'

END CATCH



-- 3. Test Insufficient Stock- to rollback if not 

BEGIN TRANSACTION

BEGIN TRY

INSERT INTO Orders(OrderID)
VALUES (102)

-- Quantity greater than stock
INSERT INTO Order_Items
VALUES
(3,102,1,500)

COMMIT TRANSACTION

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION
PRINT 'Stock not available. Order cancelled.'

END CATCH


----

SELECT * FROM Orders;
SELECT * FROM Order_Items;
SELECT * FROM Products;





-- problem 2.  Atomic Order Cancellation with SAVEPOINT


CREATE DATABASE DAY17_2;
use DAY17_2;


CREATE TABLE Products
(
ProductID INT PRIMARY KEY,
ProductName VARCHAR(100),
StockQty INT
);

CREATE TABLE Orders
(
OrderID INT PRIMARY KEY,
OrderDate DATETIME DEFAULT GETDATE(),
OrderStatus INT
);

CREATE TABLE Order_Items
(
OrderItemID INT PRIMARY KEY,
OrderID INT,
ProductID INT,
Quantity INT,

FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Products VALUES
(1,'Car Tyre',40),
(2,'Engine Oil',90),
(3,'Brake Pad',50);

INSERT INTO Orders VALUES
(101,GETDATE(),1),
(102,GETDATE(),1);

INSERT INTO Order_Items VALUES
(1,101,1,5),
(2,101,2,10),
(3,102,3,7);


BEGIN TRANSACTION

BEGIN TRY
SAVE TRANSACTION savepoint

UPDATE P
SET p.StockQty = p.StockQty+oi.Quantity
FROM Products p 
JOIN Order_Items oi 
ON p.ProductID=oi.ProductID
WHERE oi.OrderID=101



UPDATE Orders
SET OrderStatus=3
WHERE OrderID=101

COMMIT TRANSACTION
PRINT 'order sucessfull'
END TRY

BEGIN CATCH
ROLLBACK TRANSACTION savepoint
PRINT 'Roll back to save point'

END CATCH

SELECT * FROM Products;
SELECT * FROM Orders;
SELECT * FROM Order_Items;