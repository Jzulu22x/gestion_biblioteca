using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_biblioteca.Models;
public class Libro : Biblioteca
{
    public Guid Id { get; set; }

    public Libro(double precio, string genero, string isbn, string autor, string titulo, int añopublicacion)
    {
        Id = Guid.NewGuid();
        Precio = precio;
        Genero = genero.ToLower();
        ISBN = isbn;
        Autor = autor.ToLower();
        Titulo = titulo.ToLower();
        AñoPublicacion = añopublicacion;
    }
    public void Descripcion()
    {
        Console.WriteLine(@$"
        Id: {Id}
        Titulo: {Titulo}
        Año de publicacion: {AñoPublicacion}
        Autor: {Autor}
        ISBN: {ISBN}
        Genero: {Genero}
        Precio: {Precio}
        ");
    }

    public List<Libro> OrdenarPorAño(List<Libro> listaAordenar)
    {
        List<Libro> listaOrdenada = listaAordenar.OrderBy(libro => libro.AñoPublicacion).ToList();
        return listaOrdenada;
    }
}
