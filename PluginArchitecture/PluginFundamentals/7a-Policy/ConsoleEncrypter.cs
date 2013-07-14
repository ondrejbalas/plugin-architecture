using System;
using _7b_Abstraction;

namespace _7a_Policy
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
            string input = Console.ReadLine().ToUpper();

            // "Encrypt" it
            string output = encryptionAlgorithm.Encrypt(input);

            // Write output
            Console.WriteLine(output);
        }
    }
}
