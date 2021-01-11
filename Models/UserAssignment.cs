using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebSite.Models
{
    public class UserAssignment
    {
        [Key]
        public int CompanyID { get; set; }

        public Company Company { get; set; }
    }
}
