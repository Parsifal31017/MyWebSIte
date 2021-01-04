using MyWebSite.Models.CompanyViewModels;
using MyWebSite.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebSite.Models;

namespace MyWebSite.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AboutModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<EnrollmentDateGroup> Company { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDateGroup> data =
                from student in _context.Company
                group student by student.EnrollmentDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    CompanyCount = dateGroup.Count()
                };

            Company = await data.AsNoTracking().ToListAsync();
        }
    }
}
