<%@ WebHandler Language="C#" Class="CategoriasHandler" %>

using System;
using System.Web;

using System.Web.Script.Serialization;

public class CategoriasHandler : IHttpHandler {

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
        Respuesta respuesta = new Respuesta();
        var serializador = new JavaScriptSerializer();
        string ruta = HttpContext.Current.Server.MapPath("~");
        CategoriaDelegado delegado = new CategoriaDelegado(ruta);
        Categoria categoria = serializador.Deserialize<Categoria>(context.Request.Form["categoria"]);
        try
        {
            delegado.Insertar(categoria);
            respuesta.Codigo = 1;
            respuesta.Mensaje = "Se agrego la categoria";
        }
        catch (Exception)
        {
            respuesta.Codigo = -1;
            respuesta.Mensaje = "Ocurrio un error al guardar la categoria";
        }
        context.Response.Write(serializador.Serialize(respuesta));
    }

    private void Consultar(HttpContext context) {
        Respuesta respuesta = new Respuesta() { Codigo=0, Mensaje="No se encontraron datos" };
        var serializador = new JavaScriptSerializer();
        string ruta = HttpContext.Current.Server.MapPath("~");
        CategoriaDelegado delegado = new CategoriaDelegado(ruta);
        var lista = delegado.Consultar();
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