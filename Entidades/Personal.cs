using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Personal

    {

        public int id_personal { get; set; }
        
        public string codigo { get; set; }
        public string nombre1 { get; set; }

        public string nombre2 { get; set; }

        public string apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; }

        public string cargo { get; set; }

        public DateTime fecha_contratacion { get; set; }

        //Constructor sin parametros
        public Personal() { }
        //Constructor con parametros
        public Personal(int idPersonal,string codigo, string nombre1, string nombre2, string apellidoPaterno, string apellidoMaterno, string cargo, DateTime fechaContratacion)

        {

            this.id_personal = idPersonal;
            this.codigo = codigo;

            this.nombre1 = nombre1;

            this.nombre2 = nombre2;

            this.apellidoPaterno = apellidoPaterno;

            this.apellidoMaterno = apellidoMaterno;

            this.cargo = cargo;

            this.fecha_contratacion = fechaContratacion;

        }

    }
}
