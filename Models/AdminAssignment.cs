using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Models
{
    public class AdminAssignment
    {
        public int AdminID { get; set; }
        public int UserID { get; set; }
        public Admin Admin { get; set; }
        public User User { get; set; }
    }
}
