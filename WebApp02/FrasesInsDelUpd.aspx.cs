using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp02
{
    public partial class FrasesInsDelUpd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion = Request["Accion"];

            if (accion != null && accion != "")
            {
                int idfrase = Convert.ToInt32(Request["Idfrase"]);

                using (var db = new ModelFrases())
                {
                    frases frase = db.frases.Where(f => f.idfrase == idfrase).First();
                    TextBox1.Text = frase.frase;
                }

                switch (accion)
                {
                    case "DEL":
                        Label1.Text = "Retirar Frase";
                        break;
                    case "UPD":
                        Label1.Text = "Actualizar datos de la Frase";
                        break;
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string accion = Request["Accion"];
            string frase_nombre = Request["TextBox1"];
            int idautor = Convert.ToInt32(Request["Idautor"]);

            if (frase_nombre.Trim().Length > 0)
            {
                using (var db = new ModelFrases())
                {
                    if (accion == null || accion == "") // INS
                    {
                        var frase = new frases { idautor = idautor,  frase = frase_nombre };
                        db.frases.Add(frase);
                    }
                    else // DEL - UPD
                    {
                        int idfrase = Convert.ToInt32(Request["Idfrase"]);
                        var frase = db.frases.Find(idfrase);

                        switch (accion)
                        {
                            case "DEL":
                                db.frases.Remove(frase);
                                break;
                            case "UPD":
                                frase.frase = frase_nombre;
                                break;
                        }
                    }

                    db.SaveChanges();
                }
                Response.Redirect("FrasesQry.aspx?Idautor=" + idautor + "&nombre=" + Request["nombre"]);
            }
            else
            {
                Session["msg"] = "Debe ingresar nombre de la frase";
                Response.Redirect("FraseInsDelUpd.aspx?Accion=" + accion + "&Idfrase=" + Request["Idfrase"]);
            }
        }
    }
}