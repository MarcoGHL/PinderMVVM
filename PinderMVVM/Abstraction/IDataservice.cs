using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction
{
    public interface IDataservice
    {
        //Connection to the PostSQL-Database
        NpgsqlConnection DbConnection();
        //Give back every item in the current database
        List<string> GetAllFromDatabase();
        //Clear the table bevor the new items arrive
        void ClearDatabase();
        //Post the Pathlist into the table
        void CreateIntoDatabase(string text, string path);
    }
}
