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
        public static string Model {  get; set; }
        public static string EngineType { get; set; }
        public static string Color { get; set; }
        public static List<string> AddOptions { get; set; }
        public static double Sum = 0;
        public static double r = 0; //годовая ставка 
        public static double C = 0; //цена на авто
        public static double P = C * 30; //первоначальный взнос
        //контактные данные
        public static string Name { get; set; }
        public static string Telephone { get; set; }
        public static string Emale { get; set; }
    }
}
