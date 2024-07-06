using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProyectoDetalle

    {

        public int id_proyectoDetalle { get; set; }
        public string codigo {  get; set; }

        public int id_proyecto {  get; set; }   
        public int id_cliente { get; set; }
        public int id_responsable {  get; set; }
        public int id_recurso { get; set; }
        public int id_tarea { get; set; }
        public int id_progreso { get; set; }
        public int id_equipo {  get; set; }
        public string descripcion { get; set; }

        public DateTime fecha_registro { get; set; }
        public int id_personal_proyecto { get; set; }
        public int id_personal {  get; set; }



        //Csntructor sin parametros
        public ProyectoDetalle() { }
        //Constructor con parametros
        public ProyectoDetalle(int idProyectoDetalle, string codigo,int id_proyecto,int id_cliente,int id_responsable, int id_recurso, int id_tarea, int id_progreso,int id_equipo,string descripcion, DateTime fechaRegistro, int id_personal_proyecto,int id_personal)

        {

            this.id_proyectoDetalle = idProyectoDetalle;
            this.codigo = codigo;
            this.id_proyecto = id_proyecto; 
            this.id_cliente = id_cliente;
            this.id_responsable = id_responsable;   
            this.id_recurso = id_recurso;   
            this.id_tarea = id_tarea;   
            this.id_progreso = id_progreso; 
            this.id_equipo = id_equipo;
            

            this.descripcion = descripcion;

            this.fecha_registro = fechaRegistro;
            this.id_personal_proyecto= id_personal_proyecto;
            this.id_personal = id_personal;

        }

    }
}
