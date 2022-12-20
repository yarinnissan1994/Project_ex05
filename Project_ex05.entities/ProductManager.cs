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

        // get data from sql server and insert it into hashtable
        public object ReadFromDb(SqlDataReader reader)
        {
            //Clear Hashtable Before Inserting Information From Sql Server
            ProductsList.Clear();
            object retDic = null;
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

            retDic = ProductsList;
            return retDic;
        }
        //Function that helps connect between UI and DAL and return Hashtable
        public object SendSqlQueryToReadFromDB(string SqlQuery)
        {

            object retDic = null;
            retDic = DAL.sqlQuery.StartReadFromDB(SqlQuery, ReadFromDb);
            return retDic;
        }
    }
}
