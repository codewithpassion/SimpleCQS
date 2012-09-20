namespace CwP.SimpleCQS.Common.Shell
{
    using Caliburn.Micro;

    public interface IShellViewModel
    {
        IRootView RootView { get; }
    }

    public class ShellViewModel : Screen, IShellViewModel
    {
        public ShellViewModel(IRootView rootView)
        {
            this.RootView = rootView;
        }

        public IRootView RootView { get; set; }

        protected override void OnViewLoaded(object view)
        {
            this.DisplayName = "Simple CQS";
        }
    }
}