using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinHaciendaDomain.Models
{
    public class Auditoria
    {
        public DateTime Creado { get; set; }
        [MaxLength(100)]
        public string CreadoPor { get; set; }
        public DateTime Actualizado { get; set; }
    }
}
