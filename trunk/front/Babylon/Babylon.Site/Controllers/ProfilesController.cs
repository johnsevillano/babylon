﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Babylon.Site.Models;
using Babylon.Site.Providers;


namespace Babylon.Site.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ProfilesController : Controller
    {
        private IProfilesProvider _provider = new ProvidersFactory().BuildProfilesProvider();

        //
        // GET: /Profile/
        public ActionResult Index()
        {
            IList<Profile> profiles = _provider.GetAllProfiles();

            IList<ProfileViewModel> model = new List<ProfileViewModel>();

            foreach (Profile profile in profiles)
            {
                model.Add(new ProfileViewModel(profile));
            }

            return View(model);
        }

        //
        // GET: /Profile/Details/5
        public ActionResult Details(string id)
        {

            Profile profile = _provider.GetProfileByID(Guid.Parse(id));

            ProfileViewModel model = new ProfileViewModel(profile);

            return View(model);
        }

        //
        // GET: /Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Profile/Create

        [HttpPost]
        public ActionResult Create(ProfileInputModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Profile newProfile = new Profile()
                    {
                        ID = model.ID,
                        Username = model.Username,
                        Name = model.Name,
                        Surname = model.Surname,
                        Email = model.Email,
                        DateOfBirth = model.DateOfBirth,
                        Address = new Address() {
                            Street = model.Address.Street,
                            City = model.Address.City,
                            PostalCode = model.Address.PostalCode
                        },
                        Gender = model.Gender,
                        Description = model.Description
                    };

                    Guid id = _provider.Add(newProfile);

                    return RedirectToAction("Index");
                }
            }
            catch {}

            return View();
        }
        
        //
        // GET: /Profile/Edit/5
        public ActionResult Edit(string id)
        {
            Profile profile = _provider.GetProfileByID(Guid.Parse(id));

            ProfileInputModel model = new ProfileInputModel(profile);

            return View(model);
        }

        //
        // POST: /Profile/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, ProfileInputModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Profile profile = _provider.GetProfileByID(Guid.Parse(id));

                    profile.Username = model.Username;
                    profile.Name = model.Name;
                    profile.Surname = model.Surname;
                    profile.Email = model.Email;
                    profile.DateOfBirth = model.DateOfBirth;
                    profile.Address = new Address()
                    {
                        Street = model.Address.Street,
                        City = model.Address.City,
                        PostalCode = model.Address.PostalCode
                    };
                    profile.Gender = model.Gender;
                    profile.Description = model.Description;

                    _provider.Update(profile);

                    return RedirectToAction("Index");
                }
            }
            catch {}

            return View();
        }

        //
        // GET: /Profile/Delete/5
        public ActionResult Delete(string id)
        {
            var profile = _provider.GetProfileByID(Guid.Parse(id));

            ProfileViewModel model = new ProfileViewModel(profile);

            return View(model);
        }

        //
        // POST: /Profile/Delete/5
        [HttpPost]
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