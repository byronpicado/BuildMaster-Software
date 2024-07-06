using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RptProyecto
    {
        String Codigo {  get; set; }

        public RptProyecto()
        {
            
        }
    public   RptProyecto(String codigo)
        {
            Codigo = codigo;
        }
    }

    
}
