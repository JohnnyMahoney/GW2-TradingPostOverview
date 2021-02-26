using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Models
{
    public class DataAccess
    {
        public static List<Item> LoadDB(string dbFilePath)
        {
            string connectionString = $@"Data Source={dbFilePath};Version=3;";
            using (IDbConnection conn = new SQLiteConnection(connectionString))
            {
                return conn.Query<Item>("select * from \"Items\"").ToList();
            }
        }

        public static void WriteDB(Item item, string dbFilePath)
        {
            string connectionString = $@"Data Source={dbFilePath};Version=3;";
            using (IDbConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Execute("insert into \"Items\" (ID, Name, Icon_byteArray, Icon) values (@ID, @Name, @Icon_byteArray, @Icon)", item);
            }
        }
    }
}