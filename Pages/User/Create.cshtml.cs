using MyWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebSite.Pages.User;

namespace MyWebSite.Pages.Instructors
{
    public class CreateModel : InstructorCoursesPageModel
    {
        private readonly MyWebSite.Data.ApplicationDbContext _context;

        public CreateModel(MyWebSite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var instructor = new MyWebSite.Models.User();
            instructor.AdsAssignments = new List<AdsAssignment>();

            // Provides an empty collection for the foreach loop
            // foreach (var course in Model.AssignedCourseDataList)
            // in the Create Razor page.
            PopulateAssignedCourseData(_context, instructor);
            return Page();
        }

        [BindProperty]
        public MyWebSite.Models.User Instructor { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedAds)
        {
            var newInstructor = new MyWebSite.Models.User();
            if (selectedAds != null)
            {
                newInstructor.AdsAssignments = new List<AdsAssignment>();
                foreach (var ads in selectedAds)
                {
                    var adsToAdd = new AdsAssignment
                    {
                        AdsID = int.Parse(ads)
                    };
                    newInstructor.AdsAssignments.Add(adsToAdd);
                }
            }

            var emptyUser = new MyWebSite.Models.User();

            if (await TryUpdateModelAsync<MyWebSite.Models.User>(
                emptyUser,
                "user",   // Prefix for form value.
                s => s.LastName, s => s.FirstMidName, s => s.HireDate, s => s.Age, s => s.Country, s => s.City, s => s.Email, s => s.AboutMe))
            {
                _context.Instructors.Add(emptyUser);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedCourseData(_context, newInstructor);
            return Page();

            //if (await TryUpdateModelAsync<MyWebSite.Models.User>(
            //    newInstructor,
            //    "Instructor",
            //    i => i.FirstMidName, i => i.LastName,
            //    i => i.HireDate, i => i.OfficeAssignment))
            //{
            //    _context.Instructors.Add(newInstructor);
            //    await _context.SaveChangesAsync();
            //    return RedirectToPage("./Index");
            //}
            //PopulateAssignedCourseData(_context, newInstructor);
            //return Page();
        }
    }
}
