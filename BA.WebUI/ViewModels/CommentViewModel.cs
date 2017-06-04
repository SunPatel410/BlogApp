using System.ComponentModel.DataAnnotations;

namespace BA.WebUI.ViewModels
{
    public class CommentViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [MaxLength(20, ErrorMessage = "Max {0} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Comment Description")]
        [MaxLength(100, ErrorMessage = "Max {0} characters")]
        public string CommentDescription { get;  set; }
    }
}
