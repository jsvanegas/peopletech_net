using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ProductoDelegado
/// </summary>
public class ProductoDelegado
{
    private string ruta;
    public ProductoDelegado(string ruta_servidor)
    {
        this.ruta = ruta_servidor + "/archivos/productos.txt";
    }


    public List<Producto> Consultar() {
        string[] lineas = File.ReadAllLines(ruta);
        var lista = new List<Producto>();
        for (int i = 0; i < lineas.Length; i++)
        {
            string[] datos = lineas[i].Split(';');
            lista.Add(new Producto() {
                IdProducto = int.Parse(datos[0]),
                IdCategoria = int.Parse(datos[1]),
                NombreProducto = datos[2],
                PrecioProducto = double.Parse(datos[3]),
                MarcaProducto = datos[4],
                DescripcionProducto = datos[5],
                Imagen = datos[6]
            });
        }
        return lista;
    }



}