using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo10
{
    // Πρέπει να το τρέξετε σε Release γιατί το Debug mode δεν θα αφήσει το αντικείμενο να
    //"πεθάνει" ποτέ.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GC.GetTotalMemory(true).ToString());
            Dice d = new Dice();
            Dice a = d;
            MemoryLeak.CheckObject(d);
            MemoryLeak.IsItDead();
            var key = Console.ReadKey();

            while (key.KeyChar!='q')
            {
                key=Console.ReadKey();
                if (key.KeyChar == 'a')
                {
                    Debug.WriteLine("Reference a is now dead");
                    a = null;
                }
                if (key.KeyChar == 'd')
                {
                    Debug.WriteLine("Reference d is now dead");
                    d = null;
                }

                // Το παρακάτω μπαίνει για να αποτρέψει το compilation σε Release mode να κάνει optimizations
                // και να μαζέψει το αντικείμενο κατευθείαν μιας και δεν χρησιμοποιείται πουθενά.
                if (d != null)
                    d.Throw(10);

                MemoryLeak.IsItDead();
            }
        }
    }
}
