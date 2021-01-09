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

        public InstructorIndexData InstructorData { get; set; }
        public int InstructorID { get; set; }
        public int AdsID { get; set; }

        public async Task OnGetAsync(int? id, int? adsID)
        {
            InstructorData = new InstructorIndexData();
            InstructorData.Instructors = await _context.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.AdsAssignments)
                    .ThenInclude(i => i.Ads)
                        .ThenInclude(i => i.Department)
                //.Include(i => i.AdsAssignments)
                //    .ThenInclude(i => i.Ads)
                //        .ThenInclude(i => i.Enrollments)
                //            .ThenInclude(i => i.Company)
                //.AsNoTracking()
                .OrderBy(i => i.LastName)
                .ToListAsync();

            if (id != null)
            {
                InstructorID = id.Value;
                MyWebSite.Models.User instructor = InstructorData.Instructors
                    .Where(i => i.ID == id.Value).Single();
                InstructorData.Ads = instructor.AdsAssignments.Select(s => s.Ads);
            }

            if (adsID != null)
            {
                AdsID = adsID.Value;
                var selectedAds = InstructorData.Ads
                    .Where(x => x.AdsID == adsID).Single();
                await _context.Entry(selectedAds).Collection(x => x.Enrollments).LoadAsync();
                foreach (Enrollment enrollment in selectedAds.Enrollments)
                {
                    await _context.Entry(enrollment).Reference(x => x.Company).LoadAsync();
                }
                InstructorData.Enrollments = selectedAds.Enrollments;
            }
        }
    }
}
