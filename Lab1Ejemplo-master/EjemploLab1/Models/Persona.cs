using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploLab1.Models
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }

        [Required (AllowEmptyStrings = false, ErrorMessage = "Se necesita un Club")]

        public string Club { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita un Apellido")]

        public string Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita un Nombre")]

        public string Nombre { get; set; }

        [Display (Name = "Posici[on dentro del campo")]

        public string Posicion { get; set; }

        [Range (1000,10000000000)]

        public double Salario { get; set; }
    }
}