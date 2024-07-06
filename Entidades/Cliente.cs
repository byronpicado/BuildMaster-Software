using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente

    {
       public int id_cliente {  get; set; }
        public string codigo { get; set; }  

        public string nombre1 { get; set; }

        public string nombre2 { get; set; }

        public string apellidoPaterno { get; set; }

        public string apellidoMaterno { get; set; }

        public string telefono { get; set; }

        public string correo { get; set; }
        public string nombreCompleto { get { return nombre1 + " " + apellidoPaterno; } }

        //Constructor sin parametros
        public Cliente() { }


        //Construtor con parametros 

        public Cliente(int id_cliente,string codigo, string nombre1, string nombre2, string apellidoPaterno, string apellidoMaterno, string telefono, string correo)

        {

            this.id_cliente = id_cliente;

            this.codigo =codigo;

            this.nombre1 = nombre1;

            this.nombre2 = nombre2;

            this.apellidoPaterno = apellidoPaterno;

            this.apellidoMaterno = apellidoMaterno;

            this.telefono = telefono;

            this.correo = correo;

        }

    }
}
