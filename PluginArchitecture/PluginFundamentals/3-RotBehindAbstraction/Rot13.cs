namespace _3_RotBehindAbstraction
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