using System;
using System.Collections.Generic;

namespace Registro_empleados
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            int siguienteId = 1;
            string opcion;

            do
            {
                opcion = LeerOpcionMenu();

                switch (opcion)
                {
                    case "1":
                        AgregarEmpleado(listaEmpleados, ref siguienteId);
                        break;
                    case "2":
                        ListarEmpleados(listaEmpleados);
                        break;
                    case "3":
                        BuscarEmpleado(listaEmpleados);
                        break;
                    case "4":
                        CalcularFactorialMenu();
                        break;
                    case "5":
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != "5");
        }

       
        private static string LeerOpcionMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== REGISTRO DE EMPLEADOS ===");
            Console.WriteLine("1. Agregar empleado");
            Console.WriteLine("2. Listar empleados");
            Console.WriteLine("3. Buscar empleado");
            Console.WriteLine("4. Calcular factorial");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");
            return Console.ReadLine()?.Trim();
        }

        
        private static void AgregarEmpleado(List<Empleado> lista, ref int id)
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Salario base: ");
            bool salarioOk = decimal.TryParse(Console.ReadLine(), out decimal salarioBase);

            Console.Write("Horas extra: ");
            bool horasOk = int.TryParse(Console.ReadLine(), out int horasExtra);

            if (string.IsNullOrWhiteSpace(nombre) || !salarioOk || salarioBase < 0 || !horasOk || horasExtra < 0)
            {
                Console.WriteLine("Datos inválidos.");
                return;
            }

            lista.Add(new Empleado
            {
                Id = id,
                Nombre = nombre,
                SalarioBase = salarioBase,
                HorasExtra = horasExtra
            });

            id++; 
            Console.WriteLine("Empleado agregado.");
        }

        private static void ListarEmpleados(List<Empleado> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            decimal totalNomina = 0;

            foreach (Empleado emp in lista)
            {
                Console.WriteLine(emp);
                totalNomina += emp.PagoTotal();
            }

            Console.WriteLine($"TOTAL DE NÓMINA: Q {totalNomina:N2}");
        }

        
        private static void BuscarEmpleado(List<Empleado> lista)
        {
            Console.Write("Nombre a buscar: ");
            string busqueda = Console.ReadLine()?.Trim().ToUpper() ?? "";

            bool encontrado = false;

            foreach (Empleado emp in lista)
            {
                if (emp.Nombre.ToUpper().Contains(busqueda))
                {
                    Console.WriteLine(emp);
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Sin coincidencias.");
            }
        }

       
        private static void CalcularFactorialMenu()
        {
            Console.Write("Número (entero, 0 o mayor): ");
            bool esValido = int.TryParse(Console.ReadLine(), out int n);

            if (!esValido || n < 0)
            {
                Console.WriteLine("Dato inválido.");
                return;
            }

            long resultado = Factorial(n);
            Console.WriteLine($"{n}! = {resultado}");
        }

       
        private static long Factorial(int n)
        {
            if (n <= 1) return 1; 
            return n * Factorial(n - 1); 
        }
    }
}