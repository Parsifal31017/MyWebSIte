using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Models
{
    public class AdsAssignment
    {
        public int UsersID { get; set; }
        public int AdsID { get; set; }
        public Users Instructor { get; set; }
        public Ads Ads { get; set; }
    }
}
