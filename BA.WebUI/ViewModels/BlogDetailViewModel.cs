using BA.Domains;
using System;
using System.ComponentModel.DataAnnotations;

namespace BA.WebUI.ViewModels
{
    public class BlogDetailViewModel
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Please Enter Title")]
        [MaxLength(50, ErrorMessage = "Max {0} characters")]
        public string Title { get;  set; }

        public Category Category { get;  set; }

        [Required(ErrorMessage = "Please Enter Description")]
        [MaxLength(250, ErrorMessage = "Max {0} characters")]
        public string Description { get;  set; }

        public DateTime PostedDate { get;  set; }
        public int Likes { get; set; }
    }
}
