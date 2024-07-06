using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Progreso

    {

        public int id_progreso { get; set; }
        public string codigo { get; set; }  

        public string descripcion { get; set; }

        public DateTime fecha_registro { get; set; }

        //Constructor sin parametros
        public Progreso() { }
        //Constructor con parametros
        public Progreso(int idProgreso,string codigo, string descripcion, DateTime fechaRegistro)

        {

            this.id_progreso = idProgreso;
            this.codigo = codigo;

            this.descripcion = descripcion;

            this.fecha_registro = fechaRegistro;

        }

    }
}
