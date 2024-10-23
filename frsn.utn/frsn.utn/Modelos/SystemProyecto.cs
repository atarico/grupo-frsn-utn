using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechInnovation.Enums;
using TechInnovation.Modelos;

namespace TechInnovation.Modelos
{
    public class SystemProyectos
    {
        static List<ProyectoMovil> proyectosM = new List<ProyectoMovil>();
        static List<ProyectoWeb> proyectosW = new List<ProyectoWeb>();
        static List<TipoDesarrollo> desarrollos = new List<TipoDesarrollo>((TipoDesarrollo[])Enum.GetValues(typeof(TipoDesarrollo)));
        static List<EstadoProyecto> estados = new List<EstadoProyecto>((EstadoProyecto[])Enum.GetValues(typeof(EstadoProyecto)));

        static string archivoProyectosW = "proyectosW.txt";
        static string archivoProyectosM = "proyectosM.txt";
        static string SEPARADOR = ", ";

        public static void AgregarProyecto()
        {
            bool swich = true;
            TipoDesarrollo miDesarrollo = TipoDesarrollo.Web; // Caso Default para poder usar las variables que, en caso de no estar asignadas, no se puyeden usar
            while (swich)
            {
                Console.WriteLine("Ingrese que tipo de proyecto sera el nuevo proyecto (1 = Web o 2 = Movil): ");
                int miTipo = int.Parse(Console.ReadLine());
                if (miTipo == 1)
                {
                    miDesarrollo = TipoDesarrollo.Web;
                    swich = false;
                }
                else if (miTipo == 2)
                {
                    miDesarrollo = TipoDesarrollo.Movil;
                    swich = false;
                }
                else { Console.WriteLine("Has ingresado una opcion incorrecta."); }
            }
            Console.WriteLine("Ingrese el nombre del proyecto: ");
            string miNombre = Console.ReadLine();

            bool swich2 = true;
            EstadoProyecto miEstado = EstadoProyecto.Planificacion; // Caso Default para poder usar las variables que, en caso de no estar asignadas, no se puyeden usar.
            while (swich2)
            {
                Console.WriteLine("Ingrese el estado actual del proyecto (numero):\n" +
                    "[1] = Planificacion.\n" +
                    "[2] = Desarrollo.\n" +
                    "[3] = Pruebas.\n" +
                    "[4] = Completado.\n" +
                    "[5] = Cancelado.\n");
                int estadoElegido = int.Parse(Console.ReadLine());
                switch (estadoElegido)
                {
                    case 1:
                        miEstado = EstadoProyecto.Planificacion;
                        swich2 = false;
                        break;
                    case 2:
                        miEstado = EstadoProyecto.Desarrollo;
                        swich2 = false;
                        break;
                    case 3:
                        miEstado = EstadoProyecto.Pruebas;
                        swich2 = false;
                        break;
                    case 4:
                        miEstado = EstadoProyecto.Completado;
                        swich2 = false;
                        break;
                    case 5:
                        miEstado = EstadoProyecto.Cancelado;
                        swich2 = false;
                        break;
                    default:
                        Console.WriteLine("Has ingresado una opcion incorrecta.");
                        break;
                }
            }

            Console.WriteLine("Ingrese la cantidad de desarrolladores: ");
            int miCantDevelopers = int.Parse(Console.ReadLine());

            bool swich3 = true;
            DateOnly miFecha = new DateOnly(2004, 09, 04);
            while (swich3)
            {
                Console.WriteLine("Ingrese la fecha de inicio del proyecto(formato: yyyy-mm-dd):");
                string fechaString = Console.ReadLine();
                if (DateOnly.TryParse(fechaString, out miFecha)) { swich3 = false; }
                else { Console.WriteLine("Formato de fecha invalido."); }
            }

            if (miDesarrollo == TipoDesarrollo.Web)
            {
                Console.WriteLine("Ingrese el nombre de la tecnologia principal empleada: ");
                string miTecnologia = Console.ReadLine();
                ProyectoWeb miProyectoWeb = new ProyectoWeb(miNombre, miTecnologia, miCantDevelopers, miFecha);
                miProyectoWeb.TipoDesarrollo = miDesarrollo;
                miProyectoWeb.EstadoProyecto = miEstado;
                proyectosW.Add(miProyectoWeb);
            }
            else if (miDesarrollo == TipoDesarrollo.Movil)
            {
                List<string> misPlataformas = new List<string>();
                bool swich4 = true;
                while (swich4)
                {
                    Console.WriteLine("Ingrese una plataforma para agregar a la lista de plataformas objetivo: ");
                    string unaPlataforma = Console.ReadLine();
                    misPlataformas.Add(unaPlataforma);
                    Console.WriteLine("Deseas agregar otra plataforma? (ingresa numero) [1]Si  [2]No");
                    int elInput = int.Parse(Console.ReadLine());
                    if (elInput == 2) { swich4 = false; }
                }
                ProyectoMovil miProyectoMovil = new ProyectoMovil(miNombre, miCantDevelopers, miFecha);
                miProyectoMovil.TipoDesarrollo = miDesarrollo;
                miProyectoMovil.EstadoProyecto = miEstado;
                miProyectoMovil.Plataformas = misPlataformas;
                proyectosM.Add(miProyectoMovil);
            }
        }

