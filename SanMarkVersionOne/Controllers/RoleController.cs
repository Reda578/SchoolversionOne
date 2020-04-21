using Microsoft.AspNet.Identity.EntityFramework;
using SanMarkVersionOne.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanMarkVersionOne.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Role
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: Role/Details/5
        public ActionResult Details(string id)
        {
            var detail = db.Roles.Find(id);
            if(detail==null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(IdentityRole iden)
        {
            try
            {
                // TODO: Add insert logic here

                if(ModelState.IsValid)
                {
                    db.Roles.Add(iden);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(iden);
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(string id)
        {
            var editRole = db.Roles.Find(id);
            if(editRole==null)
            {
                return HttpNotFound();
            }
            return View(editRole);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(IdentityRole editIden)
        {
            try
            {
                // TODO: Add update logic here
                if(ModelState.IsValid)
                {
                    db.Entry(editIden).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(editIden);

            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(string id)
        {
            var DelRole = db.Roles.Find(id);
            if(DelRole==null)
            {
                return HttpNotFound();
            }
            return View(DelRole);
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole idenDel)
        {
            try
            {
                // TODO: Add delete logic here
                var delWithId = db.Roles.Find(idenDel.Id);
                if(delWithId==null)
                {
                    return HttpNotFound();
                }
                db.Roles.Remove(delWithId);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
