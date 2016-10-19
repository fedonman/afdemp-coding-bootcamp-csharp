using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    class Program
    {
        static void Main(string[] args)
        {
            Screen screen1 = new Screen(ScreenResolution._1920x1080(), 7);
			Battery battery1 = new Battery(BatteryType.LithiumIon, 8000);
			Device device1 = new Device(
				"Asus", 
				"Zenfone 2", 
				250, 
				new Screen(ScreenResolution._1920x1080(), 7), 
				battery1
				);

			Device device2 = Device.GetKnownModel(KnownModels.iPhone7);
			Console.WriteLine(device2.BasePrice);
			//device2.BasePrice = 100;

			device1.Usage.NewCall(CallType.Incoming);
			Console.WriteLine("Call Started...");
			System.Threading.Thread.Sleep(5000);
			device1.Usage.EndCall();
			Console.WriteLine("Call Ended");
			Console.WriteLine();

			device1.Usage.NewCall(CallType.Outgoing);
			Console.WriteLine("Call Started...");
			System.Threading.Thread.Sleep(10000);
			device1.Usage.EndCall();
			Console.WriteLine("Call Ended");

			Console.WriteLine(device1.Usage);
			Console.ReadKey();
		}  
    }
}
