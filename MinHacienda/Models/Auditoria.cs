using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinHacienda.Models
{
    public class Auditoria
    {
        public DateTime Creado { get; set; }
        public string CreadoPor { get; set; }
        public DateTime Actualizado { get; set; }
    }
}
