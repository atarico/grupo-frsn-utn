
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frsn.utn.Enums;

namespace frsn.utn.Modelos
{
    public class ProyectoMovil : Proyecto
    {
        public string Nombre { get; set; }
        public TipoDesarrollo TipoDesarrollo { get; set; }
        private EstadoProyecto _estadoProyecto;
        public List<string> Plataformas { get; set; }
        public int CantDevelopers { get; set; }
        public DateOnly FechaInicio { get; set; }

        public ProyectoMovil(string nombre, int cantDevelopers, DateOnly fechaInicio)
        {
            Nombre = nombre;
            Plataformas = new List<string>();
            CantDevelopers = cantDevelopers;
            FechaInicio = fechaInicio;
        }
        public EstadoProyecto EstadoProyecto { get { return _estadoProyecto; } set { _estadoProyecto = value; } }

        public override DateOnly TiempoEstimado()
        {
            DateOnly tiempoEstimado = FechaInicio.AddDays(730);
            return tiempoEstimado;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}" +
                $"Tipo de Desarrollo: {TipoDesarrollo}" +
                $"Estado Actual del Proyecto: {EstadoProyecto}" +
                $"Cantidad de Desarrolladores: {CantDevelopers}" +
                $"Fecha de Inicio: {FechaInicio}" +
                $"Fecha Estimada de Finalizacion: {TiempoEstimado()}";
        }
        public void MostrarPlataformas()
        {
            foreach (var value in Plataformas)
            {
                Console.WriteLine(value);
            }
        }
    }
}
