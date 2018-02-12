using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjemploLab1.Models
{
    public class Persona
    {
        public int PersonaID { get; set; }

        public string Club { get; set; }

        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Nombre { get; set; }
        public string Posicion { get; set; }
        public double Salario { get; set; }
    }
}