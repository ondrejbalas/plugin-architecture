using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8d_Abstraction;

namespace _8a_PolicyDynamic
{
    public class ConsoleEncrypter
    {
        private readonly IEncryptionAlgorithm encryptionAlgorithm;

        public ConsoleEncrypter(IEncryptionAlgorithm encryptionAlgorithm)
        {
            this.encryptionAlgorithm = encryptionAlgorithm;
        }

        public void GetAndEncryptInput()
        {
            // Get input
            Console.WriteLine("What is your input?");
            string input = Console.ReadLine().ToUpper();

            // "Encrypt" it
            string output = encryptionAlgorithm.Encrypt(input);

            // Write output
            Console.WriteLine(output);
        }
    }
}
