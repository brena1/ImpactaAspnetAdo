<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Northwind.WebForms.Pordutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Northwind - Produtos</h2>

    <div class="row">
        <div class="col-sm-12">

            <asp:RadioButtonList runat="server" ID="criterioPesquisaRadioButtonList"
                RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="criterioPesquisaRadioButtonList_SelectedIndexChanged">
                <asp:ListItem Text="Categoria" Value="0" Selected="True" />
                <asp:ListItem Text="Fornecedor" Value="1" />
            </asp:RadioButtonList>

            <asp:MultiView ActiveViewIndex="0" ID="criterioPesquisaMultiview" runat="server">
                <asp:View runat="server" ID="categoriaView">
                    <asp:DropDownList runat="server" DataTextField="CategoryName"
                        DataValueField="CategoryId"
                        ID="categoriaDropDownList" AppendDataBoundItems="true"
                        AutoPostBack="true"
                        DataSourceID="categoriaObjectDataSource">
                        <asp:ListItem Text="Selecione uma Categoria" Value="0" />
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="categoriaObjectDataSource"
                        TypeName="Nothwind.Repositorios.SqlServer.Ado.CategoriaRepositorio"
                        SelectMethod="Selecionar" runat="server"></asp:ObjectDataSource>
                </asp:View>

                <asp:View runat="server" ID="fornecedorView">
                    <asp:DropDownList runat="server" DataTextField="CompanyName"
                        DataValueField="SupplierId"
                        AutoPostBack="true"
                        ID="fornecedorDropDownList" AppendDataBoundItems="true"
                        DataSourceID="fornecedorObjectDataSource">
                        <asp:ListItem Text="Selecione um fornecedor" Value="0" />
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="fornecedorObjectDataSource"
                        TypeName="Nothwind.Repositorios.SqlServer.Ado.FornecedorRepositorio"
                        SelectMethod="Selecionar" runat="server"></asp:ObjectDataSource>
                </asp:View>

            </asp:MultiView>

        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">

            <asp:GridView runat="server" ID="produtosGridView" AutoGenerateColumns="false" Width="100%" DataSourceID="produtoPorCategoriaObjectDataSource">
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="Nome" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="Preço" />
                    <asp:BoundField DataField="UnitsInStock" HeaderText="Estoque" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource
                ID="produtoPorCategoriaObjectDataSource"
                TypeName="Nothwind.Repositorios.SqlServer.Ado.ProdutoRepositorio"
                SelectMethod="SelecionarPorCategoria" runat="server">
                <SelectParameters>
                    <asp:ControlParameter
                        ControlID="CategoriaDropDownList"
                        PropertyName="SelectedValue"
                        Name="categoriaId"
                        Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <%--  --%>
            <asp:ObjectDataSource ID="produtoPorFornecedorObjectDataSource" 
                TypeName="Nothwind.Repositorios.SqlServer.Ado.ProdutoRepositorio" SelectMethod="SelecionarPorFornecedor" runat="server" >
                <SelectParameters>
                    <asp:ControlParameter
                        ControlID="FornecedorDropDownList"
                        PropertyName="SelectedValue"
                        Name="fornecedorId"
                        Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>

        </div>
    </div>

</asp:Content>
