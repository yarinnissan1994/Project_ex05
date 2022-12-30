using Data.Sql;
using Project_ex05.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ex05.entities
{
    public class MessageManegaer
    {
        public void SendUserMessageToDB(UserMessage data)
        {
            MessageQ messageQ = new MessageQ();
            messageQ.ConvertUserMessageToSqlQuery(data);
        }
    }
}
