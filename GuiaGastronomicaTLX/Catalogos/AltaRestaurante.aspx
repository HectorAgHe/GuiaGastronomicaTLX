<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaRestaurante.aspx.cs" Inherits="GuiaGastronomicaTLX.Catalogos.AltaRestaurante" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <h3>Alta Restaurante</h3>
            <hr />

            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>

                    <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" MaxLength="50"
                        CssClass="form-control"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfvtxtNombre" ControlToValidate="txtNombre"
                        CssClass="text-danger" runat="server"
                        ErrorMessage="Nombre de restaurante requerido"></asp:RequiredFieldValidator>
                </div>
            </div>



            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                    <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Descripcion de tu restaurante" MaxLength="150"
                        CssClass="form-control">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDescripcion"
                        CssClass="text-danger" runat="server" ErrorMessage="Descripcion requerida">
                    </asp:RequiredFieldValidator>
                </div>
            </div>




            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblTipoComida" runat="server" Text="Tipo de Comida"></asp:Label>
                    <asp:TextBox ID="txtTipoComida" runat="server" placeholder="Que comida sirves" MaxLength="150"
                        CssClass="form-control">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtTipoComida"
                        CssClass="text-danger"
                        runat="server" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </div>
            </div>




            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
                    <asp:TextBox ID="txtDireccion" runat="server" placeholder="Del negocio" MaxLength="7"
                        CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtDireccion" ControlToValidate="txtDireccion"
                        CssClass="text-danger" runat="server"
                        ErrorMessage="Direccion requerida"></asp:RequiredFieldValidator>
                </div>
            </div>



            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblTelefono" Text="Telefono" runat="server"></asp:Label>
                    <asp:TextBox ID="txtTelefono" runat="server" placeholder="(999) 999-9999" MaxLength="10"
                        CssClass="form-control"></asp:TextBox>
                </div>
            </div>


     

            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblHorario" runat="server" Text="Horario"></asp:Label>
                    <asp:TextBox ID="txtHorario" runat="server" placeholder="Del negocio" MaxLength="7"
                        CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtHorario"
                        CssClass="text-danger" runat="server"
                        ErrorMessage="Horario requerida"></asp:RequiredFieldValidator>
                </div>
            </div>



            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblSitioWeb" runat="server" Text="SitioWeb"></asp:Label>
                    <asp:TextBox ID="txtSitioWeb" runat="server" placeholder="Del negocio" MaxLength="7"
                        CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtSitioWeb"
                        CssClass="text-danger" runat="server"
                        ErrorMessage="Sitio requerido"></asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="col-md-12 col-md-offset-5">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" Visible="true" CssClass="btn btn-primary" runat="server"
                        Text="Guardar" OnClick="btnGuardar_Click" />
                </div>
            </div>


            
        </div>
    </div>
</asp:Content>
