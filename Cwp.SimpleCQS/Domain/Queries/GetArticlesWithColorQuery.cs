namespace CwP.SimpleCQS.Domain.Queries
{
    using System;
    using System.Collections.Generic;

    public class GetArticlesWithColorQuery : IQuery<IEnumerable<Article>>, IPredicateQuery<Article>
    {
        public GetArticlesWithColorQuery(string color, Action<IEnumerable<Article>> callback)
        {
            this.Color = color;
            this.Callback = callback;
        }

        public Action<IEnumerable<Article>> Callback { get; private set; }

        public string Color { get; private set; }

        public Predicate<Article> Predicate
        {
            get
            {
                return article => article.Color == this.Color;
            }
        }
    }
}