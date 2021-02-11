using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Data;
using MyWebSite.Models;

namespace MyWebSite.Pages.Company
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<MyWebSite.Models.Company> Company { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<MyWebSite.Models.Company> companyIQ = from s in _context.Company
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                companyIQ = companyIQ.Where(s => s.Title.Contains(searchString)
                                       || s.Tags.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    companyIQ = companyIQ.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    companyIQ = companyIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    companyIQ = companyIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                case "bonus_desc":
                    companyIQ = companyIQ.OrderByDescending(s => s.Bonus);
                    break;
                case "description_desc":
                    companyIQ = companyIQ.OrderByDescending(s => s.Description);
                    break;
                case "video_desc":
                    companyIQ = companyIQ.OrderByDescending(s => s.Video);
                    break;
                case "topic_desc":
                    companyIQ = companyIQ.OrderByDescending(s => s.Topic);
                    break;
                case "news_desc":
                    companyIQ = companyIQ.OrderByDescending(s => s.News);
                    break;
                case "price_desc":
                    companyIQ = companyIQ.OrderByDescending(s => s.Price);
                    break;
                case "tags_desc":
                    companyIQ = companyIQ.OrderByDescending(s => s.Tags);
                    break;
            }

            int pageSize = 3;
            Company = await PaginatedList<MyWebSite.Models.Company>.CreateAsync(
                companyIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
