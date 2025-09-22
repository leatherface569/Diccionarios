using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionarios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Acciones acciones = new Acciones();
            int opcion;
            do
            {
                Console.WriteLine("\n--- Menú de Estudiantes ---");
                Console.WriteLine("1. Agregar estudiante");
                Console.WriteLine("2. Remover por matrícula");
                Console.WriteLine("3. Actualizar por matrícula");
                Console.WriteLine("4. Mostrar todos");
                Console.WriteLine("5. Buscar por matrícula");
                Console.WriteLine("6. Contar estudiantes");
                Console.WriteLine("0. Salir");
                Console.Write("Selecciona una opción: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        acciones.AddStudents();
                        break;
                    case 2:
                        Console.Write("Matrícula a remover: ");
                        if (int.TryParse(Console.ReadLine(), out int matriculaRemover))
                        {
                            if (acciones.RemoverPorMatricula(matriculaRemover))
                                Console.WriteLine("Estudiante removido.");
                            else
                                Console.WriteLine("Matrícula no encontrada.");
                        }
                        break;
                    case 3:
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
                    case 4:
                        acciones.Mostrar();
                        break;
                    case 5:
                        Console.Write("Matrícula a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int matriculaBuscar))
                        {
                            string nombre = acciones.BuscarPorMatricula(matriculaBuscar);
                            if (nombre != null)
                                Console.WriteLine($"Nombre: {nombre}");
                            else
                                Console.WriteLine("Matrícula no encontrada.");
                        }
                        break;
                    case 6:
                        Console.WriteLine($"Total de estudiantes: {acciones.Contar()}");
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 0);
        }
    }
}
