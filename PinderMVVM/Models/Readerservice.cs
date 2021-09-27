using Abstraction;
using System;
using System.Collections.Generic;
using System.IO;
using Visualis.Extractor;

namespace Models
{
    public class Readerservice : IReaderservice
    {
        public static TextExtractorD extractor = new TextExtractorD();
        public static Dictionary<DirectoryInfo, long> dir = new Dictionary<DirectoryInfo, long>();
        public string _comingpath;
        public string _content;
        public string Comingpath
        {
            get
            {
                return _comingpath;
            }
            set
            {
                _comingpath = value;
            }
        }

        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;

            }
        }

        //*Abstraction*
        public List<string> GetData(string Path)
        {
            List<string> pathlist = new List<string>();
            Comingpath = Path;

            try
            {
                DirectoryInfo sd = new DirectoryInfo(Comingpath);
                foreach (FileInfo fileinfo in sd.GetFiles())
                {
                    string path = (string.Format("{0}", fileinfo.FullName));
                    string text = extractor.Extract(fileinfo.FullName);
                    Content = text;
                    pathlist.Add(path + ";" + text);
                    Console.WriteLine(path + " " + text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Console.WriteLine("Fertig");
            return pathlist;
        }
    }
}
