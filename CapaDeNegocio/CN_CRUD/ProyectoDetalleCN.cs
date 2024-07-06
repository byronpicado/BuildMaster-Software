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
    public class ProyectoDetalleCN
    {
        private ProyectoDetalleCD proyectoDetalleCD = new ProyectoDetalleCD();
        public DataTable ObtenerProyectoDetalle()
        {
            DataTable tabla = new DataTable();
            tabla = proyectoDetalleCD.ObtenerProyectoDetalle();
                return tabla;
        }
        //pasar a capa de datos
        public bool Insertar(ProyectoDetalle proyectoDetalle)
        {
            return proyectoDetalleCD.Insertar(proyectoDetalle);
        }
        public bool Editar(ProyectoDetalle proyectoDetalle)
        {
            return proyectoDetalleCD.Editar(proyectoDetalle);
        }

        public bool Eliminar(int proyectoDetalleId)
        {
            return proyectoDetalleCD.Eliminar(proyectoDetalleId);
            return false;
        }
    }
}