using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bolog_Andreea_Proiect.Data;
using Bolog_Andreea_Proiect.Models;

namespace Bolog_Andreea_Proiect.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Bolog_Andreea_Proiect.Data.Bolog_Andreea_ProiectContext _context;

        public IndexModel(Bolog_Andreea_Proiect.Data.Bolog_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; }

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
