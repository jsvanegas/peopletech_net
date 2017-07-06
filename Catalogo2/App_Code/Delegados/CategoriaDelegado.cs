using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CategoriaDelegado
/// </summary>
public class CategoriaDelegado
{
    private string ruta;
	public CategoriaDelegado(string ruta_servidor)
	{
        this.ruta = ruta_servidor + "/archivos/categorias.txt";
	}

    public List<Categoria> Consultar() {
        string[] lineas = File.ReadAllLines(ruta);
        List<Categoria> lista = new List<Categoria>();
        for (int i = 0; i < lineas.Length; i++)
        {
            string[] datos = lineas[i].Split(';');
            lista.Add(new Categoria() {
                IdCategoria = int.Parse(datos[0]),
                NombreCategoria = datos[1],
                IconoCategoria = datos[2],
                ColorFuente = datos[3],
                ColorFondo = datos[4]
            });
        }
        return lista;
    }

    /// <summary>
    /// Inserta una nueva categoria.... 
    /// </summary>
    /// <param name="categoria">Categoria categoria, un objeto instanciado de la entidad ....</param>
    /// <returns>bool, verdadero si se inserta, falso si no.</returns>
    public bool Insertar(Categoria categoria) {
        try
        {
            using (StreamWriter sw = File.AppendText(ruta))
            {
                sw.WriteLine(categoria.ToString());
                sw.Flush();
                sw.Close();
            }
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}