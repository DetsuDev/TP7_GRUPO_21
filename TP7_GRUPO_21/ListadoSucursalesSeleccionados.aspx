<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursalesSeleccionados.aspx.cs" Inherits="TP7_GRUPO_21.ListadoSucursalesSeleccionados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:HyperLink ID="hlListadoSucursales" runat="server" NavigateUrl="~/SeleccionarSucursales.aspx">Listado de sucursales</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hlMostrarSucSelec" runat="server" NavigateUrl="~/ListadoSucursalesSeleccionados.aspx">Mostrar sucursales seleccionadas</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 20px; font-weight: bold;">Mostrar sucursales seleccionadas</td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
                            <Columns>
                                <asp:BoundField DataField="IdSucursal" HeaderText="ID_SUCURSAL" />
                                <asp:BoundField DataField="NombreSucursal" HeaderText="NOMBRE" />
                                <asp:BoundField DataField="DescripcionSucursal" HeaderText="DESCRIPCION" />
                            </Columns>
                            <HeaderStyle BackColor="#DCDCDC" Font-Bold="True" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>