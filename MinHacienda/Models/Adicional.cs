using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinHacienda.Models
{
    public class Adicional : Auditoria
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Nombre { get; set; }
        public int Valor { get; set; }
    }
}
