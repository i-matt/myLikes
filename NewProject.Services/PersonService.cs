using NewProject.Models.Domain;
using NewProject.Models.Requests;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace NewProject.Services
{
    public class PersonService
    {
        private string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; 

        public int Insert(PersonAddRequest model)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string cmdText = "Person_Insert";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Id";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;

                    cmd.Parameters.Add(param);
                    cmd.Parameters.AddWithValue("@AccountId", model.AccountId);
                    cmd.Parameters.AddWithValue("@Username", model.Username);
                    cmd.Parameters.AddWithValue("@PhotoId", model.PhotoId);
                    cmd.Parameters.AddWithValue("@Gender", model.Gender);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    result = (int)cmd.Parameters["@Id"].Value;
                    conn.Close();
                }
            }
            return result;
        }

        public List<Person> GetAll()
        {
            List<Person> result = new List<Person>();

            using(SqlConnection conn = new SqlConnection(connStr)){
                string cmdText = "Person_SelectAll";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while(reader.Read())
                    {
                        Person model = new Person();
                        int index = 0;
                        model.AccountId = reader.GetInt32(index++);
                        model.Username = reader.GetString(index++);
                        if(!reader.IsDBNull(index))
                        {
                         model.PhotoId = reader.GetInt32(index++);  
                        }
                        else
                        {
                            index++;
                        }
                        model.Gender = reader.GetBoolean(index++);
                        model.CreatedDate = reader.GetDateTime(index++);
                        model.ModifiedDate = reader.GetDateTime(index++);
                        model.ModifiedBy = reader.GetString(index);
                        result.Add(model);
                    }
                    conn.Close();
                }
            }
            return result;
        }
    }
}
