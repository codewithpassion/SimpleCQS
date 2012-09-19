namespace CwP.SimpleCQS.Domain.Commands
{
    public interface IArticleCommand
    {
    }

    public class CreateNewArticleCommand : IArticleCommand
    {
        public CreateNewArticleCommand(string name, string color)
        {
            this.Name = name;
            this.Color = color;
        }

        public string Color { get; private set; }

        public string Name { get; private set; }
    }
}