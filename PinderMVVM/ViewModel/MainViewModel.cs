using CommandHelper;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System;
using Npgsql;
using System.Threading;
using Models;
using Dataservice;
using System.Collections.Generic;

namespace PinderMVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _scanCommand;
        private ICommand _getFilesCommand;
        private ICommand _getFolderCommand;
        private string _selected;
        public string IsSelected
        {
            get { return _selected; }
            set { _selected = value; notifyPropertyChanged("IsSelected");}
        }

        private string _selectedFolder;
        public string selectedFolder
        {
            get { return _selectedFolder; }
            set { _selectedFolder = value; notifyPropertyChanged("selectedFolder"); }
        }

        //create observable collections to save the directory, folders and files
        public ObservableCollection<string> DirectoryCollection { get; set; }
        public ObservableCollection<string> FolderCollection { get; set; }
        public ObservableCollection<string> FileCollection { get; set; }
        

        private void notifyPropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        public MainViewModel()
        {
            this.DirectoryCollection = new ObservableCollection<string>();
            this.FolderCollection = new ObservableCollection<string>();
            this.FileCollection = new ObservableCollection<string>();
            ScanDirectory();
            StartScanning();
        }
      
        public ICommand ScanCommand
        {
            get
            {
                return _scanCommand = new RelayCommand(c => ScanDirectory());
            }
        }

        public ICommand getFilesCommand
        {
            get
            {
                return _getFilesCommand = new RelayCommand(c => GetFiles());
            }
        }

        public ICommand getFolderCommand
        {
            get
            {
                return _getFolderCommand = new RelayCommand(c => GetFolders());
            }
        }

        // get logical drives 
        private void ScanDirectory()
        {
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

        // get folders of selected directorys
        private void GetFolders()
        {
            FileCollection.Clear();
            FolderCollection.Clear();

            if(IsSelected != null)
            {
                string[] filePaths = Directory.GetDirectories(Convert.ToString(IsSelected));
                foreach (string files in filePaths)
                {
                    if (!FolderCollection.Contains(files))
                    {
                        this.FolderCollection.Add(files);
                    }
                }
            }
            else
            {
                MessageBox.Show("No directory selected, please try again!");
            }
        }

        // get files of the selected folder
        private void GetFiles()
        {
            FileCollection.Clear();

            try
            {
                if (selectedFolder != null)
                {
                    string[] filePaths = Directory.GetFiles(selectedFolder, "*", SearchOption.AllDirectories);
                    foreach (string files in filePaths)
                    {
                        if (!FileCollection.Contains(files))
                        {
                            this.FileCollection.Add(files);
                        }
                    }
                   
                }
                else
                {
                    MessageBox.Show("No folder selected, please try again!");
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Sie haben keine Berechtigung für diesen Ordner! Bitte wenden Sie sich an den Ersteller des Ordners.");
            }
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
