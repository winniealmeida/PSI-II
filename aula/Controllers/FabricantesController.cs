﻿using aula.App_Start.Models;
using aula.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace aula.Controllers
{
    public class FabricantesController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(
                //fabricantes
                context.Fabricantes.OrderBy(c => c.Nome)
                );
        }

        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            //fabricante.FabricanteId = fabricantes.Select(m => m.FabricanteId).Max() + 1;
            context.Fabricantes.Add(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Fabricantes/Edit/5
        [HttpGet]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Fabricante fabricante = fabricantes.Where(m => m.FabricanteId == id).First();
 
            Fabricante fabricante = context.Fabricantes.Find(id);

            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        // POST: Fabricantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                context.Entry(fabricante).State = EntityState.Modified;
                context.SaveChanges();
                //fabricantes.Remove(
                    //fabricantes.Where(c => c.FabricanteId == fabricante.FabricanteId).First());
                //fabricantes.Add(fabricante);
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }

        // GET: Fabricantes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            //Fabricante fabricante = fabricantes.Where(m => m.FabricanteId == id).First();
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        // GET: Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            //Fabricante fabricante = fabricantes.Where(m => m.FabricanteId == id).First();
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fabricante fabricante = context.Fabricantes.Find(id);
            //Fabricante fabricante = fabricantes.Where(m => m.FabricanteId == id).First();
            context.Fabricantes.Remove(fabricante);
            //fabricantes.Remove(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}