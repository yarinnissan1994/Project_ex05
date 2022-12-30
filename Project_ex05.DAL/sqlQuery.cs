using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Project_ex05.DAL
{
    public class sqlQuery
    {
        static string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost\\sqlexpress";

        public delegate object SetDataReader_delegate(SqlDataReader reader);
        public static object StartReadFromDB(string SqlQuery, SetDataReader_delegate Ptrfunc)
        {
            object retHash = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        retHash = Ptrfunc(reader);
                    }
                }
            }
            return retHash;
        }
        public static void WriteToDB(string SqlQuery)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
