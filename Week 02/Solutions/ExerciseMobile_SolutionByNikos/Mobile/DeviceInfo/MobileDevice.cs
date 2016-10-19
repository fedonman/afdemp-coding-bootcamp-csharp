using System;
using Mobile.DeviceUsageInfo;

namespace Mobile.DeviceInfo
{
    class MobileDevice : IComparable<MobileDevice>
    {
        public Manufacturers DeviceManufacturer { get; private set; }
        public string ModelName { get; private set; }
        public Battery DeviceBattery { get; private set; }
        public Screen DeviceScreen { get; private set; }
        public double BasePrice { get; private set; }
        public long PhoneNumber { get; private set; }

        public DeviceUsage Usage { get; private set; }

        public MobileDevice(Manufacturers deviceManufacturer, string modelName, Battery deviceBattery, Screen deviceScreen, double basePrice, long phoneNumber = 0)
        {
            DeviceManufacturer = deviceManufacturer;
            ModelName = modelName;
            DeviceBattery = deviceBattery;
            DeviceScreen = deviceScreen;
            BasePrice = basePrice;
            PhoneNumber = phoneNumber;

            Usage = new DeviceUsage(this, 100);
        }

        public void SetPhoneNumber(long phoneNumber)
        {
            if (PhoneNumber == default(long))
                PhoneNumber = phoneNumber;
            else
                throw new Exception("Phone number has been set already, it may not change after it has been set.");
        }

        public void AddToCallHistory(Call call, bool autostop = false)
        {
            Usage.AddToCallHistory(call);

            if (autostop)
                call.StartCall(true);
        }

        public void ClearCallHistory()
        {
            Usage.ClearCallHistory();
        }

        public static MobileDevice GetKnownDevice(KnownDevices device)
        {
            switch (device)
            {
                case KnownDevices.AppleIPhone6:
                    return new MobileDevice
                    (
                        Manufacturers.Apple, 
                        "iPhone 6", 
                        new Battery(BatteryTypes.LithiumIon, 2400, "Apple Inc."),
                        new Screen(1334, 750, 4.7), 
                        497.99
                    );

                case KnownDevices.AppleIPhone7:
                    return new MobileDevice
                    (
                        Manufacturers.Apple,
                        "iPhone 7",
                        new Battery(BatteryTypes.LithiumIon, 2400, "Apple Inc."),
                        new Screen(1334, 750, 4.7),
                        742.99
                    );

                case KnownDevices.SamsungGalaxyA3:
                    return new MobileDevice
                    (
                        Manufacturers.Samsung,
                        "Galaxy A3",
                        new Battery(BatteryTypes.LithiumPolymer, 3200, "Samsung Inc."),
                        new Screen(1280, 720, 4.7), 
                        192.43
                    );
                case KnownDevices.SamsungGalaxyA5:
                    return new MobileDevice
                    (
                        Manufacturers.Samsung,
                        "Galaxy A5",
                        new Battery(BatteryTypes.LithiumPolymer, 2900, "Samsung Inc."),
                        new Screen(1920, 1080, 5.2),
                        259.00
                    );
                case KnownDevices.LgGoogleNexus5X:
                    return new MobileDevice
                    (
                        Manufacturers.LG,
                        "Nexus 5X",
                        new Battery(BatteryTypes.LithiumIon, 2700, "Life is Good Corporation"),
                        new Screen(1920, 1080, 5.2),
                        241.10
                    );
                case KnownDevices.MicrosoftLumia950:
                    return new MobileDevice
                    (
                        Manufacturers.Microsoft,
                        "Lumia 950",
                        new Battery(BatteryTypes.LithiumIon, 3000, "Microsoft Corporation"),
                        new Screen(2560, 1440, 5.2),
                        241.10
                    );
                case KnownDevices.TurboXTheIrreplaceable2:
                    return new MobileDevice
                    (
                        Manufacturers.TurboX,
                        "The Irreplaceable 2",
                        new Battery(BatteryTypes.LithiumIon, 900, "Plaisio GmbH"),
                        new Screen(360, 140, 9.2),
                        941.10
                    );                    
                default:
                    throw new ArgumentOutOfRangeException(nameof(device), device, null);
            }
        }

        public int CompareTo(MobileDevice other)
        {
            if (DeviceManufacturer != other.DeviceManufacturer)
                return (int)DeviceManufacturer - (int)other.DeviceManufacturer;

            if (ModelName != other.ModelName)
                return ModelName.Length - other.ModelName.Length;

            int BatteryComparisonDelta = DeviceBattery.CompareTo(other.DeviceBattery);

            if (BatteryComparisonDelta != 0)
                return BatteryComparisonDelta;

            int ScreenComparisonDelta = DeviceScreen.CompareTo(other.DeviceScreen);

            if (ScreenComparisonDelta != 0)
                return ScreenComparisonDelta;

            return 0;
        }
    }
}
