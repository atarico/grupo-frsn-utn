using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechInnovation.Enums;

namespace TechInnovation.Modelos
{
    public abstract class Proyecto
    {
        public string Nombre { get; set; }
        public abstract DateOnly TiempoEstimado();
    }
}