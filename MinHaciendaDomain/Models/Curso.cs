using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinHaciendaDomain.Models
{
    public class Curso : Auditoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("CursoId")]
        public int CursoId { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Creditos { get; set; }

        // Relaciones
        public virtual List<Inscripcion> Inscripciones { get; set; }
        public virtual List<Asignacion> Asignaciones { get; set; }
    }
}
