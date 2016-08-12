using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizApi.Models
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }
        public string PetName { get; set; }
        public string Raza { get; set; }
        //public virtual Propietario propietario { get; set; }
    }
}