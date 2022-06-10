using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp02
{
    public partial class FrasesQry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Consulta();
        }

        private void Consulta()
        {
            Label1.Text = "Frases de " + Request["nombre"];
            int idautor = Convert.ToInt32(Request["idautor"]);

            using (var db = new ModelFrases())
            {
                var query = from f in db.frases
                            where f.idautor == idautor
                            select new
                            {
                                idfrase = f.idfrase,
                                frase = f.frase
                            };

                GridView1.DataSource = query.ToList();
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string accion = e.CommandName; // viene DEL o UPD
            int idautor = Convert.ToInt32(Request["idautor"]);

            // PARA TOMAR EL IDNOTA

            int index = Convert.ToInt32(e.CommandArgument); // el indice de la fila
            GridViewRow row = GridView1.Rows[index];
            int idfrase = Convert.ToInt32(row.Cells[0].Text); // esta en la columna 0

            Response.Redirect("FrasesInsDelUpd.aspx?Accion=" + accion + "&Idfrase=" + idfrase + "&Idautor=" + idautor + "&Nombre=" + Request["nombre"]);

        }
    }
}