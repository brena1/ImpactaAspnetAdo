using System.Data;
using System.Data.SqlClient;

namespace Nothwind.Repositorios.SqlServer.Ado
{
    public class CategoriaRepositorio : RepositorioDataTableBase
    {
        public DataTable Selecionar()
        {
            var instrucao = @"SELECT [CategoryID]
                                         ,[CategoryName]
                                   FROM [Northwind].[dbo].[Categories]";
            return base.Selecionar(instrucao);

            //var categoriaDataTable = new DataTable();

            //using (var conexao = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"))
            //{
            //    conexao.Open();
                

            //    using (var comando = new SqlCommand(instrucao, conexao))
            //    {
            //        using (var dataAdapter = new SqlDataAdapter(comando))
            //        {
            //            dataAdapter.Fill(categoriaDataTable);


            //        }
            //    }
            //    //conexao.Close();
            //}


            //return (categoriaDataTable);
        }
    }
}
