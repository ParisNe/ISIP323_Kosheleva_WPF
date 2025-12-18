using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Kosheleva_WPF
{
    public static class Base
    {
        public static string Model { get; set; }
        public static double ModelBasePrice { get; set; }
        public static string EngineType { get; set; }
        public static double EnginePrice { get; set; }
        public static string Color { get; set; }
        public static double ColorPrice { get; set; }
        public static List<string> AddOptions { get; set; } = new List<string>();
        public static double OptionsPrice { get; set; }
        public static double TotalPrice { get; set; }

        public static double LoanPercent { get; set; } = 30;
        public static int LoanTermMonths { get; set; } = 36;
        public static double r = 12; //годовая ставка 12%
        public static double MonthlyPayment { get; set; }

        public static string Name { get; set; }
        public static string Telephone { get; set; }
        public static string Email { get; set; }

        public static void CalculateTotalPrice()
        {
            TotalPrice = ModelBasePrice + EnginePrice + ColorPrice + OptionsPrice;
        }

        public static void CalculateLoan()
        {
            double P = TotalPrice * LoanPercent / 100; // Первоначальный взнос
            double S = TotalPrice - P;
            double i = r / 100 / 12; // Месячная процентная ставка

            if (S > 0 && i > 0)
            {
                double numerator = i * Math.Pow(1 + i, LoanTermMonths);
                double denominator = Math.Pow(1 + i, LoanTermMonths) - 1;
                MonthlyPayment = S * (numerator / denominator);
            }
            else
            {
                MonthlyPayment = 0;
            }
        }
    }
    }
