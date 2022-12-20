using Project_ex05.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ex05.UI.test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainManager.Instance.ProductM.SendSqlQueryToReadFromDB("select * from Products");
        }
    }
}
