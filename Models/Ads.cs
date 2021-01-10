using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebSite.Models
{
    public class Ads
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int AdsID { get; set; }
        //[StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        //[StringLength(50, MinimumLength = 3)]
        public string Tags { get; set; }

        public int DepartmentID { get; set; }

        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<AdsAssignment> AdsAssignments { get; set; }
    }
}
