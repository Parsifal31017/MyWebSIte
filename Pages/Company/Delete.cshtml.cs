using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MyWebSite.Pages.Company
{
    public class DeleteModel : PageModel
    {
        private readonly MyWebSite.Data.ApplicationDbContext _context;

        public DeleteModel(MyWebSite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MyWebSite.Models.Company Company { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Company.AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Company == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            try
            {
                _context.Company.Remove(company);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
