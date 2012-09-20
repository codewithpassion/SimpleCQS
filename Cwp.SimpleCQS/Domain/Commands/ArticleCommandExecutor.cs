namespace CwP.SimpleCQS.Domain.Commands
{
    using Caliburn.Micro;

    using CwP.SimpleCQS.Domain.Messages;

    public interface IArticleCommandExecutor
    {
        void Execute(IArticleCommand command);
    }

    public class ArticleCommandExecutor : IArticleCommandExecutor
    {
        private readonly IArticleService articleService;

        private readonly IEventAggregator eventAggregator;

        public ArticleCommandExecutor(IArticleService articleService, IEventAggregator eventAggregator)
        {
            this.articleService = articleService;
            this.eventAggregator = eventAggregator;
        }

        public void Execute(IArticleCommand command)
        {
            var createNewArticleCommand = command as CreateNewArticleCommand;
            if (createNewArticleCommand != null)
            {
                var result =
                    this.articleService.AddArticle(
                        new Article { Color = createNewArticleCommand.Color, Name = createNewArticleCommand.Name });
                
                this.eventAggregator.Publish(new NewArticleMessage(result));
            }
        }
    }
}