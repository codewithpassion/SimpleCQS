namespace CwP.SimpleCQS
{
    using System.Collections.Generic;

    using Caliburn.Micro;

    using CwP.SimpleCQS.Domain;
    using CwP.SimpleCQS.Domain.Messages;
    using CwP.SimpleCQS.Domain.Queries;

    public class ArticleViewModel : PropertyChangedBase, IHandle<NewArticleMessage>
    {
        private readonly IArticleQueryService articleService;
        private readonly IEventAggregator eventAggregator;
        private IEnumerable<Article> articles;

        public ArticleViewModel(IArticleQueryService articleService, IEventAggregator eventAggregator)
        {
            this.articleService = articleService;
            this.eventAggregator = eventAggregator;
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

        public void Handle(NewArticleMessage message)
        {
            var newList = new List<Article>(this.Articles);
            newList.Add(message.Article);
            this.Articles = newList;
        }

        public void LoadAllArticles()
        {
            this.articleService.ExecuteQuery(new GetAllArticlesQuery(items => this.articles = items));
        }
    }
}