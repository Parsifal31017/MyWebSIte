using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebSite.Models.CompanyViewModels
{
    public class CommentsIndexData
    {
        public IEnumerable<User> Instructors { get; set; }
        public IEnumerable<Ads> Ads { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