        public static void ModificarProyecto()
        {
            Console.WriteLine("Vas a modificar un proyecto Web o uno Movil?\n" +
                "[1] Web\n" +
                "[2] Movil\n");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {

                Console.WriteLine("Ingrese el nombre del proyecto Web que desea modificar: ");
                string miProyecto = Console.ReadLine();
                ProyectoWeb proyectoChosen = proyectosW.Find(p => p.Nombre == miProyecto);

                if (proyectoChosen == null) { Console.WriteLine("El proyecto que ingresaste no existe."); }

                else
                {

                    Console.WriteLine("Que atributo del proyecto deseas cambiar?\n" +
                        "[1] Nombre\n" +
                        "[2] Estado Actual del Proyecto\n" +
                        "[3] Cantidad de Desarrolladores\n" +
                        "[4] Tecnologia Principal Asociada\n");

                    int opcionn = int.Parse(Console.ReadLine());
                    switch (opcionn)
                    {
                        case 1:
                            Console.WriteLine("Ingrese el nuevo nombre para el proyecto: ");
                            string nuevoNombre = Console.ReadLine();
                            proyectoChosen.Nombre = nuevoNombre;
                            break;

                        case 2:
                            bool swich5 = true;
                            while (swich5)
                            {
                                Console.WriteLine("Ingrese el nuevo estado actual del proyecto:\n" +
                                    "[1] = Planificacion.\n" +
                                    "[2] = Desarrollo.\n" +
                                    "[3] = Pruebas.\n" +
                                    "[4] = Completado.\n" +
                                    "[5] = Cancelado.\n");
                                int input = int.Parse(Console.ReadLine());
                                switch (input)
                                {
                                    case 1:
                                        proyectoChosen.EstadoProyecto = EstadoProyecto.Planificacion;
                                        swich5 = false;
                                        break;

                                    case 2:
                                        proyectoChosen.EstadoProyecto = EstadoProyecto.Desarrollo;
                                        swich5 = false;
                                        break;

                                    case 3:
                                        proyectoChosen.EstadoProyecto = EstadoProyecto.Pruebas;
                                        swich5 = false;
                                        break;

                                    case 4:
                                        proyectoChosen.EstadoProyecto = EstadoProyecto.Completado;
                                        swich5 = false;
                                        break;

                                    case 5:
                                        proyectoChosen.EstadoProyecto = EstadoProyecto.Cancelado;
                                        swich5 = false;
                                        break;

                                    default:
                                        Console.WriteLine("Ingresaste un numero fuera de rango.");
                                        break;
                                }
                            }
                            break;

                        case 3:
                            Console.WriteLine("Ingrese la nueva cantidad de desarrolladores: ");
                            int nuevaCantidad = int.Parse(Console.ReadLine());
                            proyectoChosen.CantDevelopers = nuevaCantidad;
                            break;

                        case 4:
                            Console.WriteLine("Ingrese el nombre de la nueva tecnologia principal asociada: ");
                            string nuevaTech = Console.ReadLine();
                            proyectoChosen.Tecnologia = nuevaTech;
                            break;

                    }

                }
            }
            else if (opcion == 2)
            {
                Console.WriteLine("Ingrese el nombre del proyecto Movil que desea modificar: ");
                string miProyecto = Console.ReadLine();
                ProyectoMovil proyectoChosen = proyectosM.Find(p => p.Nombre == miProyecto);

                if (proyectoChosen == null) { Console.WriteLine("El proyecto que ingresaste no existe."); }

                else
                {

                    Console.WriteLine("Que atributo del proyecto deseas cambiar?\n" +
                        "[1] Nombre\n" +
                        "[2] Estado Actual del Proyecto\n" +
                        "[3] Cantidad de Desarrolladores\n" +
                        "[4] Lista de Plataformas Objetivo\n");

                    int opcionn = int.Parse(Console.ReadLine());
                    switch (opcionn)
                    {
                        case 1:
                            Console.WriteLine("Ingrese el nuevo nombre para el proyecto: ");
                            string nuevoNombre = Console.ReadLine();
                            proyectoChosen.Nombre = nuevoNombre;
                            break;

                        case 2:
                            bool swich5 = true;
                            while (swich5)
                            {
                                Console.WriteLine("Ingrese el nuevo estado actual del proyecto:\n" +
                                    "[1] = Planificacion.\n" +
                                    "[2] = Desarrollo.\n" +
                                    "[3] = Pruebas.\n" +
                                    "[4] = Completado.\n" +
                                    "[5] = Cancelado.\n");
                                int inputt = int.Parse(Console.ReadLine());
                                switch (inputt)
                                {
                                    case 1:
                                        proyectoChosen.EstadoProyecto = EstadoProyecto.Planificacion;
                                        swich5 = false;
                                        break;

                                    case 2:
                                        proyectoChosen.EstadoProyecto = EstadoProyecto.Desarrollo;
                                        swich5 = false;
                                        break;

                                    case 3:
                                        proyectoChosen.EstadoProyecto = EstadoProyecto.Pruebas;
                                        swich5 = false;
                                        break;

                                    case 4:
                                        proyectoChosen.EstadoProyecto = EstadoProyecto.Completado;
                                        swich5 = false;
                                        break;

                                    case 5:
                                        proyectoChosen.EstadoProyecto = EstadoProyecto.Cancelado;
                                        swich5 = false;
                                        break;

                                    default:
                                        Console.WriteLine("Ingresaste un numero fuera de rango.");
                                        break;
                                }
                            }
                            break;

                        case 3:
                            Console.WriteLine("Ingrese la nueva cantidad de desarrolladores: ");
                            int nuevaCantidad = int.Parse(Console.ReadLine());
                            proyectoChosen.CantDevelopers = nuevaCantidad;
                            break;

                        case 4:
                            int input;
                            do
                            {
                                Console.WriteLine("Lista de Plataformas Actuales:\n");
                                proyectoChosen.MostrarPlataformas();
                                Console.WriteLine("Que quieres hacer?\n" +
                                    "[1] Borrar una plataforma de la lista.\n" +
                                    "[2] Agregar una plataforma nueva.\n" +
                                    "[3] Terminar las modificaciones.\n");
                                input = int.Parse(Console.ReadLine());
                                switch (input)
                                {
                                    case 1:
                                        Console.WriteLine("Ingrese el nombre de la plataforma a eliminar: ");
                                        string plataformaDelete = Console.ReadLine();
                                        proyectoChosen.Plataformas.Remove(plataformaDelete);
                                        break;

                                    case 2:
                                        Console.WriteLine("Ingrese el nombre de la plataforma a agregar: ");
                                        string nuevaPlataforma = Console.ReadLine();
                                        proyectoChosen.Plataformas.Add(nuevaPlataforma);
                                        break;

                                    default:
                                        Console.WriteLine("Ingresaste un numero fuera de rango.");
                                        break;
                                }
                            } while (input != 3);
                            break;
                    }
                }
            }
            else { Console.WriteLine("Has ingresado un numero fuera de rango."); }

        }
    }
}
