using System;
using System.Collections.Generic;

namespace ToDoListApp
{
    class Program
    {
        //Lista que almacena las tareas
        static List<Tarea> listaDeTareas = new List<Tarea>();

        static void Main(string[] args)
        {
            MostrarMenu();
        }
        // Método para mostrar el menú y manejar la interacción con el usuario
        static void MostrarMenu()
        {
            while (true)
            {
                Console.WriteLine("To-Do List Q10");
                Console.WriteLine("1- Agregar Tarea");
                Console.WriteLine("2- Listar Tareas");
                Console.WriteLine("3- Marcar Tarea como Completada");
                Console.WriteLine("4- Eliminar Tarea");
                Console.WriteLine("0- SALIR");
                Console.Write("\nSeleccione una opción: ");

                //Leer la opcion seleccionada por el usuario
                string opcion = Console.ReadLine();

                //Ejecución de la accion seleccionada
                switch (opcion)
                {
                    case "1":
                        AgregarTarea();
                        break;
                    case "2":
                        ListarTareas();
                        break;
                    case "3":
                        MarcarTareaComoCompletada();
                        break;
                    case "4":
                        EliminarTarea();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
        //Método para agregar una tarea
        static void AgregarTarea()
        {
            //Solicitar la descripción de la tarea
            Console.Write("Ingrese la descripción de la tarea: ");
            string descripcion = Console.ReadLine();

            //Solicitar fecha limite Opcional
            Console.Write("Ingrese la fecha límite (opcional, formato: dd/MM/yyyy) o presione Enter para omitir: ");
            DateTime? fechaLimite = null;
            string fechaInput = Console.ReadLine();
            if (DateTime.TryParse(fechaInput, out DateTime fecha))
            {
                fechaLimite = fecha;
            }
            //Crear y agregar tarea nueva
            Tarea nuevaTarea = new Tarea(descripcion, fechaLimite);
            listaDeTareas.Add(nuevaTarea);
            Console.WriteLine("Tarea agregada con éxito.\n");
        }
        //Método para listar las tareas
        static void ListarTareas()
        {
            Console.WriteLine("\nLista de Tareas:");
            if (listaDeTareas.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas.\n");
            }
            else
            {
                for (int i = 0; i < listaDeTareas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {listaDeTareas[i]}");
                }
                Console.WriteLine();
            }
        }
        //Método para marcar la tarea como completada
        static void MarcarTareaComoCompletada()
        {
            //Listar las tareas para que el usuario seleccione cual completar
            ListarTareas();
            Console.Write("Seleccione el número de la tarea a marcar como completada: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= listaDeTareas.Count)
            {
                listaDeTareas[indice - 1].MarcarComoCompletada();
                Console.WriteLine("Tarea marcada como completada.\n");
            }
            else
            {
                Console.WriteLine("Selección no válida.\n");
            }
        }
        //Método para elminar una tarea de la lista
        static void EliminarTarea()
        {
            ListarTareas();
            Console.Write("Seleccione el número de la tarea a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= listaDeTareas.Count)
            {
                listaDeTareas.RemoveAt(indice - 1);
                Console.WriteLine("Tarea eliminada.\n");
            }
            else
            {
                Console.WriteLine("Selección no válida.\n");
            }
        }
    }
}

