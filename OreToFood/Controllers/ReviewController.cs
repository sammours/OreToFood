using OreToFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OreToFood.Controllers
{
    public class ReviewController : Controller
    {
        OdeToFoodDB _db = new OdeToFoodDB();
        // GET: Review
        public ActionResult Index([Bind(Prefix = "id")] int restuarantID)
        {
            var restuarant = _db.Restuarants.Where(r => r.Id == restuarantID).First();
            if(restuarant != null)
            {
                return View(restuarant);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var model = _db.RestuarantReviews.Where(x => x.ID == id).First();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create(int restuarantID)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestuarantReview review)
        {
            if(ModelState.IsValid)
            {
                _db.RestuarantReviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = 5});
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.RestuarantReviews.Where(x => x.ID == id).First();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RestuarantReview review)
        {
            if(ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = 5});
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _db.RestuarantReviews.Where(x => x.ID == id).First();
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(RestuarantReview review)
        {
            if(ModelState.IsValid)
            {
                var _temp = _db.RestuarantReviews.Where(x => x.ID == review.ID).First();
                _db.RestuarantReviews.Remove(_temp);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = 5 });
            }
            return View(review);
        }
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}