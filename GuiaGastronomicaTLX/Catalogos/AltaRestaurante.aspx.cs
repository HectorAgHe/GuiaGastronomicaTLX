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
    public partial class AltaRestaurante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                string Nombre = this.txtNombre.Text;
                string Descripcion = this.txtDescripcion.Text;
                string TipoComida = this.txtTipoComida.Text;
                string Direccion = this.txtDireccion.Text;
                string Telefono = this.txtTelefono.Text;
                string Horario = this.txtHorario.Text;
                string SitioWeb = this.txtSitioWeb.Text;
                BllRestaurantes.Insert(Nombre, Descripcion, TipoComida, Direccion, Telefono, Horario, SitioWeb);
                Util.UtilControls.SweetBoxConfirm("Exito!", "Restaurante agregado exitosamente", SweetAlertConstants.Success,
                    "/Catalogos/Restaurantes/ListarRestaurantes.aspx", this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error!", ex.ToString(), SweetAlertConstants.Error, this.Page, this.GetType());

            }
        }

    }
}