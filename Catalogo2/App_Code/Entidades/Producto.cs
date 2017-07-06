using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Producto
/// </summary>
public class Producto
{
    public int IdProducto { get; set; }
    public int IdCategoria { get; set; }
    public string NombreProducto { get; set; }
    public double PrecioProducto { get; set; }
    public string MarcaProducto { get; set; }
    public string DescripcionProducto { get; set; }

    public string Imagen { get; set; }

    public Producto()
	{
		
	}
}