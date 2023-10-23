using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        [Display(Name = "CODIGO DE LA MATERIA")]
        public int IdMateria { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
        [Display(Name = "NOMBRE DE LA MATERIA")]
        public string Nombre { get; set; }


        [Required]
        [Display(Name = "COSTO DE LA MATERIA")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Range(1,1000)]
        public decimal? Costo { get; set; }
        public List<object> Materias { get; set; }
    }
}
