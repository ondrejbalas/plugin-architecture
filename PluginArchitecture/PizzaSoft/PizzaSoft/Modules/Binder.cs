using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using PizzaSoft.Domain.Abstract;
using PizzaSoft.Plugins;

namespace PizzaSoft.Modules
{
    public class Binder : IBinder
    {
        private readonly IKernel kernel;

        public Binder(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public IPizzaCreationStep GetStep<T>() where T : IPizzaCreationStep
        {
            return kernel.Get<T>();
        }
    }
}