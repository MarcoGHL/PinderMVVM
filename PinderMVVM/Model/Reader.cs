using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Visualis.Extractor;
using iTextSharp.text;

namespace Auslesen
{
    class Reader
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

        public List<string> GetData(string Path, int depth)
        {
            List<string> pathlist = new List<string>();
            pathlist.Add(Path);
            Comingpath = Path;
            try
            {
                foreach (string d in Directory.GetDirectories(Comingpath))
                {
                    GetData(d, depth + 1);
                }

                DirectoryInfo sd = new DirectoryInfo(Comingpath);
                foreach (FileInfo fileinfo in sd.GetFiles())
                {

                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                    Console.WriteLine(string.Format("{0}", fileinfo.FullName));
                    Console.WriteLine(extractor.Extract(fileinfo.FullName));
                    Content = extractor.Extract(fileinfo.FullName);
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return pathlist;
        }

    }

    
}
