﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Data;
using MyWebSite.Models;

namespace MyWebSite.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly MyWebSite.Data.ApplicationDbContext _context;

        public DetailsModel(MyWebSite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MyWebSite.Models.Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Admin = await _context.Admin.FirstOrDefaultAsync(m => m.ID == id);

            if (Admin == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
