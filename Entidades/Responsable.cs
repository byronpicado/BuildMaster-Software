using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Responsable

    {

        public int id_responsable { get; set; }
        public string codigo { get; set; }

        public string nombre1 { get; set; }

        public string nombre2 { get; set; }

        public string apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; }

        public string cargo { get; set; }

        //Cosntructor sin parametros
        public Responsable() { }
        //Constructor con parametros
        public Responsable(int idResponsable,string codigo, string nombre1, string nombre2, string apellidoPaterno, string apellidoMaterno, string cargo)

        {

            this.id_responsable = idResponsable;
            this.codigo = codigo;   

            this.nombre1 = nombre1;

            this.nombre2 = nombre2;

            this.apellidoPaterno = apellidoPaterno;

            this.apellidoMaterno = apellidoMaterno;

            this.cargo = cargo;

        }

    }
}
