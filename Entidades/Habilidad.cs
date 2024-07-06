using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Habilidad

    {
        public int id_habilidad { get; set; }
        public string codigo { get; set; }

        public string descripcion { get; set; }
        
        //Constructor sin parametros
        public Habilidad() { }


        //Constructor con parametros
        public Habilidad(string codigo,int id_habilidad, string descripcion)

        {

            this.codigo = codigo;
            this.id_habilidad= id_habilidad;
            this.descripcion = descripcion;

        }

    }
}
