using MyWebSite.Models.CompanyViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
