using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _8b_DynamicLoader;
using _8d_Abstraction;

namespace _8a_PolicyDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            //CompositionRoot compositionRoot = new CompositionRoot();

            //ConsoleEncrypter consoleEncrypter = compositionRoot.GetConsoleEncrypter();
            //consoleEncrypter.GetAndEncryptInput();

            string pluginsPath = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath), "plugins\\");
            if (!Directory.Exists(pluginsPath)) Directory.CreateDirectory(pluginsPath);

            foreach (var assembly in AssemblySelector.PromptForNextAssembly(pluginsPath))
            {
                //var domain = AppDomain.CreateDomain("LoaderDomain");
                //try
                //{
                //    var t = typeof(Loader<T>);

                //    var obj = domain.CreateInstanceFromAndUnwrap(loaderPath, t.FullName, false, BindingFlags.Default, null,
                //                                                 new object[] { assembly, ExecutePlugin }, null, null);
                //    return (obj as Loader<T>).Results;
                //}
                //finally
                //{
                //    AppDomain.Unload(domain);
                //}

                var loader = new Loader<IEncryptionAlgorithm>(assembly, ExecutePlugin);
                loader.Wait();
            }
        }

        static void ExecutePlugin(IEncryptionAlgorithm algorithm)
        {
            ConsoleEncrypter consoleEncrypter = new ConsoleEncrypter(algorithm);
            consoleEncrypter.GetAndEncryptInput();
        }
    }
}
