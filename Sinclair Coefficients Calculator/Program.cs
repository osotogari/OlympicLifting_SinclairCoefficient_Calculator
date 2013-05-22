using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinclair_Coefficients_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the following information to calculate your Sinclair Coefficient");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            
            Console.WriteLine("Are you Male or Female?");
            string sex = Console.ReadLine();

            Console.WriteLine("Weight (in kg)");
            string weight = Console.ReadLine();

            Console.WriteLine("Total (in kg)");
            string total = Console.ReadLine();

            //convert values to doubles
            double iWeight = Convert.ToDouble(weight);
            double iTotal = Convert.ToDouble(total);

            string SCTotal = CalculateSC(sex.ToLower(), iWeight, iTotal);

            Console.WriteLine("Your SC is " + SCTotal);

            Console.ReadLine();
        }

        private static string CalculateSC(string sex, double iWeight, double iTotal)
        {
            string result = string.Empty;
            const double maxMale  = 174.393;
            const double maxFemale = 148.026;

            var A = (sex == "male" || sex == "m") ? 0.794358141 : 0.897260740;
            var b = (sex == "male" || sex == "m") ? maxMale : maxFemale;

            var X = (Math.Log(iWeight / b)) / (Math.Log(10));
            var AX2 = A * (X * X);
            var SC = Math.Pow(10, AX2);
            var SCTotal = Math.Round((SC * iTotal) * 100) / 100;

            if(!double.IsNaN(SCTotal))
            {
                result = SCTotal.ToString();
            }

            return result;
            
        }

        
    }
}
