using System;

class Program
{
    static void Main(string[] args)
    {
        
        Libreria miLibreria = new Libreria();
        bool salir = false;

        Console.WriteLine("--- Bienvenido al Sistema de Gestión de Librería ---");

        while (!salir)
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Mostrar todos los libros");
            Console.WriteLine("3. Modificar libro");
            Console.WriteLine("4. Eliminar libro");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    miLibreria.Registrar();
                    break;
                case "2":
                    miLibreria.Mostrar();
                    break;
                case "3":
                    miLibreria.Modificar();
                    break;
                case "4":
                    miLibreria.Eliminar();
                    break;
                case "5":
                    salir = true;
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }
}
