using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _8b_DynamicLoader
{
    public static class FuncExtensions
    {
        static BinaryFormatter formatter = new BinaryFormatter();

         public static byte[] BinarySerialize<T>(this T func)
         {
             using (var stream = new MemoryStream())
             {
                 formatter.Serialize(stream, func);
                 return stream.ToArray();
             }
         }

        public static T BinaryDeserialize<T>(this byte[] serializedFunc)
        {
            using (var stream = new MemoryStream(serializedFunc))
            {
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}