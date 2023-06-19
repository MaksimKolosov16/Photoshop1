using System;
using System.Drawing;

namespace MyPhotoshop
{
    public struct Pixel
    {
        public Pixel(double r, double g, double b):this()
        {
            //_r = _g = _b = 0;
            R = r;
            G = g;
            B = b;
        }
        
        public static Pixel operator *(Pixel pixel, double factor)
        {
            return new Pixel(
                Trim(pixel.R * factor), 
                Trim(pixel.G * factor), 
                Trim(pixel.B * factor));
        }
        
        public static Pixel operator *(double factor, Pixel pixel)
        {
            return pixel * factor;
        }

        public static double Trim(double value)
        {
            if (value < 0)
                return 0;
            if (value > 1)
                return 1;
            return value;
        }
        
        private static double Check(double value)
        {
            if (value < 0 || value > 1)
                throw new Exception(string.Format("Wrong channel value {0} (the value must be between 0 and 1", value));
            return value;
        }

        private double _r;

        public double R
        {
            get { return _r; }
            set { _r = Check(value); }
        }

        private double _g;

        public double G
        {
            get { return _g; }
            set { _g = Check(value); }
        }

        private double _b;

        public double B
        {
            get { return _b; }
            set { _b = Check(value); }
        }

        // public static explicit operator Pixel(Color color)
        // {
        //     return new Pixel {R = (double)color.R / 255, G = (double)color.G / 255, B = (double)color.B / 255};
        // }
    }
}