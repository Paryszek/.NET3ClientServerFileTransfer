using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileContainer
{
    public class FileSerializer
    {
        private IFormatter formatter;

        public FileSerializer(IFormatter formatter) => this.formatter = formatter;

        public FileSerializer() => formatter = new BinaryFormatter();

        public void WriteToStream(Stream stream, FileWrapper file)
        {
            formatter.Serialize(stream, file);
        }

        public FileWrapper ReadFromStream(Stream stream)
        {
            return (FileWrapper)formatter.Deserialize(stream);
        }
    }
}
