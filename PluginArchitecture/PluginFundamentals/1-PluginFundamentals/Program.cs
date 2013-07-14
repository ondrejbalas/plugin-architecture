using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_PluginFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get input
            string input = Console.ReadLine().ToUpper();
            
            // "Encrypt" it
            string output = "";
            foreach (char c in input)
            {
                if (c >= 65 && c <= 90)
                {
                    output += (char)(c < 78 ? c + 13 : c - 13);
                }
                else
                {
                    output += c;
                }
            }

            // Write output
            Console.WriteLine(output);
        }
    }
}