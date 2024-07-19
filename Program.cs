using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters;
using gestion_biblioteca.Models;

bool run = true;
List<Libro> listaLibros = new List<Libro>();

// Ejemplo de agregar algunos libros (puedes adaptar según tu lógica)
listaLibros.Add(new Libro(19.99, "Novela", "1234567890", "Autor1", "Libro1", 2020));
listaLibros.Add(new Libro(29.99, "Ciencia Ficción", "0987654321", "Autor2", "Libro2", 2018));
listaLibros.Add(new Libro(14.99, "Fantasía", "9876543210", "Autor3", "Libro3", 2022));

while (run)
{
    Console.Clear();
    Console.WriteLine(@$"
Hola, que quieres Realizar

1. Agregar Libro
2. Eliminar Libro
3. Mostrar Libros
4. Buscar Libro
5. Aplicar Descuento
6. Salir

    ");

    Console.Write("\nIngrese la opcion deseada => ");
    char eleccion = Convert.ToChar(Console.ReadLine());

    switch (eleccion)
    {
        case '1':
            Console.Clear();

            Console.WriteLine("Vas a agregar un Libro");
            Console.Write("Por favor ingresa el precio del libro => ");
            double precio = Convert.ToDouble(Console.ReadLine());

            Console.Write("Por favor ingresa el genero del libro => ");
            string? genero = Console.ReadLine();

            Console.Write("Por favor ingresa el ISBN del libro => ");
            string? isbn = Console.ReadLine();

            Console.Write("Por favor ingresa el autor del libro => ");
            string? autor = Console.ReadLine();

            Console.Write("Por favor ingresa el titulo del libro => ");
            string? titulo = Console.ReadLine();

            Console.Write("Por favor ingresa el año de publicacion del libro => ");
            int añolibro = Convert.ToInt32(Console.ReadLine());

            var libro = new Libro(precio, genero, isbn, autor, titulo, añolibro);
            listaLibros.Add(libro);
            Console.WriteLine("\nLibro agregado exitosamente");
            Console.Write("Precione cualquier tecla para continuar => ");
            Console.ReadKey();
            break;


        case '2':
            Console.Clear();

            Console.WriteLine("Ingresa el titulo del libro que quieres eliminar => ");
            string? tituloEliminar = Console.ReadLine().ToLower();
            var biblioteca = new Biblioteca();
            biblioteca.EliminarLibro(listaLibros, tituloEliminar);
            Console.WriteLine("\nLibro eliminado exitosamente");
            Console.Write("Precione cualquier tecla para continuar => ");
            Console.ReadKey();
            break;


        case '3':
            Console.Clear();
            for (int i = 0; i < listaLibros.Count(); i++)
            {
                listaLibros[i].Descripcion();
            }
            Console.Write("\nPrecione cualquier tecla para continuar => ");
            Console.ReadKey();
            break;


        case '4':
            Console.Clear();
            Console.WriteLine(@"
            Por favor ingrese el tipo de busqueda que desea realizar
            
            1.Buscar Libros por autor
            2.Buscar Libros por Genero
            3.En un rango de tiempo (Años)

            ");
            char eleccionBusqueda = Convert.ToChar(Console.ReadLine());
            switch (eleccionBusqueda)
            {
                case '1':
                    var bibliotecaAutor = new Biblioteca();
                    Console.Write("Por favor ingrese el autor del cual quieres ver sus libros => ");
                    string? nombreAutor = Console.ReadLine().ToLower();
                    var listaLibrosAutores = bibliotecaAutor.BuscarLibroAutor(listaLibros, nombreAutor);
                    if (listaLibrosAutores.Count() > 0)
                    {
                        Console.WriteLine($"\nlos libros del autor {nombreAutor} son: ");
                        Console.WriteLine();
                        for (int i = 0; i < listaLibrosAutores.Count(); i++)
                        {
                            listaLibrosAutores[i].Descripcion();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error, ningun libro encontrado");
                    }
                    Console.Write("Precione cualquier tecla para continuar => ");
                    Console.ReadKey();
                    break;

                case '2':
                    var bibliotecaGenero = new Biblioteca();
                    Console.Write("Por favor ingrese el genero del cual quieres ver los libros => ");
                    string? generoLibros = Console.ReadLine().ToLower();
                    var listaLibrosGeneros = bibliotecaGenero.BuscarLibroGenero(listaLibros, generoLibros);
                    if (listaLibrosGeneros.Count() > 0)
                    {
                        Console.WriteLine($"\nlos libros del genero {generoLibros} son: ");
                        Console.WriteLine();
                        for (int i = 0; i < listaLibrosGeneros.Count(); i++)
                        {
                            listaLibrosGeneros[i].Descripcion();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error, ningun libro encontrado");
                    }
                    Console.Write("Precione cualquier tecla para continuar => ");
                    Console.ReadKey();
                    break;

                case '3':
                    var bibliotecaAño = new Biblioteca();
                    Console.Write("Ingrese el año inicial => ");
                    int añoInicial = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Ingresa el año final => ");
                    int añoFinal = Convert.ToInt32(Console.ReadLine());
                    var listaRango = bibliotecaAño.BuscarLibroRango(listaLibros, añoInicial, añoFinal);
                    if (listaRango.Count() > 0)
                    {
                        Console.WriteLine($"\nlos libros con fechas de publicacion entre {añoInicial} y {añoFinal}: ");
                        Console.WriteLine();
                        for (int i = 0; i < listaRango.Count(); i++)
                        {
                            listaRango[i].Descripcion();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error, ningun libro encontrado");
                    }
                    Console.Write("Precione cualquier tecla para continuar => ");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine();
                    break;
            }

            break;
        case '5':
            Console.WriteLine("Ingrese el porcentaje de descuento que quieres realizar => ");
            double porcentaje = Convert.ToDouble(Console.ReadLine());
            double porcentajeArreglado = porcentaje/100;
            Console.WriteLine("Ingrese el titulo del libro al cual quieres aplicar el descuento => ");
            string? libroAdescuento = Console.ReadLine().ToLower();
            bool encontrado = false;
            double valor = 0;
            int indice = -1;
            for (int i = 0; i < listaLibros.Count(); i++){
                if(listaLibros[i].Titulo == libroAdescuento){
                    encontrado = true;
                    valor = listaLibros[i].Precio;
                    indice = i;
                    break;
                }
            }
            if(encontrado){
                Console.WriteLine($"El nuevo precio del libro luego del {porcentaje}% de descuento es {valor * porcentajeArreglado}");
                listaLibros[indice].Precio = valor * porcentajeArreglado;
            }
            break;

            case '6':
                run = false;
                break;
        default:
            break;
    }
}