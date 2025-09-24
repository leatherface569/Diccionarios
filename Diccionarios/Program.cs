using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionarios
{
    enum MenuOpciones
    {
        Agregar = 1,
        Mostrar,
        Actualizar,
        Eliminar,
        Contar,
        Salir
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nombre del creador: ");
            string nombreCreador = Console.ReadLine();
            Console.Write("Matrícula del creador: ");
            int matriculaCreador = Convert.ToInt32(Console.ReadLine());

            Acciones acciones = new Acciones
            {
                Nombre = nombreCreador,
                Matricula = matriculaCreador
            };

            Console.WriteLine($"\nCreador: {acciones.Nombre} | Matrícula: {acciones.Matricula}");

            MenuOpciones opcion;
            do
            {
                Console.WriteLine("\n--- Menú de Opciones ---");
                Console.WriteLine("1. Agregar estudiante");
                Console.WriteLine("2. Mostrar estudiantes");
                Console.WriteLine("3. Actualizar estudiante");
                Console.WriteLine("4. Eliminar estudiante");
                Console.WriteLine("5. Contar estudiantes");
                Console.WriteLine("6. Salir");
                Console.Write("Selecciona una opción: ");

                int.TryParse(Console.ReadLine(), out int seleccion);
                opcion = (MenuOpciones)seleccion;

                switch (opcion)
                {
                    case MenuOpciones.Agregar:
                        acciones.AddStudents();
                        break;
                    case MenuOpciones.Mostrar:
                        acciones.Mostrar();
                        break;
                    case MenuOpciones.Actualizar:
                        Console.Write("Matrícula a actualizar: ");
                        if (int.TryParse(Console.ReadLine(), out int matriculaActualizar))
                        {
                            Console.Write("Nuevo nombre: ");
                            string nuevoNombre = Console.ReadLine();
                            if (acciones.ActualizarPorMatricula(matriculaActualizar, nuevoNombre))
                                Console.WriteLine("Estudiante actualizado.");
                            else
                                Console.WriteLine("Matrícula no encontrada.");
                        }
                        break;
                    case MenuOpciones.Eliminar:
                        Console.Write("Matrícula a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int matriculaEliminar))
                        {
                            if (acciones.RemoverPorMatricula(matriculaEliminar))
                                Console.WriteLine("Estudiante eliminado.");
                            else
                                Console.WriteLine("Matrícula no encontrada.");
                        }
                        break;
                    case MenuOpciones.Contar:
                        Console.WriteLine($"Total de estudiantes: {acciones.Contar()}");
                        break;
                    case MenuOpciones.Salir:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != MenuOpciones.Salir);
        }
    }
}
