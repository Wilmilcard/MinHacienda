using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinHaciendaDomain.Models
{
    public class Inscripcion : Auditoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("InscripcionId")]
        public int InscripcionId { get; set; }
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public DateTime FechaInscripcion { get; set; }

        // Relaciones
        public virtual Estudiante Estudiante { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
