using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebSite.Models.CompanyViewModels
{
    [Keyless]
    public class AdminIndexData
    {
        public IEnumerable<User> User { get; set; }
        public IEnumerable<Admin> Admin { get; set; }
        public IEnumerable<Company> Company { get; set; }
    }
}
