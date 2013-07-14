using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Ninject;
using Ninject.Modules;
using Ninject.Extensions.Conventions;
using PizzaSoft.Data;
using PizzaSoft.Domain;
using PizzaSoft.Domain.Abstract;
using PizzaSoft.Plugins;

namespace PizzaSoft.Modules
{
    public class DefaultModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPizzaFactory>().To<DefaultPizzaFactory>();
            Bind<IPizzaCreationProcess>().To<DefaultPizzaCreationProcess>();
            Bind<IStateRepository>().To<InMemoryStateRepository>().InSingletonScope();
            Bind<IBinder>().To<Binder>();
            
            var plugin = BindPlugins();
            Bind<IPizzaPriceCalculator>()
                .ToMethod(context => plugin.ChangePizzaPriceCalculator(context.Kernel.Get<DefaultPriceCalculator>()));

        }

        private IPlugin BindPlugins()
        {
            var pluginsPath = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath), "plugins\\");
            if (!Directory.Exists(pluginsPath)) Directory.CreateDirectory(pluginsPath);
            // Requires Ninject.Extensions.Conventions
            this.Bind(x => x.FromAssembliesInPath(pluginsPath)
                .SelectAllClasses()
                .InheritedFrom<Plugin>()
                .BindAllInterfaces()
            );

            var allPlugins = Kernel.GetAll<IPlugin>().ToList();
            Debug.WriteLine("Plugin dir: " + pluginsPath);
            Debug.WriteLine("Plugins found: " + allPlugins.Count);
            var composite = new CompositePlugin(allPlugins);
            Rebind<IPlugin>().ToConstant(composite);
            return composite;
        }
    }
}