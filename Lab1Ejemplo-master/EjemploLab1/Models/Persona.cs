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

<<<<<<< HEAD
        [Required (AllowEmptyStrings = false, ErrorMessage = "Se necesita un Club")]
=======
        [Required(AllowEmptyStrings = false, ErrorMessage="Se necesita un nombre")]
>>>>>>> aca57b5dc7b089c3231ccd82c7241bb3b0161a45

        public string Club { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita un Apellido")]

        public string Apellido { get; set; }

<<<<<<< HEAD
        [Required(AllowEmptyStrings = false, ErrorMessage = "Se necesita un Nombre")]

        public string Nombre { get; set; }

        [Display (Name = "Posici[on dentro del campo")]

        public string Posicion { get; set; }

        [Range (1000,10000000000)]

=======
        public string Nombre { get; set; }

        public string Posicion { get; set; }

>>>>>>> aca57b5dc7b089c3231ccd82c7241bb3b0161a45
        public double Salario { get; set; }
    }
}