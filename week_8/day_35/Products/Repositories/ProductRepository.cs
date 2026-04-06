using Dapper;
using Microsoft.Data.SqlClient;
using Products.Models;

namespace Products.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connStr;
        public ProductRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection");
        }


        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }

        public IEnumerable<Product> GetAll()
        {
            string sqlQuery = "SELECT * FROM Products";
            var db = GetConnection();
            return db.Query<Product>(sqlQuery);

        }

        public Product GetById(int id)
        {
            string sqlQuery = "SELECT * FROM Products WHERE Id=" + id;
            var db = GetConnection();
            return db.QueryFirstOrDefault<Product>(sqlQuery);
        }

        public void Add(Product product)
        {
            string sqlQuery = @"INSERT INTO Products (Name, Price, Category) VALUES (@Name, @Price, @Category)";

            var db = GetConnection();
            db.Execute(sqlQuery, product);
        }

        public void Update(Product product)
        {
            var db=GetConnection();
            string sqlQuery= @"UPDATE products
                                SET Name= @Name,Price=@Price,Category = @Category
                        WHERE Id = @Id";
            db.Execute(sqlQuery, product);
        }
        public void Delete(int id)
        {
            using var db = GetConnection();

            string sqlQuery = "DELETE FROM Products WHERE Id = @Id";

            db.Execute(sqlQuery, new { Id = id });
        }
    }
}