using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    static class FileUtilitiy
    {
        public static string ReadFile(string filepath)
        {
            return File.ReadAllText(filepath);
        }

        public static void WriteFile(string filepath, string data)
        {
            File.WriteAllText(filepath, data);
        }
    }
}
