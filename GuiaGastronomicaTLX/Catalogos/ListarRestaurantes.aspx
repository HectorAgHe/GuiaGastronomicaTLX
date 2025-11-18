<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarRestaurantes.aspx.cs" Inherits="GuiaGastronomicaTLX.Catalogos.ListarRestaurantes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">

    <div class="row">
        
        <h3>Lista de Restaurantes</h3>
        <hr />

        <div class="col-md-12 table-responsive">

            <div class="col-12">
                <button class="btn btn-success btn-xs"
                    onclick="location.href='AltaRestaurante.aspx'; return false;">
                    Agregar</button>
            </div>

                <asp:GridView

                    ID="GVRestaurante"
                    runat="server"
                    AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped mt-3 table-condensed&quot;"
                    DataKeyNames="RestauranteId"
                    OnRowDeleting="GVRestaurante_RowDeleting"
                    OnRowCommand="GVRestaurante_RowCommand"
                    OnRowEditing="GVRestaurante_RowEditing"
                    OnRowUpdating="GVRestaurante_RowUpdating"
                    OnRowCancelingEdit="GVRestaurante_RowCancelingEdit">
                    
                    <Columns>


                    <asp:ButtonField 
                        ButtonType="Button" 
                        CommandName="Seleccionado" 
                        Text="Seleccionar"
                        ControlStyle-CssClass="btn btn-success btn-xs">
                        <%--<ControlStyle CssClass="btn btn-success btn-xs"></ControlStyle>--%>
                    </asp:ButtonField>

                    <asp:CommandField 
                        ButtonType="Button" 
                        CancelText="Cancelar" 
                        DeleteText="Eliminar"
                        EditText="Editar" 
                        ShowDeleteButton="True" 
                        ControlStyle-CssClass="btn btn-danger btn-xs">
                        <%--<ControlStyle CssClass="btn btn-danger btn-xs"></ControlStyle>--%>
                    </asp:CommandField>

                    <asp:CommandField 
                        ButtonType="Button" 
                        ShowEditButton="True"
                        ControlStyle-CssClass="btn btn-primary btn-xs">
                        <%--<ControlStyle CssClass="btn btn-primary btn-xs"></ControlStyle>--%>
                    </asp:CommandField>


                    <asp:BoundField 
                        DataField="restauranteId" 
                        HeaderText="restauranteId" 
                        ReadOnly="True"
                        />

                    <asp:BoundField 
                        DataField="Nombre" 
                        HeaderText="Nombre" 
                        />                    

                    <asp:BoundField 
                        DataField="Descripcion" 
                        HeaderText="Descripcion" 
                         />

                    <asp:BoundField 
                        DataField="TipoComida" 
                        HeaderText="TipoComida" 
                         />

                    <asp:BoundField 
                        DataField="Direccion" 
                        HeaderText="Direccion" />

                    <asp:BoundField 
                        DataField="Telefono" 
                        HeaderText="Telefono" />

                    <asp:BoundField 
                        DataField="Horario" 
                        HeaderText="Horario" />
                    <asp:BoundField
                        DataField="SitioWeb"
                        HeaderText="SitioWeb" />
                    <asp:BoundField
                        DataField="FechaRegistro"
                        HeaderText="FechaRegistro" />

                </Columns>
            </asp:GridView>

        </div>
    </div>

</div>
</asp:Content>
