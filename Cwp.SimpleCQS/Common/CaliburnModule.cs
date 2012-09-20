namespace CwP.SimpleCQS.Common
{
    using Caliburn.Micro;

    using CwP.SimpleCQS.Common.Shell;

    using Ninject.Modules;

    public class CaliburnModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IShellViewModel>().To<ShellViewModel>();
            this.Kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            this.Kernel.Bind<IWindowManager>().To<WindowManager>();
        }
    }
}