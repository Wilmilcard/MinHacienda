using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinHaciendaDomain.Models
{
    public class Profesor : Auditoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("ProfesorId")]
        public int ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Departamento { get; set; }

        // Relaciones
        public virtual List<Asignacion> Asignaciones { get; set; }
    }
}
