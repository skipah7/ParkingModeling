using System;

namespace ParkingApp.Classes.ModelingClasses
{
    class DistributionsClass
    {
        Random random;
        public double generateUniformValue(double a, double b)
        {
            random = new Random();
            double r_i;
            double result_i = 0;

            while (result_i == 0)
            {
                r_i = random.NextDouble();
                result_i = a + (b - a) * r_i;
                result_i = (Math.Round(result_i, 1));
            }

            return result_i;
        }

        public double generateExponentialValue(double lambda)
        {
            random = new Random();
            double r_i;
            double x_i = 0;

            while (x_i == 0)
            {
                r_i = random.NextDouble();
                x_i = (-1 / lambda) * Math.Log(r_i);
                x_i = (Math.Round(x_i, 1));
            }

            return x_i;
        }

        public double generateNormalValue(double MX, double DX)
        {
            random = new Random();
            double R;
            double dSumm;
            double dRandValue = 0;

            while (dRandValue == 0)
            {
                dSumm = 0;
                for (int i = 0; i <= 12; i++)
                {
                    R = random.NextDouble();
                    dSumm = dSumm + R;
                }
                dRandValue = Math.Round((MX + DX * (dSumm - 6)), 1);
            }

            return Math.Abs(dRandValue);
        }
    }
}