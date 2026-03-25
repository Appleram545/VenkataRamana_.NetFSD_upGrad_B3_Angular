
create DATABASE ProductD;

use ProductD;
GO

CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100),
    Category NVARCHAR(100),
    Price DECIMAL(10,2),
    Stock INT
);


CREATE PROCEDURE sp_InsertProduct
    @ProductName NVARCHAR(100),
    @Category NVARCHAR(100),
    @Price DECIMAL(10,2),
    @Stock INT
AS
BEGIN
    INSERT INTO Products (ProductName, Category, Price, Stock)
    VALUES (@ProductName, @Category, @Price, @Stock);
END


CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT * FROM Products;
END


CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName NVARCHAR(100),
    @Category NVARCHAR(100),
    @Price DECIMAL(10,2),
    @Stock INT
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName,
        Category = @Category,
        Price = @Price,
        Stock = @Stock
    WHERE ProductId = @ProductId;
END

CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products WHERE ProductId = @ProductId;
END


CREATE PROCEDURE sp_GetProductById
    @ProductId INT
AS
BEGIN
    SELECT * FROM Products WHERE ProductId = @ProductId;
END
GO
