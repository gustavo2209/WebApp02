<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrasesQry.aspx.cs" Inherits="WebApp02.FrasesQry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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

        <!-- TITULO DE LA PAGINA -->
        <div class="row mt-4">
            <div class="col-12 text-center">
                <h3>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </h3>
            </div>
        </div>

        <!-- BOTONES SOBRE LA GRILLA -->
        <div class="row mt-4">
            <div class="col-1"></div>
            <div class="col-3 text-center">
                <a class="btn btn-success" href="FrasesInsDelUpd.aspx?Idautor=<%=Request["idautor"]%>&nombre=<%=Request["nombre"] %>"><i class="bi-plus-square"></i>Añadir Frase</a>
            </div>
            <div class="col-4"></div>
            <div class="col-3 text-end">
                <a href="Main.aspx" class="btn btn-success"><i class="bi-house-dooor"></i>Home</a>
            </div>
            <div class="col-1"></div>
        </div>

        <!-- GRILLA -->
        <div class="row mt-1">
            <div class="col-1"></div>
            <div class="col-10">
                <form id="form1" runat="server">
                    <asp:HiddenField id="nombre" runat="server"/>
                    <div>
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="idfrase" HeaderText="ID" />
                                <asp:BoundField DataField="frase" HeaderText="Frase" />

                                <asp:ButtonField CommandName="DEL" ItemStyle-Width="20" Text="<i class='bi-trash-fill' style='color:#900'></i>" />
                                <asp:ButtonField CommandName="UPD" ItemStyle-Width="20" Text="<i class='bi-pencil-fill' style='color:#090'></i>" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </form>
            </div>
        </div>
    </div>



    <script src="jq/jquery-3.6.0.min.js"></script>
    <script src="jq/bootstrap/bootstrap.bundle.min.js"></script>
</body>
</html>
