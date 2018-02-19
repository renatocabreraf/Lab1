﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploLab1.DBContext;
using EjemploLab1.Models;
using System.Net;
using System.IO;
using System.Data;
using LumenWorks.Framework.IO.Csv;

namespace EjemploLab1.Controllers
{

    public class PersonaController : Controller
    {

        DefaultConnection db = DefaultConnection.getInstance;
      
    
        // GET: /Persona/
        public ActionResult Index()
        {
            return View(db.Personas.ToList());
        }

        //
        // GET: /Persona/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Persona personaBuscada = db.Personas.FirstOrDefault(x => x.PersonaID == id);

            if (personaBuscada == null)
            {
                return HttpNotFound();
            }

            return View(personaBuscada);
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
        public ActionResult Create([Bind(Include = "PersonaID,Nombre,Apellido,Edad,Salario,Club,Posicion")] Persona persona)
        {
            try
            {
                // TODO: Add insert logic here
                persona.PersonaID = ++db.IDActual;
                db.Personas.AddLast(persona);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Persona/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Persona personaBuscada = db.Personas.FirstOrDefault(x => x.PersonaID == id);

            if (personaBuscada == null) {
                return HttpNotFound();
            }

            return View(personaBuscada);
        }

        //
        // POST: /Persona/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonaID,Nombre,Apellido,Edad,Salario,Club,Posicion")]Persona persona)
        {
            try
            {
                Persona personaBuscada = db.Personas.FirstOrDefault(x => x.PersonaID == persona.PersonaID);
                if (personaBuscada == null)
                {
                    return HttpNotFound();
                }
                personaBuscada.Nombre = persona.Nombre;
                personaBuscada.Apellido = persona.Apellido;
                personaBuscada.Club = persona.Club;
                personaBuscada.Posicion = persona.Posicion;
                personaBuscada.Salario = persona.Salario;

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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Persona personaBuscada = db.Personas.FirstOrDefault(x => x.PersonaID == id);

            if (personaBuscada == null)
            {
                return HttpNotFound();
            }

            return View(personaBuscada);
        }

        //
        // POST: /Persona/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Persona personaBuscada = db.Personas.FirstOrDefault(x => x.PersonaID == id);

                if (personaBuscada == null)
                {
                    return HttpNotFound();
                }

                db.Personas.Remove(personaBuscada);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        /// <summary>
        /// GET UPLOAD
        /// </summary>
        /// <returns></returns>
        public ActionResult Upload()
        {
            return View();
        }
        /// <summary>
        /// Se sube un archivo
        /// </summary>
        /// <param name="upload"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload.FileName.EndsWith(".csv"))
                    {
                        Stream stream = upload.InputStream;
                        DataTable csvTable = new DataTable();
                        using (CsvReader csvReader =
                            new CsvReader(new StreamReader(stream), true))
                        {
                            csvTable.Load(csvReader);
                        }
                        DataRow[] currentRows = csvTable.Select(
    null, null, DataViewRowState.CurrentRows);
                        if (currentRows.Length < 1)
                            Console.WriteLine("No Current Rows Found");
                        else
                        {
                            string fila;
                            foreach (DataRow row in currentRows)
                            {
                                foreach (DataColumn column in csvTable.Columns)
                                     fila = row.ToString();

                            }
                        }
                        return View(csvTable);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }
    }
}
