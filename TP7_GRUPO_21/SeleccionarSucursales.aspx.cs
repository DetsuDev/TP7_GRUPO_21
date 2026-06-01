using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace TP7_GRUPO_21
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Conexion con = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListView("SELECT Id_Sucursal, NombreSucursal, DescripcionSucursal, URL_Imagen_Sucursal FROM Sucursal");
                if (Session["SucursalesSeleccionadas"] == null)
                {
                    Session["SucursalesSeleccionadas"] = new List<Sucursal>();
                }
            }
        }
        private void CargarListView(string consulta)
        {
            DataTable dt = con.ObtenerTabla(consulta);
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Label lblNombre = (Label)e.Item.FindControl("NombreSucursalLabel");
                Label lblDesc = (Label)e.Item.FindControl("DescripcionSucursalLabel");
                string id = e.CommandArgument.ToString();

                List<Sucursal> seleccionados = (List<Sucursal>)Session["SucursalesSeleccionadas"];

                if (!seleccionados.Exists(s => s.IdSucursal.ToString() == id))
                {
                    Sucursal nueva = new Sucursal();
                    nueva.IdSucursal = int.Parse(id);
                    nueva.NombreSucursal = lblNombre.Text;
                    nueva.DescripcionSucursal = lblDesc.Text;

                    seleccionados.Add(nueva);
                    Session["SucursalesSeleccionadas"] = seleccionados;
                }
            }
        }
        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager pager = (DataPager)ListView1.FindControl("DataPager1");
            pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            string busqueda = txtNombreSucursal.Text.Trim();
            string consulta = "SELECT Id_Sucursal, NombreSucursal, DescripcionSucursal, URL_Imagen_Sucursal FROM Sucursal";

            if (!string.IsNullOrEmpty(busqueda))
            {
                consulta += " WHERE NombreSucursal LIKE '%" + busqueda + "%'";
            }

            CargarListView(consulta);
        }
        protected void btnBuscarSucursal_Click(object sender, EventArgs e)
        {
            string busqueda = txtNombreSucursal.Text.Trim();

            string consulta = "SELECT Id_Sucursal, NombreSucursal, DescripcionSucursal, URL_Imagen_Sucursal FROM Sucursal";
            if (!string.IsNullOrEmpty(busqueda))
            {
                consulta += " WHERE NombreSucursal LIKE '%" + busqueda + "%'";
            }

            CargarListView(consulta);
        }

        protected void btnProvincia_Click(object sender, EventArgs e)
        {
            string idProvincia = ((Button)sender).CommandArgument;
            string consulta = "SELECT Id_Sucursal, NombreSucursal, DescripcionSucursal, URL_Imagen_Sucursal FROM Sucursal WHERE Id_ProvinciaSucursal = '" + idProvincia + "'";
            CargarListView(consulta);
        }

    }
}