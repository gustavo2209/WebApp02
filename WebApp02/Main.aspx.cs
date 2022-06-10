using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp02
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Consulta();
        }

        private void Consulta()
        {
            using (var db = new ModelFrases())
            {
                var query = from a in db.autores
                            join f in db.frases on a.idautor equals f.idautor into autores_frases
                            from a_f in autores_frases.DefaultIfEmpty() // LOGRAR UN LEFT JOIN
                            select new
                            {
                                idautor = a.idautor,
                                autor = a.autor,
                                frase = a_f.frase
                            };

                GridView1.DataSource = query.ToList();
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string accion = e.CommandName; // viene DEL o UPD

            // PARA TOMAR EL IDAUTOR

            int index = Convert.ToInt32(e.CommandArgument); // el indice de la fila
            GridViewRow row = GridView1.Rows[index];
            int idautor = Convert.ToInt32(row.Cells[0].Text); // esta en la columna 0

            Response.Redirect("AutorInsDelUpd.aspx?accion=" + accion + "&idautor=" + idautor);
        }
    }
}