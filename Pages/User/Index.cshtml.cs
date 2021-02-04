using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Data;
using MyWebSite.Models;
using MyWebSite.Models.CompanyViewModels;

namespace MyWebSite.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly MyWebSite.Data.ApplicationDbContext _context;

        public IndexModel(MyWebSite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MyWebSite.Models.Company> Company { get; set; }

        public List<MyWebSite.Models.Company> GetCompaniesWithRank()
        {
            return Company != null
                ? Company.OrderBy(p => p.Rank).Take(100).ToList()
                : new List<MyWebSite.Models.Company>();
        }

        public List<MyWebSite.Models.Company> GetCompaniesWithUpdate()
        {
            return Company != null
                ? Company.OrderBy(p => p.Update).ToList()
                : new List<MyWebSite.Models.Company>();
        }

        public async Task OnGetAsync(int? id, int? courseID)
        {
            Company = await _context.Company
    .Include(c => c.AdminIndexData)
    .AsNoTracking()
    .ToListAsync();
        }
    }
}
