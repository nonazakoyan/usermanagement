using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public class Config
    {
        public static string? Value1 { get; set; }
        public static int? Value2 { get; set; }
        public static void print()
        {
            Console.WriteLine($"Value1 = {Value1}\nValue2 = {Value2}");
        }
    }
}
