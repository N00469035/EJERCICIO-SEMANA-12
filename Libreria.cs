using System;

public class Libreria
{
    private string[] nombres = new string[0];
    private decimal[] precios = new decimal[0];

    
    private int BuscarIndice(string nombreABuscar)
    {
        for (int i = 0; i < nombres.Length; i++)
        {
            
            if (nombres[i].ToUpper() == nombreABuscar.ToUpper())
            {
                return i; 
            }
        }
        return -1; 
    }

    
    public void Registrar()
    {
        Console.WriteLine("\n-> Registrar Libro");
        string nombre;
        decimal precio;

        
        while (true)
        {
            Console.Write("Nombre del libro: ");
            nombre = Console.ReadLine();

            
            if (nombre == null || nombre.Length == 0)
            {
                Console.WriteLine("Error: El nombre no puede ser vacío o nulo.");
                continue;
            }

            if (BuscarIndice(nombre) != -1)
            {
                Console.WriteLine("Error: Ese libro ya existe.");
                continue;
            }

            break; 
        }

        
        while (true)
        {
            Console.Write("Precio del libro (entre 0 y 1000): ");
            if (!decimal.TryParse(Console.ReadLine(), out precio) || precio < 0 || precio > 1000)
            {
                Console.WriteLine("Error: Precio inválido.");
            }
            else
            {
                break;
            }
        }

        
        string[] tempNombres = new string[nombres.Length + 1];
        decimal[] tempPrecios = new decimal[precios.Length + 1];

        for (int i = 0; i < nombres.Length; i++)
        {
            tempNombres[i] = nombres[i];
            tempPrecios[i] = precios[i];
        }

        tempNombres[nombres.Length] = nombre;
        tempPrecios[precios.Length] = precio;

        nombres = tempNombres;
        precios = tempPrecios;


        Console.WriteLine("¡Libro registrado!");
    }

    
    public void Mostrar()
    {
        Console.WriteLine("\n-> Lista de Libros");
        if (nombres.Length == 0)
        {
            Console.WriteLine("No hay libros registrados.");
            return;
        }

        for (int i = 0; i < nombres.Length; i++)
        {
            Console.WriteLine($"- {nombres[i]} | Precio: {precios[i]:C}");
        }
    }

    
    public void Modificar()
    {
        Console.WriteLine("\n-> Modificar Libro");
        Console.Write("Escribe el nombre del libro que quieres cambiar: ");
        string nombreBuscar = Console.ReadLine();

        int indiceEncontrado = BuscarIndice(nombreBuscar);

        if (indiceEncontrado == -1)
        {
            Console.WriteLine("Error: Ese libro no existe.");
            return;
        }

        
        Console.Write("Escribe el NUEVO nombre: ");
        string nuevoNombre;
        while (true)
        {
            nuevoNombre = Console.ReadLine();

            
            if (nuevoNombre == null || nuevoNombre.Length == 0)
            {
                Console.WriteLine("Error: El nombre no puede ser vacío. Intenta de nuevo:");
                continue;
            }

            
            int indiceNuevoNombre = BuscarIndice(nuevoNombre);
            
            if (indiceNuevoNombre != -1 && indiceNuevoNombre != indiceEncontrado)
            {
                Console.WriteLine("Error: Ya hay OTRO libro con ese nombre. Intenta de nuevo:");
                continue;
            }
            break; 
        }


        
        Console.Write("Escribe el NUEVO precio: ");
        decimal nuevoPrecio;
        while (!decimal.TryParse(Console.ReadLine(), out nuevoPrecio) || nuevoPrecio < 0 || nuevoPrecio > 1000)
        {
            Console.WriteLine("Error, precio inválido. Intenta de nuevo (entre 0 y 1000): ");
        }

        
        nombres[indiceEncontrado] = nuevoNombre;
        precios[indiceEncontrado] = nuevoPrecio;

        Console.WriteLine("¡Libro modificado!");
    }

    
    public void Eliminar()
    {
        Console.WriteLine("\n-> Eliminar Libro");
        Console.Write("Escribe el nombre del libro que quieres borrar: ");
        string nombreBuscar = Console.ReadLine();

        int indiceBorrar = BuscarIndice(nombreBuscar);

        if (indiceBorrar == -1)
        {
            Console.WriteLine("Error: Ese libro no existe.");
            return;
        }

        
        string[] tempNombres = new string[nombres.Length - 1];
        decimal[] tempPrecios = new decimal[precios.Length - 1];

        int j = 0;
        for (int i = 0; i < nombres.Length; i++)
        {
            if (i == indiceBorrar)
            {
                continue;
            }

            tempNombres[j] = nombres[i];
            tempPrecios[j] = precios[i];
            j++;
        }


        nombres = tempNombres;
        precios = tempPrecios;

        Console.WriteLine("¡Libro eliminado!");
    }
}