using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exercise3
{
    public sealed class FileUtility
    {
        private static readonly Lazy<FileUtility> lazy = new Lazy<FileUtility>(() => new FileUtility());

        public static FileUtility Instance { get { return lazy.Value; } }

        private FileUtility()
        {
        }

        public string ReadFile(string file)
        {
            if (file == null)
            {
                return null;
            }
            using (StreamReader reader = new StreamReader(file))
            {
                if (reader == null )
                {
                    return null;
                }
                return reader.ReadToEnd();
            }
        }
        
        public bool WriteToFile(string file, string content, bool append = false)
        {
            if (file == null)
            {
                return false;
            }
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                if (writer == null)
                {
                    return false;
                }
                writer.Write(file);
                return true;
            }
        }
    }
}
