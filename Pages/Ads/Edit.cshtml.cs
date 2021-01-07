using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Data;
using MyWebSite.Models;

namespace MyWebSite.Pages.Ads
{
    public class EditModel : PageModel
    {
        private readonly MyWebSite.Data.ApplicationDbContext _context;

        public EditModel(MyWebSite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdsExists(Ads.AdsID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AdsExists(int id)
        {
            return _context.Ads.Any(e => e.AdsID == id);
        }
    }
}
