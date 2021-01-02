using System;
using System.Collections.Generic;

namespace MyWebSite.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Rating { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Bonus { get; set; }
        public string Description { get; set; }
        public byte[] Images { get; set; }
        public byte[] Video { get; set; }
        public string Topic { get; set; }
        public string News { get; set; }
        public decimal Price { get; set; }
        public string Tags { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
