using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bolog_Andreea_Proiect.Data;
using Bolog_Andreea_Proiect.Models;


namespace Bolog_Andreea_Proiect.Pages.Movies
{
    public class CreateModel : MovieCategoriesPageModel
    {
        private readonly Bolog_Andreea_Proiect.Data.Bolog_Andreea_ProiectContext _context;

        public CreateModel(Bolog_Andreea_Proiect.Data.Bolog_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");

            var movie = new Movie();
            movie.MovieCategories = new List<MovieCategory>();
            PopulateAssignedCategoryData(_context, movie);

            return Page();

        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newMovie = new Movie();
            if (selectedCategories != null)
            {
                newMovie.MovieCategories = new List<MovieCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new MovieCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newMovie.MovieCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Movie>(
            newMovie,
            "Movie",
            i => i.Title, i => i.Director,
            i => i.Price, i => i.ReleaseDate, i => i.PublisherID))
            {
                _context.Movie.Add(newMovie);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newMovie);
            return Page();
        }
    }
}
