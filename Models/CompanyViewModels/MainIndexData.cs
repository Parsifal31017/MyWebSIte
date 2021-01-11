using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebSite.Models.CompanyViewModels
{
    public class MainIndexData
    {
        public IEnumerable<User> Instructors { get; set; }
        public IEnumerable<Company> Company { get; set; }
        public IEnumerable<UserAssignment> UserAssignment { get; set; }
    }
}
