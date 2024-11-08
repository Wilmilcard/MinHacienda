using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinHacienda.Models
{
    public class Helado : Auditoria
    {
        public int Id { get; set; }
        public string Sabor { get; set; }
        public int Valor { get; set; }
        public int Inventario { get; set; }

        public Helado(int _id, string _sabor, int _valor, int _invent)
        {
            Id = _id;
            Sabor = _sabor.ToUpper();
            Valor = _valor * 2;
            Inventario = _invent;
        }

        public Helado()
        {

        }
    }
}
