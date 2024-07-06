using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mantenimiento

    {

        public int id_mantenimiento { get; set; }
        public string codigo { get; set; }

        public DateTime fecha_mantenimiento { get; set; }

        public string descripcion { get; set; }

        //Constructor sin parametros
        public Mantenimiento() { }
        //Constructor con parametros
        public Mantenimiento(int id_mantenimiento, string codigo,DateTime fechaMantenimiento, string descripcion)

        {

            this.id_mantenimiento = id_mantenimiento;
            this.codigo = codigo;

            this.fecha_mantenimiento = fechaMantenimiento;

            this.descripcion = descripcion;

        }

    }
}
