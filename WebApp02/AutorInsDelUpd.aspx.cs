using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp02
{
    public partial class AutorInsDelUpd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion = Request["Accion"];

            if(accion != null && accion != "")
            {
                int idautor = Convert.ToInt32(Request["Idautor"]);

                using(var db = new ModelFrases())
                {
                    autores autor = db.autores.Where(a => a.idautor == idautor).First();
                    TextBox1.Text = autor.autor;
                }

                switch (accion)
                {
                    case "DEL":
                        Label1.Text = "Retirar Autor";
                        break;
                    case "UPD":
                        Label1.Text = "Actualizar datos de Autor";
                        break;
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string accion = Request["Accion"];
            string autor_nombre = Request["TextBox1"];

            if (autor_nombre.Trim().Length > 0)
            {
                using(var db = new ModelFrases())
                {
                    if (accion == null || accion == "") // INS
                    {
                        var autor = new autores { autor = autor_nombre };
                        db.autores.Add(autor);
                    }
                    else // DEL - UPD
                    {
                        int idautor = Convert.ToInt32(Request["Idautor"]);
                        var autor = db.autores.Find(idautor);

                        switch (accion)
                        {
                            case "DEL":
                                db.autores.Remove(autor);
                                break;
                            case "UPD":
                                autor.autor = autor_nombre;
                                break;
                        }
                    }

                    db.SaveChanges();
                }
                Response.Redirect("Main.aspx");
            }
            else
            {
                Session["msg"] = "Debe ingresar nombre del autor";
                Response.Redirect("AutorInsDelUpd.aspx?Accion=" + accion + "&Idautor=" + Request["Idautor"]);
            }
        }
    }
}