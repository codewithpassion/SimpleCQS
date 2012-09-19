namespace CwP.SimpleCQS.Domain.Messages
{
    public class NewArticleMessage
    {
        public NewArticleMessage(Article article)
        {
            this.Article = article;
        }

        public Article Article { get; private set; }
    }
}