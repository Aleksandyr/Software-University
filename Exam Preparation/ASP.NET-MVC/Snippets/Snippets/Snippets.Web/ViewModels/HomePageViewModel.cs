using System.Collections.Generic;

namespace Snippets.Web.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<SnippetViewModel> Snippets { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; } 
   
        public IEnumerable<HomePageLabelViewModel> Labels { get; set; }    
    }
}