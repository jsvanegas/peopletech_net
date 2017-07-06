using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Categoria
/// </summary>
public class Categoria
{

    public int IdCategoria { get; set; }

    public string NombreCategoria { get; set; }

    public string IconoCategoria { get; set; }

    public string ColorFuente { get; set; }

    public string ColorFondo { get; set; }


    public Categoria()
	{
		
	}

    public override string ToString() {
        return string.Format("{0};{1};{2};{3};{4};", IdCategoria, NombreCategoria, IconoCategoria, ColorFuente, ColorFondo);
    }
}