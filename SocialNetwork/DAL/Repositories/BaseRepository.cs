using Dapper;
using System.Data;
using System.Data.SQLite;

namespace SocialNetwork.DAL.Repositories;

public class BaseRepository
{
    protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
    {
        using(var connection = CreateConnection())
        {
            connection.Open();
            return connection.QueryFirstOrDefault<T>(sql, parameters);
        }
    }

    protected int Execute(string sql, object parameters = null)
    {
        using(var connection = CreateConnection())
        {
            connection.Open();
            return connection.Execute(sql, parameters);
        }
    }

    protected List<T> Query<T>(string sql, object parameters = null)
    {
        using(var connection = CreateConnection())
        {
            connection.Open();
            return connection.Query<T>(sql, parameters).ToList();
        }
    }

    private IDbConnection CreateConnection()
    {
        return new SQLiteConnection("Data Source = DAL/DB/social_network_db.db; Version = 3");
    }
}