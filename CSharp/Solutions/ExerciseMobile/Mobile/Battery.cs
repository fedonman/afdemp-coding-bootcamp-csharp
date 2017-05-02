using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    enum BatteryType
    {
        LithiumIon,
        LithiumPolymer,
        NickelCadmium,
        NickelMetalHybride,
        NewLithiumTechnology
    }

    class Battery
    {
        //private fields
        private BatteryType type;
        private int capacity;

        //public Properties
        public BatteryType Type
        {
            get { return type; }
            private set { type = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value > 0 && value <= Int32.MaxValue)
                {
                    capacity = value;
                }
            }
        }

		//Constructor
        public Battery(BatteryType type, int capacity)
        {
            Type = type;
            Capacity = capacity;
        }
    }
}
