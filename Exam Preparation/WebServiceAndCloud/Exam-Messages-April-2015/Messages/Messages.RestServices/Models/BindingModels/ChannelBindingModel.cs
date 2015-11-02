using System.ComponentModel.DataAnnotations;

namespace Messages.RestServices.Models
{
    public class ChannelBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}