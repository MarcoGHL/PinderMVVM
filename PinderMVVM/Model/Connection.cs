using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Npgsql;

namespace PinderMVVM.Model
{
    public class Connection
    {
        public void Con()
        {
            try
            {
                var cs = "Host=localhost;Username=postgres;Password=Password;Database=PinderMVVM";

                var conn = new NpgsqlConnection(cs);
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
        }
        
    }
}