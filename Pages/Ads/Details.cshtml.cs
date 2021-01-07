using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Data;
using MyWebSite.Models;

namespace MyWebSite.Pages.Ads
{
    public class DetailsModel : PageModel
    {
        private readonly MyWebSite.Data.ApplicationDbContext _context;

        public DetailsModel(MyWebSite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MyWebSite.Models.Ads Ads { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ads = await _context.Ads
                .Include(a => a.Department).FirstOrDefaultAsync(m => m.AdsID == id);

            if (Ads == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
