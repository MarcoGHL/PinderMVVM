using Abstraction;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Dataservice
{
    public class ConnectionDB : IDataservice
    {
        //Connection to Database 
        public NpgsqlConnection DbConnection()
        {
            var connString = "Host = localhost; Username = postgres; Password = password; Database = Reader";
            var connection = new NpgsqlConnection(connString);
            connection.Open();
            return connection;
        }

        //*Abstraction*
        public void ClearDatabase()
        {
            ConnectionDB Db = new ConnectionDB();
            var command = new NpgsqlCommand("TRUNCATE TABLE reader", Db.DbConnection());

            command.ExecuteNonQuery();
        }


        //*Abstraction*
        public void CreateIntoDatabase(string text, string path)
        {
            ConnectionDB Db = new ConnectionDB();
            var command = new NpgsqlCommand($"INSERT INTO reader(filevalue, path) VALUES ( '{ text }' , '{ path }');", Db.DbConnection());

            command.ExecuteNonQuery();
        }


        //*Abstraction*
        public List<string> GetAllFromDatabase()
        {
            ConnectionDB Db = new ConnectionDB();
            var command = new NpgsqlCommand("SELECT * FROM reader", Db.DbConnection());
            List<string> file_path = new List<string>();
            var result = command.ExecuteReader();

            while (result.Read())
            {
                file_path.Add(result.GetString(2));
            }
            return file_path;
        }
    }
}
