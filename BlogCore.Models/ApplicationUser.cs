using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage ="El nombre es Obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La direccion es obligatoria")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La ciudad es Obligatoria")]
        public string Ciudad { get; set; }
        
        [Required(ErrorMessage = "El Pais es Obligatorio")]
        public string Pais { get; set; }

    }
}
