using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Recurso

    {

        public int id_recurso { get; set; }
        public string codigo { get; set; }    

        public string tipo { get; set; }

        public string descripcion { get; set; }

        public decimal costo { get; set; }

        //Constructor sin parametros
        public Recurso() { }
        //Constructor con parametros
        public Recurso(int idRecurso, string codigo,string tipo, string descripcion, decimal costo)

        {

            this.id_recurso = idRecurso;
            this.codigo = codigo;

            this.tipo = tipo;

            this.descripcion = descripcion;

            this.costo = costo;

        }

    }
}
