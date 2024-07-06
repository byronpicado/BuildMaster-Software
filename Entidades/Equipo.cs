using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    namespace Entidades
    {
        public class Equipo

        {

            public int id_equipo { get; set; }
            public string codigo { get; set; }  

            public string tipo { get; set; }

            public string marca { get; set; }

            public DateTime fecha_adquisicion { get; set; }

            //Constructor sin parametros
            public Equipo() { }
            //Construcotr con parametros
            public Equipo(int idEquipo, string codigo ,string tipo, string marca, DateTime fechaAdquisicion)

            {

                this.id_equipo = idEquipo;
                this.codigo = codigo;

                this.tipo = tipo;

                this.marca = marca;

                this.fecha_adquisicion = fechaAdquisicion;

            }

        }
    }
}
