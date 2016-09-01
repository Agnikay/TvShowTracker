using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvShowTracker.Model.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private string connectionString;

        public UserRepository()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.UserID = "lecture";
            builder.Password = "Qwert123";
            builder.InitialCatalog = "TvShowTracker";
            builder.DataSource = @"10.70.63.237\SQLEXPRESS";
            builder.IntegratedSecurity = false;
            connectionString = builder.ToString();
        }

        public User FindUserByLoginAndPassword(string name, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * from [dbo].[User] where (Nick=@Name OR Email=@Name) AND Password=@Pass";
                    SqlParameter nameParameter = new SqlParameter("@Name", System.Data.SqlDbType.NVarChar);
                    SqlParameter passParameter = new SqlParameter("@Pass", System.Data.SqlDbType.NVarChar);
                    nameParameter.Value = name;
                    passParameter.Value = password;
                    command.Parameters.Add(nameParameter);
                    command.Parameters.Add(passParameter);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            throw new UserNotFoundException();
                        }
                        reader.Read();
                        User user = new User();
                        user.Id = reader.GetInt32(0);
                        user.FirstName = reader.GetString(1).Trim();
                        user.FamilyName = reader.GetString(2).Trim();
                        user.LastName = reader.GetString(3).Trim();
                        user.Nick = reader.GetString(4).Trim();
                        user.Email = reader.GetString(5).Trim();
                        return user;
                    }
                }
            }
        }
    }
}
