using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _7b_Abstraction;

namespace _7d_LeetPlugin
{
    public class Leet : IEncryptionAlgorithm
    {
        public string Encrypt(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                switch (c)
                {
                    case 'A':
                        output += '4';
                        break;
                    case 'E':
                        output += '3';
                        break;
                    case 'L':
                        output += '1';
                        break;
                    case 'O':
                        output += '0';
                        break;
                    case 'S':
                        output += '5';
                        break;
                    case 'T':
                        output += '7';
                        break;
                    default:
                        output += c;
                        break;
                }
            }
            return output;
        }
    }
}
