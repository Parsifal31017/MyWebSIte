using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebSite.Data;
using MyWebSite.Models;

namespace MyWebSite.Pages.User
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

        public async Task<IActionResult> OnPostAsync(string[] selectedCourses)
        {
            var newInstructor = new MyWebSite.Models.User();
            if (selectedCourses != null)
            {
                newInstructor.AdsAssignments = new List<AdsAssignment>();
                foreach (var course in selectedCourses)
                {
                    var courseToAdd = new AdsAssignment
                    {
                        AdsID = int.Parse(course)
                    };
                    newInstructor.AdsAssignments.Add(courseToAdd);
                }
            }

            if (await TryUpdateModelAsync<MyWebSite.Models.User>(
                newInstructor,
                "Instructor",
                i => i.FirstMidName, i => i.LastName,
                i => i.HireDate, i => i.OfficeAssignment))
            {
                _context.Instructors.Add(newInstructor);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCourseData(_context, newInstructor);
            return Page();
        }
    }
}
