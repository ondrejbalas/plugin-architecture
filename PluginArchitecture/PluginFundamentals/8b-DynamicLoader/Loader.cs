using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _8b_DynamicLoader
{
    public class Loader<T>
    {
        private readonly string pathToAssembly;
        private readonly Action<T> callBack;
        private Task task;

        public Loader(string pathToAssembly, Action<T> callBack)
        {
            this.pathToAssembly = pathToAssembly;
            this.callBack = callBack;

            // Spawn a new thread. We have to do this from the constructor so that the new thread runs under the new AppDomain
            task = Task.Factory.StartNew(Main);
        }

        // This becomes the "Main" method of the new AppDomain
        private void Main()
        {
            var domain = AppDomain.CreateDomain("LoaderDomain");
            try
            {
                //var t = typeof(Loader<IEncryptionAlgorithm>);

                //var obj = domain.CreateInstanceFromAndUnwrap(loaderPath, t.FullName, false, BindingFlags.Default, null,
                //                                             new object[] { payload }, null, null);
                //return (obj as Loader<T>).Results;


                // load the DLL
                var assembly = Assembly.LoadFile(pathToAssembly);

                // find all implementors of T
                var type = typeof(T);
                var implementorsOfType = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => type.IsAssignableFrom(p) && p.GetConstructor(Type.EmptyTypes) != null);

                // select the first implementor
                var first = implementorsOfType.FirstOrDefault();
                if (first != null)
                {
                    // if one exists, create an instance and pass into callback
                    var obj = (T)Activator.CreateInstance(first);
                    callBack(obj);
                }
                else
                {
                    // if it doesn't exist, pass back a default object.
                    callBack(default(T));
                }
            }
            finally
            {
                AppDomain.Unload(domain);
            }
        }

        public void Wait()
        {
            task.Wait();
        }
    }
}
