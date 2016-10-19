using System;

namespace Mobile.DeviceInfo
{
    public enum BatteryTypes
    {
        LithiumIon,
        LithiumPolymer,
        NickelCadmium,
        NickelMetalHydride
    }

    class Battery : IComparable<Battery>
    {
        public BatteryTypes BatteryType { get; private set; }
        public int BatteryCapacity { get; private set; }
        public string ManufacturerName { get; private set; }

        public Battery(BatteryTypes batteryType, int batteryCapacity, string manufacturerName)
        {
            BatteryType = batteryType;
            BatteryCapacity = batteryCapacity;
            ManufacturerName = manufacturerName;
        }

        public override string ToString()
        {
            return $"Battery Type {BatteryType}: Manufactured by {ManufacturerName} - Capacity {BatteryCapacity} mAh.";
        }

        public int CompareTo(Battery other)
        {

            if (ManufacturerName != other.ManufacturerName)
                return ManufacturerName.Length - other.ManufacturerName.Length;

            return (int) BatteryType - (int) other.BatteryType;
        }
    }
}
