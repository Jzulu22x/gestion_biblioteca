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
        Id = new Guid();
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
    public double Descuento(double porcentaDescuento)
    {
        double precioDescuento = Precio - (Precio * porcentaDescuento);
        return precioDescuento;
    }

    public List<Libro> OrdenarPorAño(List<Libro> listaAordenar)
    {
        List<Libro> listaOrdenada = listaAordenar.OrderBy(libro => libro.AñoPublicacion).ToList();
        return listaOrdenada;
    }
    public bool LibroReciente(List<Libro> libros, int añoActual)
    {
        for (int i = 0; i < libros.Count(); i++)
        {
            if (añoActual - libros[i].AñoPublicacion <= 5)
            {
                return true;
            }
        }
        return false;
    }
}
