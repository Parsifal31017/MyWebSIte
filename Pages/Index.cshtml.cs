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


        //public IList<MyWebSite.Models.Company> Company { get; set; }

        public AdminIndexData AdminData { get; set; }
        public int CompanyID { get; set; }

        public async Task OnGetAsync(int? id, int? companyID)
        {
            AdminData = new AdminIndexData();
            AdminData.Company = await _context.Company
                .Include(i => i.OfficeAssignment)
                .Include(i => i.AdminIndexData)
                    .ThenInclude(i => i.Company)
                        .ThenInclude(i => i.Title)
                .Include(i => i.AdminIndexData)
                    .ThenInclude(i => i.Company)
                        .ThenInclude(i => i.Rating)
                .Include(i => i.AdminIndexData)
                    .ThenInclude(i => i.Company)
                        .ThenInclude(i => i.EnrollmentDate)
                .Include(i => i.AdminIndexData)
                    .ThenInclude(i => i.Company)
                        .ThenInclude(i => i.Tags)
                .Include(i => i.AdminIndexData)
                    .ThenInclude(i => i.Company)
                        .ThenInclude(i => i.Topic)
                .Include(i => i.AdminIndexData)
                    .ThenInclude(i => i.Company)
                        .ThenInclude(i => i.News)
                .AsNoTracking()
                .OrderBy(i => i.Title)
                .OrderBy(i => i.Rating)
                .OrderBy(i => i.EnrollmentDate)
                .OrderBy(i => i.Tags)
                .OrderBy(i => i.Topic)
                .OrderBy(i => i.News)
                .ToListAsync();
        }
    }
}
