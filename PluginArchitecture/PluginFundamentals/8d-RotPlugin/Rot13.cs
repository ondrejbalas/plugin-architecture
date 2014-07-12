using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8d_Abstraction;

namespace _8e_RotPlugin
{
    public class Rot13 : IEncryptionAlgorithm
    {
        public string Encrypt(string input)
        {
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
            return output;
        }
    }
}
