namespace Snippets.Web.ViewModels
{
    using Snippets.Common.Mappings;
    using Snippets.Models;

    public class LanguageViewModel : IMapFrom<Language>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}