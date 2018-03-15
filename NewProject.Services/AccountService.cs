using NewProject.Models.Domain;
using NewProject.Models.Requests;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace NewProject.Services
{
    public class AccountService
    {
        private string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public int Insert(AccountAddRequest model)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string cmdText = "Accounts_Insert";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Id";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;

                    cmd.Parameters.Add(param);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    result = (int)cmd.Parameters["@Id"].Value;
                    conn.Close();
                }
            }
            return result;
        }

        public void Update(AccountUpdateRequest model)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string cmdText = "Accounts_Update";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string cmdText = "Accounts_Delete";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public List<Account> GetAll()
        {
            List<Account> result = new List<Account>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string cmdText = "Accounts_SelectAll";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Account model = new Account();
                        int index = 0;
                        model.Id = reader.GetInt32(index++);
                        model.Email = reader.GetString(index++);
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

        public Account GetById(int id)
        {
            Account model = new Account();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string cmdText = "Accounts_SelectById";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        int index = 0;
                        model.Id = reader.GetInt32(index++);
                        model.Email = reader.GetString(index++);
                        model.CreatedDate = reader.GetDateTime(index++);
                        model.ModifiedDate = reader.GetDateTime(index++);
                        model.ModifiedBy = reader.GetString(index);
                    }
                    conn.Close();
                }
            }
            return model;
        }
    }
}
