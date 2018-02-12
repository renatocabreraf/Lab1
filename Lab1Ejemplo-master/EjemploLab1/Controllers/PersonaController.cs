using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploLab1.DBContext;
using EjemploLab1.Models;
using System.Net;

namespace EjemploLab1.Controllers
{

    public class PersonaController : Controller
    {

        DefaultConnection db = DefaultConnection.getInstance;
       
        //
        // GET: /Persona/
        public ActionResult Index()
        {
            return View(db.Personas.ToList());
        }

        //
        // GET: /Persona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Persona/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "PersonaID,Nombre,Apellido,Edad")] Persona persona)
        {
            try
            {
                // TODO: Add insert logic here
                persona.PersonaID = ++db.IDActual;
                db.Personas.Add(persona);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Persona personaBuscada = db.Personas.Find(x => x.PersonaID == id);

            if (personaBuscada == null) {
                return HttpNotFound();
            }

            return View(personaBuscada);
        }

        //
        // POST: /Persona/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PersonaID,Nombre,Apellido,Edad")]Persona persona)
        {
            try
            {
                Persona personaBuscada = db.Personas.Find(x => x.PersonaID == persona.PersonaID);
                if (personaBuscada == null)
                {
                    return HttpNotFound();
                }
                personaBuscada.Nombre = persona.Nombre;
                personaBuscada.Apellido = persona.Apellido;
                personaBuscada.Edad = persona.Edad;

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        //
        // GET: /Persona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Persona/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
