using System;
using Mobile.DeviceInfo;
using Mobile.DeviceUsageInfo;

namespace Mobile
{
    class Program
    {
        static void Main(string[] args)
        {
            MobileDevice Device = MobileDevice.GetKnownDevice(KnownDevices.SamsungGalaxyA5);
            Device.SetPhoneNumber(6973453703);
            Call NewCall = new Call(Device.PhoneNumber, 6987761688);

            Device.AddToCallHistory(NewCall, true);

            Console.ReadKey();
        }
    }
}
