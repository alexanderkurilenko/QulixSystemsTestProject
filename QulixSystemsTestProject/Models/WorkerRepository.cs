using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QulixSystemsTestProject.Models
{
    public class WorkerRepository:IDisposable
    {
        private string connectionstring;
       
        public WorkerRepository()
        {
            connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        
        public void Add(Worker _worker)
        {
            string sqlExpression = "INSERT INTO Worker (Name,MiddleName,SurName,Date,Position,CompanyID) VALUES ("+_worker.Name+","+
                _worker.MiddleName + "," + _worker.SurName + "," + _worker.Date + ","
                + _worker.Pos.ToString() + ","+_worker.CompanyID+")";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

       
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}