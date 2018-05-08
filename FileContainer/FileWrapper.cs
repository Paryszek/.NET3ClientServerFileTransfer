using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileContainer
{
    [Serializable]
    public class FileWrapper
    {
        public string _fileName { get; private set; }
        public byte[] _file { get; private set; }

        public FileWrapper(string fileName, byte[] file)
        {
            _fileName = fileName;
            _file = file;
        }
    }
}
