using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tarea

    {

        public int id_tarea { get; set; }

        public string codigo { get; set; }
        public string descripcion { get; set; }

        public DateTime fecha_inicio { get; set; }

        public DateTime? fecha_fin { get; set; }

        public string estado { get; set; }


        //Constructor sin parametros
        public Tarea() { }
        //Constructor con parametros 

        public Tarea(int idTarea,string codigo, string descripcion, DateTime fechaInicio, DateTime? fechaFin, string estado)

        {

            this.id_tarea = idTarea;
            this.codigo = codigo;

            this.descripcion = descripcion;

            this.fecha_inicio = fechaInicio;

            this.fecha_fin = fechaFin;

            this.estado = estado;

        }

    }
}
