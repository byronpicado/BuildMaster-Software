using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MantenimientoEquipo

    {

        public int id_mantenimiento_Equipo { get; set; }
        public string codigo {  get; set; }

        public int id_mantenimiento { get; set; }

        public int id_equipo { get; set; }

        //Constructor sin parametros
        public MantenimientoEquipo() { }
        //Constructor con parametros
        public MantenimientoEquipo(int idMantenimientoEquipo, string codigo,int idMantenimiento, int idEquipo)

        {

            this.id_mantenimiento_Equipo = idMantenimientoEquipo;
            this.codigo = codigo;

            this.id_mantenimiento = idMantenimiento;

            this.id_equipo = idEquipo;

        }

    }
}
