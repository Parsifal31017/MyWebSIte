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

        //public IList<MyWebSite.Models.User> User { get;set; }

        //public async Task OnGetAsync()
        //{
        //    User = await _context.User.ToListAsync();
        //}

        public AdminIndexData AdminData { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }

        public async Task OnGetAsync(int? id, int? courseID)
        {
            AdminData = new AdminIndexData();
            AdminData.User = await _context.User
                .Include(i => i.OfficeAssignment)
                .Include(i => i.AdminIndexData)
                    .ThenInclude(i => i.User)
                        .ThenInclude(i => i.FirstMidName)
                .Include(i => i.AdminIndexData)
                    .ThenInclude(i => i.Company)
                        .ThenInclude(i => i.Title)
                .AsNoTracking()
                .OrderBy(i => i.FirstMidName)
                .ToListAsync();
        }
    }
}
