using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QulixSystemsTestProject.Models.Repositories
{
    public class WorkerRepository:IRepository<Worker>
    {
        private string connectionstring;
        private CompanyRepository rep;
       
        public WorkerRepository()
        {
            connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            rep = new CompanyRepository();
        }

        public void Add(Worker _worker)
        {
            string sqlExpression = "INSERT INTO Worker (Name,MiddleName,SurName,Date,Position,CompanyId) VALUES (@Name,@MiddleName,@SurName,@Date,@Position,@CompanyId)";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@Name", _worker.Name);
                cmd.Parameters.AddWithValue("@MiddleName", _worker.MiddleName);
                cmd.Parameters.AddWithValue("@SurName", _worker.SurName);
                cmd.Parameters.AddWithValue("@Date", _worker.Date.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Position", _worker.Position);
                cmd.Parameters.AddWithValue("@CompanyId", _worker.CompanyID);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Worker> List()
        {
            List<Worker> query = new List<Worker>();
            string sqlExpression = "SELECT * FROM Worker";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string middleName = reader.GetString(2);
                        string surName = reader.GetString(3);
                        DateTime date = reader.GetDateTime(4);
                        string  pos= reader.GetString(5);
                        int compId = reader.GetInt32(6);
                        string CompTitle = rep.SearchTitle(compId);
                        query.Add(new Worker { ID = id, Name=name,MiddleName=middleName,SurName=surName,
                            Date=date.Date,Position=pos,CompanyID=compId,CompanyTitle=CompTitle});

                    }
                }
                reader.Close();

            }
            return query;
        }

        public void Delete(int id)
        {
            string sqlExpression = "DELETE FROM Worker WHERE Id=@id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Worker Find(int id)
        {
            Worker tmp = new Worker();
            string sqlExpression = "SELECT* FROM Worker WHERE Id=@id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int _id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string middleName = reader.GetString(2);
                        string surName = reader.GetString(3);
                        DateTime date = reader.GetDateTime(4);
                        string pos = reader.GetString(5);
                        int compId = reader.GetInt32(6);
                        tmp = new Worker { ID = _id, Name = name, MiddleName = middleName, SurName = surName,
                            Date = date.Date, Position = pos, CompanyID = compId };
                    }
                }
                reader.Close();
            }
            return tmp;
        }

        public void Update(Worker _worker)
        {
            string sqlExpression = "UPDATE Worker SET Name=@Name,MiddleName=@MiddleName,SurName=@SurName,Date=@Date,Position=@Position,CompanyId=@CompanyId WHERE Id=@Id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@Id", _worker.ID);
                cmd.Parameters.AddWithValue("@Name", _worker.Name);
                cmd.Parameters.AddWithValue("@MiddleName", _worker.MiddleName);
                cmd.Parameters.AddWithValue("@SurName", _worker.SurName);
                cmd.Parameters.AddWithValue("@Date", _worker.Date.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Position", _worker.Position);
                cmd.Parameters.AddWithValue("@CompanyId", _worker.CompanyID);
                cmd.ExecuteNonQuery();
            }
        }
       
    }
}