using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploLab1.DBContext;
using EjemploLab1.Models;
using System.Net;
using System.IO;

namespace EjemploLab1.Controllers
{

    public class PersonaController : Controller
    {

        DefaultConnection db = DefaultConnection.getInstance;
       
        
        [HttpPost]  
       public ActionResult LoadCSV(HttpPostedFileBase postedFile)  
       {  
           List<Persona> personas = new List<Persona>();
           string filePath = string.Empty;  
           if (postedFile != null)  
           {  
               string path = Server.MapPath("~/Uploads/");  
               if (!Directory.Exists(path))  
               {  
                   Directory.CreateDirectory(path);  
               }  
               filePath = path + Path.GetFileName(postedFile.FileName);  
               string extension = Path.GetExtension(postedFile.FileName);  
               postedFile.SaveAs(filePath);  
  
               string csvData = System.IO.File.ReadAllText(filePath);  
               foreach(string row in csvData.Split(' '))  
               {  
                   if (!string.IsNullOrEmpty(row))  
                   {
                       personas.Add(new Persona
                       {
                           PersonaID = Convert.ToInt32(row.Split(',')[0]),
                           Club = row.Split(',')[1],
                           Apellido = (row.Split(',')[2]),
                           Nombre = row.Split(',')[3],
                           Posicion = row.Split(',')[4],
                           Salario = Convert.ToDouble(row.Split(',')[5]),
                       });
                   }  
               }  
           }  
           return View();  
       }
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
        public ActionResult Create([Bind(Include = "PersonaID,Nombre,Apellido,Edad,Salario,Club,Posicion")] Persona persona)
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
        public ActionResult Edit([Bind(Include = "PersonaID,Nombre,Apellido,Edad,Salario,Club,Posicion")]Persona persona)
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

            Persona personaBuscada = db.Personas.Find(x => x.PersonaID == id);

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

                Persona personaBuscada = db.Personas.Find(x => x.PersonaID == id);

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
    }
}
