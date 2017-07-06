using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Periodico1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardarTema_Click(object sender, EventArgs e)
        {
            using (var cnn = new PeriodicoEntities())
            {
                cnn.TEMA.Add(new TEMA() { TEMA1=txtTema.Text, ICONO=txtIcono.Text });
                cnn.SaveChanges();
            }
        }

        protected void btnConsultarTemas_Click(object sender, EventArgs e)
        {
            using (var cnn = new PeriodicoEntities())
            {
                gridTemas.DataSource = cnn.TEMA.ToList();
                gridTemas.DataBind();
            }
        }

        protected void btnCrearTodo_Click(object sender, EventArgs e)
        {
            using (var cnn = new PeriodicoEntities())
            {
                var autor = new AUTOR() {
                    NOMBRE = "Ricardo Jorge",
                    TITULO = "El Corresponsal"                        
                };
                cnn.AUTOR.Add(autor);
                cnn.SaveChanges();

                var noticia = new NOTICIA() {
                    TITULO = "Inicia Mundial Rusia 2018",
                    CONTENIDO = "Texto de prueba",
                    FOTO = "foto",
                    FECHA = DateTime.Now,
                    ID_TEMA = 1,
                    ID_AUTOR = autor.ID_AUTOR
                };
                cnn.NOTICIA.Add(noticia);
                cnn.SaveChanges();
            }
        }
    }
}