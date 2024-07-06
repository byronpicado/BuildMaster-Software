using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Habilidad_Personal

    {

        public int id_habilidad_personal { get; set; }

        public String codigo {  get; set; }
        public int idPersonalProyecto { get; set; }
        public int idProyecto { get; set; }
        public int idCliente {  get; set; }
        public int idResponsable { get; set; }

        public int id_personal { get; set; }

        public int Id_habilidad { get; set; }

        //Constructor sin parametros
        public Habilidad_Personal() { }  
        //Constructor con parametros
        public Habilidad_Personal(int idHabilidadPersonal,string codigo, int idPersonalProyecto, int idProyecto, int idCliente, int idResponsable, int idPersonal, int idHabilidad)

        {

            this.id_habilidad_personal = idHabilidadPersonal;

            this.codigo = codigo;

            this.idPersonalProyecto = idPersonalProyecto;

            this.idProyecto = idProyecto;

            this.idCliente = idCliente;

            this.idResponsable = idResponsable;


            this.id_personal = idPersonal;

            this.Id_habilidad = idHabilidad;

        }

    }
}
