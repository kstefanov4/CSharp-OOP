using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            Lenght = lenght;
            Width = width;
            Height = height;
        }

        public double Lenght
        {
            get 
            { 
                return lenght; 
            }
            set 
            {
                if (ValidateInputValue("Lenght",value))
                {
                    lenght = value;
                }
                
            }
        }

        public double Width
        {
            get 
            { 
                return width; 
            }
            set 
            {
                if (ValidateInputValue("Width", value))
                {
                    width = value;
                }
                
            }
        }

        public double Height
        {
            get 
            { 
                return height; 
            }
            set 
            {
                if (ValidateInputValue("Height", value))
                {
                    height = value;
                }
                 
            }
        }
/*
        Volume = lwh
        Lateral Surface Area = 2lh + 2wh
        Surface Area = 2lw + 2lh + 2wh
*/
        public double SurfaceArea()
        {
            return 2 * Lenght * Width + 2 * Lenght * Height + 2 * Width * Height; 
        }

        public double LateralSurfaceArea()
        {
            return 2 * Lenght * Height + 2 * Width * Height;
        }

        public double Volume()
        {
            return Lenght * Height * Width;
        }
        private bool ValidateInputValue(string propertyName, double value)
        {
            if (value <= 0 )
            {
                throw new ArgumentException($"{propertyName} cannot be zero or negative.");
            }
            return true;
        }

    }
}
