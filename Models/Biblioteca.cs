using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestion_biblioteca.Models;

namespace gestion_biblioteca.Models;
public class Biblioteca : Publicacion
{
    public string? Autor { get; set; }
    public string? ISBN { get; set; }
    public string? Genero { get; set; }
    public double Precio { get; set; }

    public void EliminarLibro(List<Libro> listaLibros, string titulo)
    {
        bool encontrado = false;
        for (int i = 0; i < listaLibros.Count(); i++)
        {
            if (listaLibros[i].Titulo == titulo)
            {
                listaLibros.RemoveAt(i);
                encontrado = true;
                break;
            }
        }
        if (!encontrado){
            Console.WriteLine("Error, libro no encontrado");
        }
    }
    public List<Libro> BuscarLibroAutor(List<Libro> listaLibros, string autor)
    {
        List<Libro> librosEncontrados = new List<Libro>();
        for (int i = 0; i < listaLibros.Count(); i++)
        {
            if (listaLibros[i].Autor == autor)
            {
                librosEncontrados.Add(listaLibros[i]);
            }
        }
        return librosEncontrados;
    }
    public List<Libro> BuscarLibroGenero(List<Libro> listaLibros, string genero)
    {
        List<Libro> librosEncontrados = new List<Libro>();
        for (int i = 0; i < listaLibros.Count(); i++)
        {
            if (listaLibros[i].Genero == genero)
            {
                librosEncontrados.Add(listaLibros[i]);
            }
        }
        return librosEncontrados;
    }
    public List<Libro> BuscarLibroRango(List<Libro> listaLibros, int añoInicial, int añofinal)
    {
        List<Libro> librosEncontrados = new List<Libro>();
        for (int i = 0; i < listaLibros.Count(); i++)
        {
            if (listaLibros[i].AñoPublicacion >= añoInicial && listaLibros[i].AñoPublicacion <= añofinal)
            {
                librosEncontrados.Add(listaLibros[i]);
            }
        }
        return librosEncontrados;
    }
}
