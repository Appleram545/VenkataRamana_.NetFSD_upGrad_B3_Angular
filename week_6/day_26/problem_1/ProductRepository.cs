using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using problem_1.Model;

namespace problem_1.Data
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository()
        {
            _connectionString = "Server=localhost,1433;Database=ProductD;User Id=sa;Password=StrongPass@123;TrustServerCertificate=True;";
        }

        // INSERT
        public void InsertProduct(Product product)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_InsertProduct", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@Category", product.Category);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Stock", product.Stock);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public Product GetProductById(int productId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetProductById", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductId", productId);

            conn.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Product
                {
                    ProductId = (int)reader["ProductId"],
                    ProductName = reader["ProductName"].ToString(),
                    Category = reader["Category"].ToString(),
                    Price = (decimal)reader["Price"],
                    Stock = (int)reader["Stock"]
                };
            }

            return null; // Product not found
        }

        // GET ALL
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllProducts", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    ProductId = (int)reader["ProductId"],
                    ProductName = reader["ProductName"].ToString(),
                    Category = reader["Category"].ToString(),
                    Price = (decimal)reader["Price"],
                    Stock = (int)reader["Stock"]
                });
            }

            return products;
        }

        // UPDATE
        public void UpdateProduct(Product product)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateProduct", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@Category", product.Category);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Stock", product.Stock);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void DeleteProduct(int productId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteProduct", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductId", productId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}