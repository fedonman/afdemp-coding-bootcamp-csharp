using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        public struct Connection
        {
            public string url;
            public int port;

            public void Add()
            {
                url = "hello";
            }
        }

        static void Main(string[] args)
        {
            Connection c;
            c.url = "github.com";
            c.port = 88;
        }
    }
}
