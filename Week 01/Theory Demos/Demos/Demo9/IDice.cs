using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo9
{
    public interface IDice
    {
        void SetId(string Id);
        void Throw(int Number);
        bool GetResult();
    }
}
