using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploLab1.Models
{
    public class Persona
    {
       
        public int PersonaID { get; set; }


<<<<<<< HEAD
        

        public string Club { get; set; }

      

        public string Apellido { get; set; }

      

=======
   

        public string Club { get; set; }

        

        public string Apellido { get; set; }

     
>>>>>>> 2018a528e49a72d108338776f07a8e291e216187
        public string Nombre { get; set; }

       

        public string Posicion { get; set; }

       
        public double Salario { get; set; }
    }
}