using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bolog_Andreea_Proiect.Data;
using Bolog_Andreea_Proiect.Models;
namespace Bolog_Andreea_Proiect.Pages.Movies
{
    public class EditModel : MovieCategoriesPageModel
    {
        private readonly Bolog_Andreea_Proiect.Data.Bolog_Andreea_ProiectContext _context;

        public EditModel(Bolog_Andreea_Proiect.Data.Bolog_Andreea_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie
     .Include(b => b.Publisher)
     .Include(b => b.MovieCategories).ThenInclude(b => b.Category)
     .AsNoTracking()
     .FirstOrDefaultAsync(m => m.ID == id);

            Movie = await _context.Movie.FirstOrDefaultAsync(b => b.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Movie);

            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movieToUpdate = await _context.Movie
            .Include(i => i.Publisher)
            .Include(i => i.MovieCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (movieToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Movie>(
                movieToUpdate,
                "Movie",
            i => i.Title, i => i.Director,
            i => i.Price, i => i.ReleaseDate, i => i.Publisher))
            {
                UpdateMovieCategories(_context, selectedCategories, movieToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateMovieCategories(_context, selectedCategories, movieToUpdate);
            PopulateAssignedCategoryData(_context, movieToUpdate);
            return Page();
        }
    }
}

