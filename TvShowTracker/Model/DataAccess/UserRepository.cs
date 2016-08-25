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
            builder.InitialCatalog = "lecture";
            builder.DataSource = @"10.70.63.193\SQLEXPRESS";
            builder.IntegratedSecurity = false;
            connectionString = builder.ToString();
        }

        public User FindUserByEmailAndPassword(string name, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
            }            
        }

        public User FindUserByNickAndPassword(string name, string password)
        {
            
        }
    }
}
