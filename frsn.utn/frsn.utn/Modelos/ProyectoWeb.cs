using frsn.utn.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frsn.utn.Modelos
{
    public class ProyectoWeb : Proyecto
    {
        public string Nombre { get; set; }
        public TipoDesarrollo TipoDesarrollo { get; set; }
        private EstadoProyecto _estadoProyecto;
        public string Tecnologia { get; set; }
        public int CantDevelopers { get; set; }
        public DateOnly FechaInicio { get; set; }

        public ProyectoWeb(string nombre, string tecnologia, int cantDevelopers, DateOnly fechaInicio)
        {
            Nombre = nombre;
            Tecnologia = tecnologia;
            CantDevelopers = cantDevelopers;
            FechaInicio = fechaInicio;
        }
        public EstadoProyecto EstadoProyecto { get { return _estadoProyecto; } set { _estadoProyecto = value; } }
        public override DateOnly TiempoEstimado()
        {
            DateOnly tiempoEstimado = FechaInicio.AddDays(365);
            return tiempoEstimado;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}" +
                $"Tipo de Desarrollo: {TipoDesarrollo}" +
                $"Estado Actual del Proyecto: {EstadoProyecto}" +
                $"Tecnologia Principal Asociada: {Tecnologia}" +
                $"Cantidad de Desarrolladores: {CantDevelopers}" +
                $"Fecha de Inicio: {FechaInicio}" +
                $"Fecha Estimada de Finalizacion: {TiempoEstimado()}";
        }
    }
}
