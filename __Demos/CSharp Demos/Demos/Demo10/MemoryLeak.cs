using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo10
{
    public static class MemoryLeak
    {
        public static WeakReference Reference { get; private set; }

        public static void CheckObject(object ObjToCheck)
        {
            MemoryLeak.Reference = new WeakReference(ObjToCheck,false);
        }

        public static void IsItDead()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            if (MemoryLeak.Reference.IsAlive)
                Console.WriteLine("Still here "+GC.GetGeneration(Reference).ToString()+" "+GC.GetTotalMemory(false).ToString()); //Debug.WriteLine("Still here");
            else
                Console.WriteLine("I 'm dead");  //Debug.WriteLine("I 'm dead");
        }
    }
}
