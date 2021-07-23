using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace PinderMVVM.ViewModel
{
    public class drives
    {
        public void getDrives()
        {
            string[] drives = Directory.GetLogicalDrives();
            foreach(string item in drives)
            {
                
            }
        }
    }
}
