namespace CwP.SimpleCQS.Domain.Fakes
{
    using System.Collections.Generic;

    public static class ArticleFakes
    {
        public static IEnumerable<Article> ThreeFakeArticles
        {
            get
            {
                return new[]
                    {
                       new Article { Name = "Book", Color = "Red" }, 
                       new Article { Name = "Car", Color = "Blue" }, 
                       new Article { Name = "Dog", Color = "Brown" }, 
                    };
            }
        }
    }
}