using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Personal_Proyecto

    {

        public int id_Personal_proyecto { get; set; }
        public string codigo { get; set; }

        public int id_proyecto { get; set; }

        public int id_cliente { get; set; }

        public int id_responsable { get; set; }

        public int id_personal { get; set; }

        //Constructor sin parametros
        public Personal_Proyecto() { }
        //Constructor con parametros
        public Personal_Proyecto(int idPersonalProyecto,string codigo, int idProyecto, int idCliente, int idResponsable, int idPersonal)

        {

            this.id_Personal_proyecto = idPersonalProyecto;

            this.codigo = codigo;

            this.id_proyecto = idProyecto;

            this.id_cliente = idCliente;

            this.id_responsable = idResponsable;

            this.id_personal = idPersonal;

        }

    }
}
