using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP7_GRUPO_21
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SucursalesSeleccionadas"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID_SUCURSAL");
                dt.Columns.Add("NOMBRE");
                dt.Columns.Add("DESCRIPCION");
                Session["SucursalesSeleccionadas"] = dt;
            }
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                ListViewItem item = (ListViewItem)e.Item;
                Label lblNombre = (Label)item.FindControl("NombreSucursalLabel");
                Label lblDescripcion = (Label)item.FindControl("DescripcionSucursalLabel");

                string id = e.CommandArgument.ToString();
                DataTable dt = (DataTable)Session["SucursalesSeleccionadas"];

                bool yaExiste = false;
                foreach (DataRow fila in dt.Rows)
                {
                    if (fila["ID_SUCURSAL"].ToString() == id)
                    {
                        yaExiste = true;
                        break;
                    }
                }

                if (!yaExiste)
                {
                    dt.Rows.Add(id, lblNombre.Text, lblDescripcion.Text);
                    Session["SucursalesSeleccionadas"] = dt;
                }
            }
        }
    }
}