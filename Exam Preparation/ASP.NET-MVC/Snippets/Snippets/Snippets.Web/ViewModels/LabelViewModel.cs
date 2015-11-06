namespace Snippets.Web.ViewModels
{
    using Snippets.Common.Mappings;
    using Snippets.Models;

    public class LabelViewModel : IMapFrom<Label>
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }
}