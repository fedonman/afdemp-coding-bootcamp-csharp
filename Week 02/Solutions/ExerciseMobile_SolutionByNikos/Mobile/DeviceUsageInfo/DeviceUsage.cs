using System;
using System.Collections.Generic;
using System.Threading;
using Mobile.DeviceInfo;

namespace Mobile.DeviceUsageInfo
{
    public enum OperatingSystems
    {
        Android,
        iOS,
        WindowsMobile,
        BlackBerryOS
    }

    class DeviceUsage
    {
        public int BatteryLevelPercentage { get; private set; }
        public OperatingSystems OperatingSystem { get; private set; }

        public List<Call> CallHistory = new List<Call>();
        public MobileDevice ParentDevice { get; private set; }

        public DeviceUsage(MobileDevice device, int batteryLevelPercentage)
        {
            ParentDevice = device;

            BatteryLevelPercentage = batteryLevelPercentage;
            OperatingSystem = GetOSByManufacturer(ParentDevice.DeviceManufacturer);

            InitBatteryLevelUpdater();
        }

        public void AddToCallHistory(Call call)
        {
            CallHistory.Add(call);
        }

        public void ClearCallHistory()
        {
            CallHistory.Clear();
            CallHistory.Capacity = 0;            
        }

        private void InitBatteryLevelUpdater()
        {
            Thread T = new Thread(delegate()
            {
                while (BatteryLevelPercentage != 0)
                {
                    Thread.Sleep(5 * 1000);

                    lock (this)                    
                        BatteryLevelPercentage--;   
                    
                    Console.WriteLine("Device has now {0}% battery level.", BatteryLevelPercentage);
                }

                Console.WriteLine("Device has reached 0% battery level. It will now turn off.");
            });

            T.IsBackground = true;
            T.Start();
        }

        private OperatingSystems GetOSByManufacturer(Manufacturers manufacturer)
        {
            switch (manufacturer)
            {
                case Manufacturers.Samsung:
                case Manufacturers.LG:
                case Manufacturers.TurboX:
                    return OperatingSystems.Android;
                case Manufacturers.Apple:
                    return OperatingSystems.iOS;
                case Manufacturers.Nokia:
                case Manufacturers.Microsoft:
                    return OperatingSystems.WindowsMobile;
                case Manufacturers.BlackBerry:
                    return OperatingSystems.BlackBerryOS;
                default:
                    throw new ArgumentOutOfRangeException(nameof(manufacturer), manufacturer, null);
            }
        }
    }
}
