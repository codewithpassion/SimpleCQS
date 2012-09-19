namespace CwP.SimpleCQS.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    using CwP.SimpleCQS.Domain.Queries;

    public interface IArticleQueryService
    {
        void ExecuteQuery(IQuery<IEnumerable<Article>> query);
    }

    public interface IArticleService
    {
        Article AddArticle(Article article);
    }

    public class ArticleServiceStub : IArticleQueryService, IArticleService
    {
        private List<Article> articles = new List<Article> { new Article(), new Article(), };

        public Article AddArticle(Article article)
        {
            this.articles.Add(article);
            return article;
        }

        public void ExecuteQuery(IQuery<IEnumerable<Article>> query)
        {
            var predicateQuery = query as IPredicateQuery<Article>;
            var result = this.articles.Where(a => predicateQuery.Predicate(a));

            query.Callback(result);
        }
    }
}