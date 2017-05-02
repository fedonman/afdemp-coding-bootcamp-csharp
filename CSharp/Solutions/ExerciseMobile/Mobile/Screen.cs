using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    //Declare struct Resolution
    public struct ScreenResolution
    {
        public int Width { get; private set; }
		public int Height { get; private set; }
		
		//Constructor
		public ScreenResolution(int width, int height)
		{
			Width = width;
			Height = height;
		}

		//static methods for creating common resolutions
		public static ScreenResolution _1920x1080()
		{
			return new ScreenResolution(1920, 1080);
		}
		public static ScreenResolution _1280x720()
		{
			return new ScreenResolution(1280, 720);
		}
		public static ScreenResolution _1900x1200()
		{
			return new ScreenResolution(1900, 1200);
		}
	}

    class Screen
    {
        public ScreenResolution Resolution { get; private set; }
        public double DiagonalInches { get; private set; }
		
		//Constructor
		public Screen(ScreenResolution resolution, double diagonal) {
			Resolution = resolution;
			DiagonalInches = diagonal;
		}
    }
}
