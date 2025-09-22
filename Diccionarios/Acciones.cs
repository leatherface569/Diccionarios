using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionarios
{
    internal class Acciones
    {
        public string Nombre { get; set; }

        public int Matricula { get; set; }

        // Cambié el tipo de Dictionary para que la clave sea la matrícula (int) y el valor el nombre (string)
        private Dictionary<int, string> StudentsDictionary = new Dictionary<int, string>();

        public void AddStudents()
        {
            Console.WriteLine("Dame matricula");
            int matricula = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dame nombre");
            string nombre = Console.ReadLine();
            StudentsDictionary.Add(matricula, nombre);
        }

        // Remover por matrícula
        public bool RemoverPorMatricula(int matricula)
        {
            return StudentsDictionary.Remove(matricula);
        }

        // Actualizar por matrícula
        public bool ActualizarPorMatricula(int matricula, string nuevoNombre)
        {
            if (StudentsDictionary.ContainsKey(matricula))
            {
                StudentsDictionary[matricula] = nuevoNombre;
                return true;
            }
            return false;
        }

        // Mostrar todos los estudiantes
        public void Mostrar()
        {
            foreach (var estudiante in StudentsDictionary)
            {
                Console.WriteLine($"Matrícula: {estudiante.Key}, Nombre: {estudiante.Value}");
            }
        }

        // Buscar por matrícula
        public string BuscarPorMatricula(int matricula)
        {
            if (StudentsDictionary.TryGetValue(matricula, out string nombre))
            {
                return nombre;
            }
            return null;
        }

        // Contar estudiantes
        public int Contar()
        {
            return StudentsDictionary.Count;
        }
    }
}
