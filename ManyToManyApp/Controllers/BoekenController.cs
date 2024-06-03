using ManyToManyApp.Data;
using ManyToManyApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManyToManyApp.Controllers
{
    public class BoekenController : Controller
    {
        private readonly ManyToManyContext _context;

        public BoekenController(ManyToManyContext context) //ctor om deze _context injecteren
        {
            _context = context; //we hebben toegang to onze Context classe
        }

        public async Task<IActionResult> Index() //create async Task (omd void is)
        {
            var boeken = await _context.Boeken
                .Include(b => b.Auteur)
                .Include(b => b.BoekGenres)
                    .ThenInclude(bg => bg.Genre)
                .ToListAsync();

            ViewBag.Count = boeken.Count();

            if (boeken == null || !boeken.Any()) //if null and if geen records hebben
            {
                return NotFound();
            }

            var viewModel = boeken.Select(b => new BoekenIndexViewModel
            { 
                BoekId = b.BoekId,  //view model - lambda expression
                Titel = b.Titel,
                AuteurNaam = b.Auteur.Naam,
                GenreNamen = b.BoekGenres.Select(bg => bg.Genre.Naam).ToList(),
                IsAvailable = b.IsAvailable,
                IsNewRelease = b.IsNewRelease,
                IsBestSeller = b.IsBestSeller,
                BindingType = b.BindingType.HasValue ? b.BindingType.Value.ToString() : "onbekend"        //parer, hardbook, ...

            }).ToList();

            return View(viewModel);
        }
    }
}
