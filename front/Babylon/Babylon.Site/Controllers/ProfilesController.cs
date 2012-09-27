using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Babylon.Site.Models;
using Babylon.Site.Providers;


namespace Babylon.Site.Controllers
{
    public class ProfilesController : Controller
    {
        private IProfilesProvider _provider = new ProvidersFactory().BuildProfilesProvider();

        //
        // GET: /Profile/
        [Authorize]
        public ActionResult Index()
        {
            IList<Profile> model = _provider.GetAllProfiles();

            return View(model);
        }

        //
        // GET: /Profile/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {

            Profile profile = _provider.GetProfileByID(Guid.Parse(id));

            return View(profile);
        }

        //
        // GET: /Profile/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Profile/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(Profile model)
        {
            try
            {
                Guid id = _provider.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Profile/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            Profile profile = _provider.GetProfileByID(Guid.Parse(id));

            return View(profile);
        }

        //
        // POST: /Profile/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(string id, Profile profile)
        {
            try
            {
                _provider.Update(profile);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Profile/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            var profile = _provider.GetProfileByID(Guid.Parse(id));

            return View(profile);
        }

        //
        // POST: /Profile/Delete/5

        [HttpPost]
        [Authorize]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                _provider.Remove(Guid.Parse(id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
