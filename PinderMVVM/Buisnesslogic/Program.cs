using Abstraction;
using Dataservice;
using Models;
using System;
using System.Collections.Generic;

namespace Buisnesslogic
{
    class Program : IBuisnesslogic
    {
        static void Main(string[] args)
        {
            StartScanning();
        }

        
        public static void StartScanning()
        {
            Readerservice Reader = new Readerservice();
            ConnectionDB ConnectionDb = new ConnectionDB();

            //Scann the Data from this path
            List<string> Combineditem = Reader.GetData("C:\\Users\\Manu\\Desktop\\Daten");
            ConnectionDb.ClearDatabase();

            //validation to send the item into the right collum
            foreach (var item in Combineditem)
            {
                var itemSplitted = item.Split(';');
                ConnectionDb.CreateIntoDatabase(itemSplitted[1], itemSplitted[0]);
            }
        }

    }
}
