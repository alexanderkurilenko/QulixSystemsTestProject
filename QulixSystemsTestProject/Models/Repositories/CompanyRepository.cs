using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QulixSystemsTestProject.Models.Repositories
{
    public class CompanyRepository:IRepository<Company>
    {
        private string connectionstring;
       
        public CompanyRepository()
        {
            connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Add(Company _company)
        {
            string sqlExpression = "INSERT INTO Company (Title,Size,Organization) VALUES (@Title,@Size,@Organization)";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@Title", _company.Title);
                cmd.Parameters.AddWithValue("@Size", _company.Size);
                cmd.Parameters.AddWithValue("@Organization", _company.Form);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Company> List()
        {
            List<Company> query = new List<Company>();
            string sqlExpression = "SELECT * FROM Company";
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
                        string title = reader.GetString(1);
                        int size = reader.GetInt32(2);
                        string form = reader.GetString(3);

                        query.Add(new Company { ID = id, Title = title, Size = size, Form = form });

                    }
                }
                reader.Close();

            }
            return query;
        }
        
        public void Delete(int id)
        {
            string sqlExpression = "DELETE FROM Company WHERE Id=@id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlExpression,connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Company Find(int id)
        {
            Company tmp=new Company();
            string sqlExpression = "SELECT* FROM Company WHERE Id=@id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@id",id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int _id = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        int size = reader.GetInt32(2);
                        string form = reader.GetString(3);
                        tmp = new Company { ID = _id, Title = title, Size = size, Form = form };
                    }
                }
                reader.Close();
            }
            return tmp;
        }

        public void Update(Company _company)
        {
            string sqlExpression = "UPDATE Company SET Title=@title,Size=@size,Organization=@organization WHERE Id=@id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@id", _company.ID);
                cmd.Parameters.AddWithValue("@title", _company.Title);
                cmd.Parameters.AddWithValue("@size", _company.Size);
                cmd.Parameters.AddWithValue("@organization", _company.Form);
                cmd.ExecuteNonQuery();
            }
        }

        public string SearchTitle(int id)
        {
            string result=null;
            string sqlExpression = "SELECT Title FROM Company WHERE Id=@id";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string title = reader.GetString(0);
                        result = title;
                    }
                }
                reader.Close();
                
            }
            return result;
        }

    }
}