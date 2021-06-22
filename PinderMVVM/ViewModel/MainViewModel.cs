using System;
using System.Collections.Generic;
using System.Text;
using CommandHelper;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace PinderMVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _scanCommand;


        public ObservableCollection<string> DirectoryCollection { get; set; }

        private void notifyPropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        public MainViewModel()
        {
            this.DirectoryCollection = new ObservableCollection<string>();
            ScanDirectory();
        }
      
        public ICommand ScanCommand
        {
            get
            {
                return _scanCommand = new RelayCommand(c => ScanDirectory());
            }
        }

        private void ScanDirectory()
        {
            // get logical drives and clear the obCollection 
            string[] drives = Directory.GetLogicalDrives();
            DirectoryCollection.Clear();

            // go through drives and add them to the obCollection
            foreach (string directory in drives)
            {
                if (!DirectoryCollection.Contains(directory))
                {
                    this.DirectoryCollection.Add(directory);
                }
            }
        }

    }
}
