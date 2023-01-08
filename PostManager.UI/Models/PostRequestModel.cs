using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class PostRequestModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }

    }
}