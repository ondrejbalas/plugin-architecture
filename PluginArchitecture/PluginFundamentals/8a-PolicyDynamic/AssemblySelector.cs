using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8a_PolicyDynamic
{
    class AssemblySelector
    {
        public static IEnumerable<string> PromptForNextAssembly(string folder)
        {
            string input = "";
            while (input != "0")
            {
                int i = 1;
                Console.WriteLine("Choose an assembly from the list: ");

                var assemblies = Directory.GetFiles(folder, "*.dll").ToDictionary(s => (i++).ToString());

                foreach (var assembly in assemblies)
                {
                    Console.WriteLine("[{0}] {1}", assembly.Key, new FileInfo(assembly.Value).Name);
                }
                Console.WriteLine("0 to exit");

                Console.WriteLine("Selection? ");
                input = Console.ReadLine();
                if (input != null && assemblies.ContainsKey(input))
                {
                    yield return assemblies[input];
                }
            }
        }
    }
}
