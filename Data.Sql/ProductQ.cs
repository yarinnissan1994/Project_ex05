using Project_ex05.model;
using Project_ex05.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Sql
{
    public class ProductQ
    {
        public Dictionary<string, Product> ReadFromDb(SqlDataReader reader)

        {
            Dictionary<string, Product> ProductsList = new Dictionary<string, Product>();

            while (reader.Read())
            {
                Product product = new Product();
                product.ProductID = reader.GetInt32(0);
                product.ProductName = reader.GetString(1);
                product.SupplierID = reader.GetInt32(2);
                product.CategoryID = reader.GetInt32(3);
                product.QuantityPerUnit = reader.GetString(4);
                product.UnitPrice = reader.GetDecimal(5);
                product.UnitsInStock = reader.GetInt16(6);
                product.UnitsOnOrder = reader.GetInt16(7);
                product.ReorderLevel = reader.GetInt16(8);
                product.Discontinued = reader.GetBoolean(9);


                //Cheking If Hashtable contains the key
                if (ProductsList.ContainsKey(product.ProductName))
                {
                    //key already exists
                }
                else
                {
                    //Filling a hashtable
                    ProductsList.Add(product.ProductName, product);
                }

            }
            return ProductsList;
        }
        public Dictionary<string, Product> SendSqlQueryToReadFromDB()
        {
            string SqlQuery = "select * from Products_Copy";
            Dictionary<string, Product> retDict = (Dictionary<string, Product>)Project_ex05.DAL.sqlQuery.StartReadFromDB(SqlQuery, ReadFromDb);
            return retDict;
        }
        public void UpdateProductInDB(Product product)
        {
            string updateQuery = "update Products_Copy set ProductName = '" + product.ProductName+"', QuantityPerUnit = '"+product.QuantityPerUnit+"', UnitPrice = "+product.UnitPrice.ToString()+", UnitsInStock = "+product.UnitsInStock.ToString()+" where ProductID = "+product.ProductID.ToString();
            Project_ex05.DAL.sqlQuery.WriteToDB(updateQuery);
        }
        public void DeleteAProduct(string productID)
        {
            string deleteQuery = "delete from Products_Copy where ProductID = " + productID;
            Project_ex05.DAL.sqlQuery.WriteToDB(deleteQuery);
        }
    }
}
