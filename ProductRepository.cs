using CarisSneakerCloset.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CarisSneakerCloset
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM sneakers;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM sneakers WHERE SneakersID = @id", new { id = id});
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE SneakersID = @id",
             new { name = product.Name, price = product.Price, id = product.SneakersID });
        }
        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, SNEAKERSID) VALUES (@name, @price, @SneakersID);",
                new { name = productToInsert.Name, price = productToInsert.Price, SneakersID = productToInsert.SneakersID });
        }
        //public IEnumerable<Category> GetCategories()
        //{
        //    return _conn.Query<Category>("SELECT * FROM categories;");
        //}
        //public Product AssignCategory()
        //{
        //    var categoryList = GetCategories();
        //    var product = new Product();
        //    product.Categories = categoryList;
        //    return product;
        //}
        public void DeleteProduct(Product product)
        {
            _conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;", new { id = product.SneakersID });
            _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;", new { id = product.SneakersID });
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.SneakersID });
        }

    }
}
