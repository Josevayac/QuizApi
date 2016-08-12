using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizApi.Models
{
    public class Propietario
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }

        //public virtual IEnumerable<Mascota> mascotas { get; set; }  

    }
}