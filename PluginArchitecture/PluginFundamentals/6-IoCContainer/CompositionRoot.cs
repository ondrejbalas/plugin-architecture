﻿using Ninject;

namespace _6_IoCContainer
{
    public class CompositionRoot
    {
        private IKernel container;

        public CompositionRoot()
        {
            container = new StandardKernel();

            container.Bind<IEncryptionAlgorithm>().To<Rot13>();
        }

        public ConsoleEncrypter GetConsoleEncrypter()
        {
            return container.Get<ConsoleEncrypter>();
        }
    }
}
