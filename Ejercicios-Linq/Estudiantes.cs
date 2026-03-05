using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_Linq
{
    public class Estudiantes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
        public string Career { get; set; }


      static void Main(string[] args)
      {
            var estudiantes = new List<Estudiantes> {
            new Estudiantes { Id = 1, Name = "Ana López", Age = 20, Grade = 88, Career = "Ingenieria" },
            new Estudiantes { Id = 2, Name = "Luis García", Age = 16, Grade = 55, Career = "Contabilidad" },
            new Estudiantes { Id = 3, Name = "María Pérez", Age = 22, Grade = 72, Career = "Ingeniería" },
            new Estudiantes { Id = 4, Name = "Carlos Ruiz", Age = 17, Grade = 68, Career = "Diseño" },
            new Estudiantes { Id = 5, Name = "Sara Molina", Age = 19, Grade = 91, Career = "Contabilidad" },
            new Estudiantes { Id = 6, Name = "Pedro Castro", Age = 21, Grade = 43, Career = "Diseño" },
            new Estudiantes { Id = 7, Name = "Tomás Vargas", Age = 18, Grade = 76, Career = "Ingenieria" },
            new Estudiantes { Id = 8, Name = "Lucía Fernández", Age = 20, Grade = 5, Career = "Ingenieria" }
            };


            // Estudiantes mayores de edad arfabeticamente
            var MayorEdad = estudiantes
                .Where(e => e.Age >= 18) 
                .OrderBy(e => e.Name ?? string.Empty, StringComparer.CurrentCultureIgnoreCase)
                .ToList();

            foreach (var m in MayorEdad)
            {
                Console.WriteLine($"Eestudiantes mayores de edad; Nombre: {m.Name}, Edad: {m.Age}");
            }
            Console.WriteLine("=============================================");

            //Lista de estudiantes aprovado  >= 70  ordenados de mayor a menor calificación.
            var Aprovados = estudiantes
                .Where(e => e.Grade >= 70)
                .OrderByDescending(e=> e.Grade)
                .ThenBy(e=> e.Name ?? string.Empty, StringComparer.CurrentCultureIgnoreCase)
                .ToList();

            foreach (var a in Aprovados) {

                Console.WriteLine("");
                Console.WriteLine($"Nombre {a.Name}, : {a.Grade}");
            
            }
            Console.WriteLine("===============================================");
            //Ahora encontraremos el estudiante con el ID = 5 utilizando el FirstOrDefault mostrando su nombre y su carrera 

            var EstudianteId = estudiantes.FirstOrDefault(e => e.Id == 5);

            if (EstudianteId != null) {

                Console.WriteLine($"ID: {EstudianteId.Id},Nombre: {EstudianteId.Name},Carrera:{EstudianteId.Career}");
            }
            Console.WriteLine("=============================");
            //ejercicio4: Muestra cuántos estudiantes hay en la carrera de "Ingeniería" y cuál es su promedio de notas.


            var CarrerEstudiantes = estudiantes.Where(e => string.Equals(e.Career, "Ingenieria",StringComparison.OrdinalIgnoreCase));

            if (CarrerEstudiantes != null) {
                Console.WriteLine($"Total de estudiantes en Ingeniería: {CarrerEstudiantes.Count()}");
                Console.WriteLine($"Promedio de notas: {CarrerEstudiantes.Average(e => e.Grade)}");
            }

            Console.WriteLine("================================================");

            // ejercicio5: filtra los estudiantes mayores de edad, aprobados, y muestra solo su nombre ordenado A–Z.
            var EstudianteOrdenados = estudiantes
                .Where(s => s.Age >= 18 && s.Grade >= 70)
                .Select(s => s.Name ?? string.Empty) // evita nulls
                .Distinct(StringComparer.CurrentCultureIgnoreCase) // opcional: elimina duplicados
                .OrderBy(name => name) // orden culturalmente correcto
                .ToList(); // fuerza evaluación

            foreach (var nombre in EstudianteOrdenados)
            {
                Console.WriteLine($"Nombre: {nombre}");
            }
            

      }

    }
}


