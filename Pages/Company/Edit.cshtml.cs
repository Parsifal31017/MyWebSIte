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

namespace MyWebSite.Pages.Company
{
    public class EditModel : PageModel
    {
        private readonly MyWebSite.Data.ApplicationDbContext _context;

        public EditModel(MyWebSite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MyWebSite.Models.Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Company.FindAsync(id);

            if (Company == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var studentToUpdate = await _context.Company.FindAsync(id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<MyWebSite.Models.Company>(
                studentToUpdate,
                "company",
                s => s.Title, s => s.Rating, s => s.EnrollmentDate, s => s.Bonus, s => s.Description, s => s.Images, s => s.Video, s => s.Topic, s => s.News, s => s.Price, s => s.Tags))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.ID == id);
        }
    }
}
