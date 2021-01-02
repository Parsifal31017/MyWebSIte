using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int AdsID { get; set; }
        public int CompanyID { get; set; }
        public Grade? Grade { get; set; }

        public Ads Ads { get; set; }
        public Company Company { get; set; }
    }
}
