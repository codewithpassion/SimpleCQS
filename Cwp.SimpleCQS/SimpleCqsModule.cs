namespace CwP.SimpleCQS
{
    using CwP.SimpleCQS.Common.Shell;
    using CwP.SimpleCQS.Domain;

    using Ninject.Modules;

    public class SimpleCqsModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IRootView>().To<Article.ArticleViewModel>();
            Kernel.Bind<IArticleQueryService>().To<ArticleServiceStub>();
        }
    }
}