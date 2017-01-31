using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleClientWordProcessor
{
    [Serializable]
    public class FileWrapper
    {
       public List<File_s> longfiles;
       public List<File_s> shortfiles;
    }
}
