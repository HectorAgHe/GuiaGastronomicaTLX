using CapaNegocio;
using GuiaGastronomicaTLX.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuiaGastronomicaTLX.Catalogos
{
    public partial class ListarRestaurantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefrescaGrid();
            }
        }
    

        public void RefrescaGrid()
        {
            //Llenar el grid con una lista de CamionVO
            GVRestaurante.DataSource = BllRestaurantes.GetRestaurantes();
            GVRestaurante.DataBind();
        }

        protected void GVRestaurante_RowDeleting(object sender, GridViewDeleteEventArgs e) // Evento que se dispara al hacer clic en el botón de eliminar en una fila del GridView
        {
            string RestauranteId = GVRestaurante.DataKeys[e.RowIndex].Values["RestauranteId"].ToString();
            bool Resultado = BllRestaurantes.Delete(int.Parse(RestauranteId));
            string mensaje = "";
            string sub = "";
            string clase = "";

            switch (Resultado)
            {
                case true:
                    mensaje = "Restaurante Eliminado con éxito";
                    sub = "";
                    clase = SweetAlertConstants.Success;
                    break;
                default:
                    mensaje = "Restaurante no puede ser eliminado";
                    sub = "Los choferes en Ruta no pueden ser eliminados";
                    clase = SweetAlertConstants.Warning;
                    break;
            }
            UtilControls.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            RefrescaGrid();
        }


        //>>>><



        protected void GVRestaurante_RowCommand(object sender, GridViewCommandEventArgs e) // Evento que se dispara al hacer clic en un botón dentro del GridView
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string restauranteId = GVRestaurante.DataKeys[index].Values["RestauranteId"].ToString();
                Response.Redirect("EditarRestaurante.aspx?Id=" + restauranteId);
            }
        }


        protected void GVRestaurante_RowEditing(object sender, GridViewEditEventArgs e) // Evento que se dispara al hacer clic en el botón de editar en una fila del GridView
        {
            GVRestaurante.EditIndex = e.NewEditIndex;
            RefrescaGrid();
        }




        //<<<<<<<
        //protected void GVRestaurante_RowDeleting(object sender, GridViewEditEventArgs e) // Evento que se dispara al hacer clic en el botón de editar en una fila del GridView
        //{
        //    GVRestaurante.EditIndex = e.NewEditIndex;
        //    RefrescaGrid();
        //}

        protected void GVRestaurante_RowUpdating(object sender, GridViewUpdateEventArgs e) // Evento que se dispara al hacer clic en el botón de actualizar en una fila del GridView
        {   
            string RestauranteId = GVRestaurante.DataKeys[e.RowIndex].Values["RestauranteId"].ToString(); // Obtener el ID del restaurante desde las claves de datos del GridView
            string Nombre = e.NewValues["Nombre"].ToString();
            string Descripcion = e.NewValues["Descripcion"].ToString();
            string TipoComida = e.NewValues["TipoComida"].ToString();
            string Direccion = e.NewValues["Direccion"].ToString();
            string Telefono = e.NewValues["Telefono"].ToString();
            string Horarios = e.NewValues["Horario"].ToString();  // Estos datos entre comillas son los nombres de las columnas en el GridView
            string SitioWeb = e.NewValues["SitioWeb"].ToString();


            //CheckBox ChkAux = (CheckBox)GVRestaurante.Rows[e.RowIndex].FindControl("ChkEditDisponible");
            //bool Disponibilidad = ChkAux.Checked;

            BllRestaurantes.UpdRestaurante(int.Parse(RestauranteId), Nombre, Descripcion, TipoComida, Direccion, Telefono, Horarios, SitioWeb);

            GVRestaurante.EditIndex = -1;
            RefrescaGrid();
            UtilControls.SweetBox("Registro actualizado", "", SweetAlertConstants.Success, this.Page, this.GetType());
        }

        protected void GVRestaurante_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) // Evento que se dispara al hacer clic en el botón de cancelar en una fila del GridView
        {
            GVRestaurante.EditIndex = -1;
            RefrescaGrid();
        }



    }
}
