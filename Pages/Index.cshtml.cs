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
        public MainIndexData MainData { get; set; }
        public int CompanyID { get; set; }

        public async Task OnGetAsync(int? id, int? companyID)
        {
            MainData = new MainIndexData();
            MainData.Company = await _context.Company
                .Include(i => i.UserAssignments)
                .Include(i => i.UserAssignments)
                .Include(i => i.UserAssignments)
                .Include(i => i.UserAssignments)
                .Include(i => i.UserAssignments)
                .AsNoTracking()
                .OrderBy(i => i.Title)
                .OrderBy(i => i.Rating)
                .OrderBy(i => i.Tags)
                .OrderBy(i => i.Topic)
                .OrderBy(i => i.News)
                .ToListAsync();
        }
    }
}
