using System.ComponentModel.DataAnnotations;

namespace MyWebSite.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int UserID { get; set; }

        [Display(Name = "Office Location")]
        public string Location { get; set; }
    }
}
