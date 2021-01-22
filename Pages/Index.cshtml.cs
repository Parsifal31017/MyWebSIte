using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebSite.Models;
using MyWebSite.Models.CompanyViewModels;
using Microsoft.EntityFrameworkCore;

namespace MyWebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyWebSite.Data.ApplicationDbContext _context;

        public IndexModel(MyWebSite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public int CompanyID { get; set; }

        public IList<MyWebSite.Models.Company> Company { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            CurrentFilter = searchString;

            IQueryable<MyWebSite.Models.Company> companyIQ = from s in _context.Company
                                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                companyIQ = companyIQ.Where(s => s.Title.Contains(searchString)
                                       || s.Tags.Contains(searchString));
            }

            //Company = new MyWebSite.Models.Company();
            Company = await _context.Company
                .Include(i => i.UserAssignments)
                .Include(i => i.UserAssignments)
                .Include(i => i.UserAssignments)
                .Include(i => i.UserAssignments)
                .Include(i => i.UserAssignments)
                .Include(i => i.UserAssignments)
                .AsNoTracking()
                .OrderBy(i => i.Title)
                .OrderBy(i => i.Rating)
                .OrderBy(i => i.EnrollmentDate)
                .OrderBy(i => i.Tags)
                .OrderBy(i => i.Topic)
                .OrderBy(i => i.News)
                .ToListAsync();

            switch (sortOrder)
            {
                case "name_desc":
                    companyIQ = companyIQ.OrderByDescending(s => s.Rating);
                    break;
                case "Date":
                    companyIQ = companyIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    companyIQ = companyIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
            }

            Company = await companyIQ.AsNoTracking().ToListAsync();
        }
    }
}
