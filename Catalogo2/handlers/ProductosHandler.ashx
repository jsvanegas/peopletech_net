<%@ WebHandler Language="C#" Class="ProductosHandler" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Linq;

public class ProductosHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "application/json";
        string accion = context.Request.Form["accion"];
        switch (accion) {
            case "insertar":
                Insertar(context);
                break;
            case "consultar":
                Consultar(context);
                break;
        }
    }

    private void Insertar(HttpContext context) {

    }

    private void Consultar(HttpContext context) {
        Respuesta respuesta = new Respuesta() { Codigo=0, Mensaje="No se encontraron datos" };
        var serializador = new JavaScriptSerializer();
        string ruta = HttpContext.Current.Server.MapPath("~");
        ProductoDelegado delegado = new ProductoDelegado(ruta);
        var lista = delegado.Consultar();

        if (context.Request.Form["idCategoria"]!=null)
        {
            int idCategoria = int.Parse(context.Request.Form["idCategoria"]);
            lista = lista.Where(a => a.IdCategoria.Equals(idCategoria)).ToList();
        }

        if (context.Request.Form["nombre"]!=null)
        {
            string nombre = context.Request.Form["nombre"].ToUpper();
            lista = lista.Where(a => a.NombreProducto.ToUpper().Contains(nombre)).ToList();
        }


        if (lista.Count > 0) {
            respuesta.Codigo = 1;
            respuesta.Datos = lista;
            respuesta.Mensaje = "OK";
        }
        context.Response.Write(serializador.Serialize(respuesta));
    }



    public bool IsReusable {
        get {
            return false;
        }
    }

}