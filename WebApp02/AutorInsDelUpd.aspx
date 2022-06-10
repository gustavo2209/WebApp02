<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutorInsDelUpd.aspx.cs" Inherits="WebApp02.AutorInsDelUpd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>cibertec.edu.pe</title>
    <link href="images/pi-favicon.gif" rel="shortcut icon" />
    <link href="jq/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="jq/bootstrap/bootstrap-icons.min.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
</head>
<body>
    <div class="container-fluid">
        <div class="row mt-4">
            <div class="col-2"></div>
            <div class="col-8">
                <form id="form1" runat="server">
                    <asp:HiddenField id="Accion" runat="server"/>
                    <asp:HiddenField id="Idautor" runat="server"/>

                    <!-- TITULO DE LA PAGINA -->
                    <div class="row mb-4">
                        <div class="col-12 text-center">
                            <h3> 
                                <asp:Label ID="Label1" runat="server" Text="Añadir Autor"></asp:Label>
                            </h3>
                        </div>
                    </div>

                    <!-- EL AUTOR A INS/DEL/UPD -->
                    <div class="row mb-4">
                        <div class="col-12">
                            <label for="TextBox1">Autor</label>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <!-- BOTONES CANCELAR/ACEPTAR -->
                    <div class="row mb-4">
                        <div class="col-12 text-center">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success" OnClick="LinkButton1_Click"><i class="bi-save"></i> Aceptar</asp:LinkButton>
                            <a href="Main.aspx" class="btn btn-primary"><i class="bi-house-door"></i> Cancelar</a>
                        </div>
                    </div>

                    <!-- PARA MENSAJERIA -->
                    <% 
                        if(Session["msg"] != null && Session["msg"].ToString() != "")
                        {
                    %>
                           <div class="row mb-5">
                               <div class="col-3"></div>
                               <div class="col-6">
                                   <div class="alert alert-warning">
                                       <h4><i class="bi-exclamation-square-fill"></i> Advertencia</h4>
                                       <hr />
                                       <h5 class="text-center">
                                           <% Response.Write(Convert.ToString(Session["msg"])); %>
                                       </h5>
                                   </div>
                               </div>
                               <div class="col-3"></div>
                           </div>
                    <%
                       }
                    %>

                    <!-- BORRAR MENSAJE -->
                    <% Session["msg"] = ""; %>

                </form>
            </div>
            <div class="col-2"></div>
        </div>
    </div>
    
    <script src="jq/jquery-3.6.0.min.js"></script>
    <script src="jq/bootstrap/bootstrap.bundle.min.js"></script>

</body>
</html>
