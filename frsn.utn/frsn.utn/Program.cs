using frsn.utn.Modelos;

class Program
{
    static void Main()
    {
        SystemProyectos.CargarDatos();
        int opcion;
        do
        {
            Console.WriteLine("==== Menu Opciones ====\n" +
                "1. Agregar un Nuevo Proyecto.\n" +
                "2. Mostrar Todos los Proyectos.\n" +
                "3. Modificar un Proyecto.\n" +
                "4. Eliminar un Proyecto.\n" +
                "5. Guardar los Cambios Realizados en esta Sesion.\n" +
                "6. Cargar los Datos del Archivo de Texto.\n" +
                "7. Salir.\n");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    SystemProyectos.AgregarProyecto();
                    break;

                case 2:
                    SystemProyectos.MostrarProyectos();
                    break;

                case 3:
                    SystemProyectos.ModificarProyecto();
                    break;

                case 4:
                    SystemProyectos.EliminarProyecto();
                    break;

                case 5:
                    SystemProyectos.GuardarCambios();
                    break;

                case 6:
                    SystemProyectos.CargarDatos();
                    break;
            }
        } while (opcion != 7);
    }
}