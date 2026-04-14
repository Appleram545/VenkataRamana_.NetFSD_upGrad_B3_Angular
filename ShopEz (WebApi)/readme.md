 Simple E-commerce Web API built using ASP.NET Core, 
Entity Framework Core, and JWT Authentication.

* Tech Stack
1.ASP.NET Core Web API
2.Entity Framework Core
3.SQL Server
4.JWT Authentication
5.Swagger & PostMan


Steps to run the project

1. Configure Database // I used docker for sqlserver you can change servewr name in 
 Appsettings.json

-----

2. Run Migrations
dotnet ef migrations add InitialCreate
dotnet ef database update

-----

3. Run Application
  dotnet run

4. Open PostMan

    http://localhost:5135/api/controller


   1.  Authentication Flow

     1. Register User
      POST /api/auth/register

      {
        "name": "Ram", 
      "email": "ram3@mail.com",
       "password": "12345" 
       }

     2.  Login   
        POST /api/auth/login

        {
        "email": "ram3@mail.com",
       "password": "12345" 
       }

      We get Response, to login copy the " JWT TOKEN ".

     3. use TOKEN
        Authorization → Bearer TOKEN 

     4. Admin Login
         {
             "email": "admin@mail.com", 
             "password": "admin123" 
        }

    2. Product APIs 

       1. Get All Products
            GET /api/product

        2. Get Product by ID
            GET /api/product/{id}  

        3. Add Product (Admin Only can ADD)
            POST /api/product
        
        4. Update Product (Admin Only Can Update)
            PUT /api/product/{id}

        5. Delete Product (Admin Only Can Delete ) 
            DELETE /api/product/{id}   


    3. Order APIs

        1. Place Order
            POST /api/order

        2. Get All Orders
            GET /api/order  

        3. Get Order by ID
            GET /api/order/{id}      


    User Can - View products, place orders
    Admin Can - Add, update, delete products

   4. Common Erros you might get 

        1. 400 Bad Request
            Wrong JSON format

        2. 401 Unauthorized
            Token missing or invalid

        3. 403 Forbidden
            User trying admin-only API

        4. 404 Not Found
            ID doesn't Exist            