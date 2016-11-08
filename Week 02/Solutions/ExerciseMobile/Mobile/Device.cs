using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
	public enum KnownModels
	{
		iPhone7,
		SamsungGalaxyNote4,
		AsusZenfone3,
		Huawei
	}

	class Device
    {

        //private fields
        private string model;
        private string manufacturer;
        private decimal basePrice;

		public Screen Screen { get; private set; }
		public Battery Battery { get; private set; }

		public Usage Usage { get; private set; }

        //public Properties
        public string Model
        {
            get { return model; }
            private set { model = value; }
        }
        public string Manufacturer
        {
            get { return manufacturer; }
            private set { manufacturer = value; }
        }
        public decimal BasePrice
        {
            get { return basePrice; }
            private set
            {
                if (value > 0)
                {
                    basePrice = value;
                }
            }
        }
        public string Name
        {
            get { return manufacturer + " " + model; }
        }

		//Constructors
		public Device(string manufacturer, string model, decimal basePrice, Screen screen, Battery battery)
		{
			this.Manufacturer = manufacturer;
			this.Model = model;
			this.BasePrice = basePrice;
			this.Screen = screen;
			this.Battery = battery;
			this.Usage = new Usage();
		}

		public static Device GetKnownModel(KnownModels model)
		{
			switch (model) {
				case (KnownModels.AsusZenfone3):
					return new Device("Asus", "Zenfone 3", 300,new Screen(new ScreenResolution(1920, 1200), 10.1), new Battery(BatteryType.LithiumPolymer, 8000));
				case (KnownModels.iPhone7):
					return new Device("Apple", "iPhone 7", 1200, new Screen(new ScreenResolution(640, 480), 5.5), new Battery(BatteryType.LithiumPolymer, 6500));
				default:
					return null;
			}
		}

		public override string ToString()
		{
			string result = "";
			result += this.manufacturer + " " + this.model;
			return result;
		}
	}
}
