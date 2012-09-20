namespace CwP.SimpleCQS.Article
{
    using Caliburn.Micro;

    using CwP.SimpleCQS.Domain.Commands;

    public interface INewArticleViewModel
    {
        string ArticleColor { get; set; }

        string ArticleName { get; set; }

        void Cacel();

        void Save();
    }

    public class NewArticleViewModel : Screen, INewArticleViewModel
    {
        public NewArticleViewModel(IArticleCommandExecutor commandExecutor)
        {
            this.CommandExecutor = commandExecutor;
        }

        public string ArticleColor { get; set; }

        public string ArticleName { get; set; }

        protected IArticleCommandExecutor CommandExecutor { get; private set; }

        public void Cacel()
        {
            this.TryClose();
        }

        public void Save()
        {
            this.CommandExecutor.Execute(new CreateNewArticleCommand(this.ArticleName, this.ArticleColor));
            this.TryClose();
        }

        protected override void OnInitialize()
        {
            this.DisplayName = "Add new article";
        }
    }
}