using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP7_GRUPO_21
{
    public partial class ListadoSucursalesSeleccionados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SucursalesSeleccionadas"] != null)
                {
                    List<Sucursal> seleccionados = (List<Sucursal>)Session["SucursalesSeleccionadas"];
                    GridView1.DataSource = seleccionados;
                    GridView1.DataBind();
                }
            }
        }
    }
}