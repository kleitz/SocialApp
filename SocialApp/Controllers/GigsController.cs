using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialApp.Models;
using SocialApp.ViewModels;
using Microsoft.AspNet.Identity;

namespace SocialApp.Controllers
{
    public class GigsController : Controller
    {
        //private var which connects to dbModel
        private ApplicationDbContext _content;

        //Constructor
        public GigsController()
        {
            //instantiate db model to get access to its data
            _content = new ApplicationDbContext();
        }

        //create view
        [Authorize]
        public ActionResult Create()
        {
            //instantiate the Gig view model
            var viewModel = new GigFormViewModel
            {
                //get genres from db model and output to list
                Genres = _content.Genres.ToList()
            };
            //return view model
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        //post method takes parameter of view model
        public ActionResult Create(GigFormViewModel ViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewModel.Genres = _content.Genres.ToList();
                return View("Create", ViewModel);
            }

            //gig object is created
            var gig = new Gig
            {
                //artist detials stored here
                ArtistId = User.Identity.GetUserId(),
                //date time retrieved from the view model and stored here
                DateTime = ViewModel.GetDateTime(),
                //genre is passed here and stored
                GenreId = ViewModel.Genre,
                //the venue is stored here
                Venue = ViewModel.Venue

            };

            //add and save object data to db
            _content.Gigs.Add(gig);
            _content.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}