using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinHaciendaDomain.Models
{
    public class Asignacion : Auditoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("AsignacionId")]
        public int AsignacionId { get; set; }
        public int ProfesorId { get; set; }
        public int CursoId { get; set; }
        public string Semestre { get; set; }

        // Relaciones
        public virtual Profesor Profesor { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
