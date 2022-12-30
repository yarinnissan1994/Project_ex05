using Data.Sql;
using Project_ex05.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ex05.entities
{
    public class ProductManager
    {
        public Dictionary<string, Product> ProductsList = new Dictionary<string, Product>();

        public void CreateProductListFromDB()
        {
            ProductsList.Clear();
            ProductQ productQ = new ProductQ();
            ProductsList = productQ.SendSqlQueryToReadFromDB();
        }

        public void DeleteAProductByProductID(string productID)
        {
            ProductQ productQ = new ProductQ();
            productQ.DeleteAProduct(productID);
        }

        public void UpdateProduct(Product product)
        {
            ProductQ productQ = new ProductQ();
            productQ.UpdateProductInDB(product);
        }

    }
}
