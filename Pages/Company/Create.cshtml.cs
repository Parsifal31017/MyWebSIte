using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebSite.Data;
using MyWebSite.Models;

namespace MyWebSite.Pages.Company
{
    public class CreateModel : PageModel
    {
        private readonly MyWebSite.Data.ApplicationDbContext _context;

        public CreateModel(MyWebSite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MyWebSite.Models.Company Company { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCompany = new MyWebSite.Models.Company();

            if (await TryUpdateModelAsync<MyWebSite.Models.Company>(
                emptyCompany,
                "company",
                s => s.Title, s => s.EnrollmentDate, s => s.Thematics, s => s.Bonus, s => s.Description, s => s.Images, s => s.Video, s => s.Topic, s => s.News, s => s.Price, s => s.Tags))
            {
                _context.Company.Add(emptyCompany);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
