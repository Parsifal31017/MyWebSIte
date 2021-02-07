using System.ComponentModel.DataAnnotations;

namespace MyWebSite.Models
{
    public class Owner
    {
        [Key]
        public int UserID { get; set; }
        public int CompanyID { get; set; }

        public Company Company { get; set; }
    }
}
