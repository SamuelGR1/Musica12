using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Musica12.Models;

namespace Musica12.Controllers
{
    public class tb_MUSICController : Controller
    {
        private musicas1Entities db = new musicas1Entities();

        // GET: tb_MUSIC
        public ActionResult Index()
        {
            return View(db.tb_MUSIC.ToList());
        }

        // GET: tb_MUSIC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_MUSIC tb_MUSIC = db.tb_MUSIC.Find(id);
            if (tb_MUSIC == null)
            {
                return HttpNotFound();
            }
            return View(tb_MUSIC);
        }

        // GET: tb_MUSIC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_MUSIC/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idmusica,titulo,autor,album,genero,fecha_lanzamiento,duracion")] tb_MUSIC tb_MUSIC)
        {
            if (ModelState.IsValid)
            {
                db.tb_MUSIC.Add(tb_MUSIC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_MUSIC);
        }

        // GET: tb_MUSIC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_MUSIC tb_MUSIC = db.tb_MUSIC.Find(id);
            if (tb_MUSIC == null)
            {
                return HttpNotFound();
            }
            return View(tb_MUSIC);
        }

        // POST: tb_MUSIC/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idmusica,titulo,autor,album,genero,fecha_lanzamiento,duracion")] tb_MUSIC tb_MUSIC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_MUSIC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_MUSIC);
        }

        // GET: tb_MUSIC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_MUSIC tb_MUSIC = db.tb_MUSIC.Find(id);
            if (tb_MUSIC == null)
            {
                return HttpNotFound();
            }
            return View(tb_MUSIC);
        }

        // POST: tb_MUSIC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_MUSIC tb_MUSIC = db.tb_MUSIC.Find(id);
            db.tb_MUSIC.Remove(tb_MUSIC);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
