﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bolog_Andreea_Proiect.Data;
using Bolog_Andreea_Proiect.Models;

namespace Bolog_Andreea_Proiect.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Bolog_Andreea_Proiect.Data.Bolog_Andreea_ProiectContext _context;

        public DetailsModel(Bolog_Andreea_Proiect.Data.Bolog_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
