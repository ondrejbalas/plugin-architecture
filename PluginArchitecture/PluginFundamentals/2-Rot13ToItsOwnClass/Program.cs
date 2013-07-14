using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Rot13ToItsOwnClass
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get input
            string input = Console.ReadLine().ToUpper();

            // "Encrypt" it
            Rot13 encryptionAlgorithm = new Rot13();
            string output = encryptionAlgorithm.Encrypt(input);

            // Write output
            Console.WriteLine(output);
        }
    }
}
