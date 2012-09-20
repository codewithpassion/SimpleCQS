namespace CwP.SimpleCQS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Caliburn.Micro;

    using CwP.SimpleCQS.Common.Shell;

    using Ninject;

    public class SimpleCqsBootstrapper : Bootstrapper<IShellViewModel>
    {
        protected StandardKernel Kernel { get; set; }

        protected override void BuildUp(object instance)
        {
            this.Kernel.Inject(instance);
        }

        protected override void Configure()
        {
            this.Kernel = new StandardKernel();
            this.Kernel.Load(this.SelectAssemblies());
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return this.Kernel.GetAll(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return string.IsNullOrEmpty(key) ? this.Kernel.Get(service) : this.Kernel.Get(service, key);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return Assembly.GetAssembly(this.GetType());
        }
    }
}