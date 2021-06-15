using System;
using System.Collections.Generic;
using System.Text;
//using CommandHelper;
using System.ComponentModel;
using System.IO;

namespace PinderMVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public List<string> Laufwerke { get; set; }

        private void notifyPropertyChanged(string propname)
        {
            //Test
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        public MainViewModel()
        {
            string[] drives = Directory.GetLogicalDrives();
            Laufwerke = new List<string>(drives);
            Laufwerke.Add(Properties.Settings.Default.CurrPath);
        }

    }
}
