using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebSite.Models.CompanyViewModels
{
    public class AdminIndexData
    {
        [Key]
        public int AdminIndexDataID { get; set; }
        public IEnumerable<User> User { get; set; }
        public IEnumerable<Admin> Admin { get; set; }
        public IEnumerable<Company> Company { get; set; }
        public IEnumerable<Owner> Owner { get; set; }
    }
}
