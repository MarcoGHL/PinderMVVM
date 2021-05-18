using System;
using System.Collections.Generic;
using System.Text;
using CommandHelper;
using System.ComponentModel;

namespace PinderMVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private void notifyPropertyChanged(string propname)
        {
            //Test
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

    }
}
