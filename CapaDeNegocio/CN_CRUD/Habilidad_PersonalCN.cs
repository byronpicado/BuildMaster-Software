using CapaDeDatos.CRUD;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.CN_CRUD
{
    public class Habilidad_PersonalCN
    {
        private Habilidad_PersonalCD habilidad_PersonalCD = new Habilidad_PersonalCD();
        public DataTable ObetenerHabilidad_Personal()
        {
            DataTable tabla = new DataTable();
            tabla = habilidad_PersonalCD.ObtenerHabilidad_Personal();
            return tabla;
        }
        //pasar a capa de datos
        public bool Insertar(Habilidad_Personal habilidad_Personal)
        {
            return habilidad_PersonalCD.Insertar(habilidad_Personal);
        }
        public bool Editar(Habilidad_Personal habilidad_Personal)
        {
            return habilidad_PersonalCD.Editar(habilidad_Personal);
        }

        public bool Eliminar(int habilidad_personalId)
        {
            return habilidad_PersonalCD.Eliminar(habilidad_personalId);
            return false;
        }
    }
}
