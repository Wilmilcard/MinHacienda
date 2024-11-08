using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinHacienda.Models
{
    public class Factura : Auditoria
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public int Codigo { get; set; }
        public List<Helado> DetalleHelados { get; set; }
        public List<Adicional> DetalleAdicionales { get; set; }
        public int Total { get; set; }
    }
}
