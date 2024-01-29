using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion_de_tareas.Model
{
 
    public class MLista { 
        public string IdTarea { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public bool FechaAtrasada
        {
            get
            {
                return DateTime.Today >= FechaFinal;
            }
        }
        
        
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
    }






}
