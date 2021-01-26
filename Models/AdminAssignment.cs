using MyWebSite.Models.CompanyViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebSite.Models
{
    public class AdminAssignment
    {
        [Key]
        public int AdminID { get; set; }
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public Admin Admin { get; set; }
        public User User { get; set; }

        public IEnumerable<AdminIndexData> AdminIndexData { get; set; }
    }
}
