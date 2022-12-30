using Project_ex05.DAL;
using Project_ex05.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Sql
{
    public class MessageQ
    {
        public void ConvertUserMessageToSqlQuery(UserMessage data)
        {
            string sqlQuery = "insert into ContactUs values('" + data.name + "','" + data.message + "','" + data.phone + "','" + data.email + "',getdate())";
            Project_ex05.DAL.sqlQuery.WriteToDB(sqlQuery);
        }
    }
}
