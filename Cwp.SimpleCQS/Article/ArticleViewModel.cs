namespace CwP.SimpleCQS.Article
{
    using System.Collections.Generic;
    using System.Linq;

    using Caliburn.Micro;

    using CwP.SimpleCQS.Common.Shell;
    using CwP.SimpleCQS.Domain;
    using CwP.SimpleCQS.Domain.Messages;
    using CwP.SimpleCQS.Domain.Queries;

    public class ArticleViewModel : Screen, IHandle<NewArticleMessage>, IRootView
    {
        private readonly IArticleQueryService articleService;

        private readonly IEventAggregator eventAggregator;

        private IEnumerable<Article> articles;

        public ArticleViewModel(
            INewArticleViewModel newArticle, 
            IArticleQueryService articleService, 
            IEventAggregator eventAggregator, 
            IWindowManager windowManager)
        {
            this.NewArticle = newArticle;
            this.WindowManager = windowManager;
            this.articleService = articleService;
            this.eventAggregator = eventAggregator;

            this.eventAggregator.Subscribe(this);
        }

        public IEnumerable<Article> Articles
        {
            get
            {
                return this.articles;
            }

            set
            {
                if (object.Equals(value, this.articles))
                {
                    return;
                }

                this.articles = value;
                this.NotifyOfPropertyChange(() => this.Articles);
            }
        }

        private INewArticleViewModel NewArticle { get; set; }

        private IWindowManager WindowManager { get; set; }

        public void AddArticle()
        {
            this.WindowManager.ShowDialog(this.NewArticle);
        }

        public void Handle(NewArticleMessage message)
        {
            this.Articles = new List<Article>(this.Articles) { message.Article };
        }

        public void LoadAllArticles()
        {
            this.articleService.ExecuteQuery(new GetAllArticlesQuery(items => this.Articles = items.ToArray()));
        }
    }
}