using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction
{
    public interface IReaderservice
    {
        //Method to get back a list of path included with the extracted text
        List<string> GetData(string Path);
    }
}
