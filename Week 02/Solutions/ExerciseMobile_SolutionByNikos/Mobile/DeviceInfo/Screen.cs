using System;

namespace Mobile.DeviceInfo
{
    class Screen : IComparable<Screen>
    {
        //TODO: Replace with Size?
        public int ResolutionX { get; private set; }
        public int ResolutionY { get; private set; }
        public double DisplaySize { get; private set; }
        public int PixelDensity { get; private set; }

        public Screen(int resolutionX, int resolutionY, double displaySize)
        {
            ResolutionX = resolutionX;
            ResolutionY = resolutionY;
            DisplaySize = displaySize;

            PixelDensity = CalculatePixelDensity();
        }

        private int CalculatePixelDensity()
        {
            if (ResolutionX == default(int) || ResolutionY == default(int) || DisplaySize == default(int))
                throw new Exception("One or more of the Screen required fields has not been set.");

            double DiagonalResolution = Math.Sqrt(ResolutionX * ResolutionX + ResolutionY * ResolutionY);
            return (int)(DiagonalResolution / DisplaySize);
        }

        public int CompareTo(Screen other)
        {
            if (ResolutionX != other.ResolutionX)
                return ResolutionX - other.ResolutionX;

            if (ResolutionY != other.ResolutionY)
                return ResolutionY - other.ResolutionY;

            if (DisplaySize != other.DisplaySize)
                return (int)(DisplaySize - other.DisplaySize);

            if (PixelDensity != other.PixelDensity)
                return PixelDensity - other.PixelDensity;

            return 0;
        }
    }
}
