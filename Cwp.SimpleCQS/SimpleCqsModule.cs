namespace CwP.SimpleCQS
{
    using CwP.SimpleCQS.Article;
    using CwP.SimpleCQS.Common.Shell;
    using CwP.SimpleCQS.Domain;
    using CwP.SimpleCQS.Domain.Commands;

    using Ninject.Modules;

    public class SimpleCqsModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IRootView>().To<ArticleViewModel>();
            this.Kernel.Bind<INewArticleViewModel>().To<NewArticleViewModel>();

            this.Kernel.Bind<IArticleQueryService, IArticleService>().To<ArticleServiceStub>().InSingletonScope();

            this.Kernel.Bind<IArticleCommandExecutor>().To<ArticleCommandExecutor>();
        }
    }
}