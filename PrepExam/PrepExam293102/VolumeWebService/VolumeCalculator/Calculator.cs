using System;

namespace VolumeWebService.VolumeCalculator
{
    public class Calculator
    {
        public double CalculateVolumeCylinder(double radius, double height)
        {
            return Math.PI * radius * radius * height;
        }

        public double CalculateVolumeCone(double radius, double height)
        {
            return CalculateVolumeCylinder(radius, height) / 3;
        }
    }
}