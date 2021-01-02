using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebSite.Models
{
    public class Ads
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdsID { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
