namespace CwP.SimpleCQS.Domain.Queries
{
    using System;
    using System.Collections.Generic;

    public class GetAllArticlesQuery : IQuery<IEnumerable<Article>>, IPredicateQuery<Article>
    {
        public GetAllArticlesQuery(Action<IEnumerable<Article>> callback)
        {
            this.Callback = callback;
        }

        public Action<IEnumerable<Article>> Callback { get; private set; }

        public Predicate<Article> Predicate
        {
            get
            {
                return article => article != null;
            }
        }
    }
}