using OreToFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OreToFood.Controllers
{
    public class RestuarantController : Controller
    {
        // GET: Restuarant
        OdeToFoodDB _db = new OdeToFoodDB();
        // GET: Contact

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Restuarants.Where(x => x.Name.StartsWith(term))
                .Take(10).Select(x => new { label = x.Name });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 10)]
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            //throw new HttpRequestValidationException();
            var model = (from r in _db.Restuarants
                         where r.Name.StartsWith(searchTerm) || searchTerm == null
                         orderby r.Reviews.Average(re => re.Rating) descending
                         select r).ToList().ToPagedList(page, 10);

            if(Request.IsAjaxRequest())
            {
                return PartialView("_Restuarant", model);
            }
            return View(model);
        }

        // GET: Contact/Details/5


        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(Restuarant restuarant)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _db.Restuarants.Add(restuarant);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(restuarant);
            }
            catch
            {
                return View(restuarant);
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _db.Restuarants.Where(x => x.Id == id).First();
            return View(model);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Restuarant restuarant)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _db.Entry(restuarant).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(restuarant);
            }
            catch
            {
                return View(restuarant);
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _db.Restuarants.Where(x => x.Id == id).First();
            return View(model);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Restuarant restuarant)
        {
            try
            {
                var _temp = _db.Restuarants.Where(x => x.Id == id).First();
                _db.Restuarants.Remove(_temp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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