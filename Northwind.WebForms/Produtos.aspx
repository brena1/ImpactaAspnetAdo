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
             
           <asp:GridView runat="server" ID="produtosGridView" AutoGenerateColumns="false" Width="100%">
               
               <Columns>
                   <asp:BoundField   


               </Columns>      
                   
           </asp:GridView>

        </div>
    </div>

</asp:Content>
