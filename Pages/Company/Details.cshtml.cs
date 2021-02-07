using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MyWebSite.Pages.Company
{
    public class DetailsModel : PageModel
    {
        private readonly MyWebSite.Data.ApplicationDbContext _context;

        public DetailsModel(MyWebSite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MyWebSite.Models.Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Company
                .Include(s => s.Owner)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Company == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
