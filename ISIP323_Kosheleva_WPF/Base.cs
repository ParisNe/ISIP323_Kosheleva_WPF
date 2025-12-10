using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Kosheleva_WPF
{
    static class Base
    {
        static string Model {  get; set; }
        static string EngineType { get; set; }
        static string Color { get; set; }
        static List<string> AddOptions { get; set; }
        static double Sum = 0;
        static double r = 0; //годовая ставка 
        static double C = 0; //цена на авто
        static double P = C * 30; //первоначальный взнос
        //контактные данные
        static string Name { get; set; }
        static string Telephone { get; set; }
        static string Emale { get; set; }
    }
}
