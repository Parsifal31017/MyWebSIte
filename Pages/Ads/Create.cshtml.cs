﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebSite.Data;
using MyWebSite.Models;

namespace MyWebSite.Pages.Ads
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
        ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID");
            return Page();
        }

        [BindProperty]
        public MyWebSite.Models.Ads Ads { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ads.Add(Ads);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
