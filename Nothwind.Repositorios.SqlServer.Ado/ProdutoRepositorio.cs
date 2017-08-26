using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothwind.Repositorios.SqlServer.Ado
{
    public class ProdutoRepositorio : RepositorioDataTableBase
    {
        public DataTable SelecionarPorCategoria(int categoriaId)
        {
            var instrucao = @"SELECT [ProductID]
                                    ,[ProductName]
                                    ,[UnitPrice]
                                    ,[UnitsInStock]
                                FROM [Northwind].[dbo].[Products]
                               Where [CategoryID] = @categoriaId";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@categoriaId", categoriaId));

            return base.Selecionar(instrucao, parametros);
        }

        public DataTable SelecionarPorFornecedor(int fornecedorId)
        {
            var instrucao = @"SELECT [ProductID]
                                    ,[ProductName]
                                    ,[UnitPrice]
                                    ,[UnitsInStock]
                                FROM [Northwind].[dbo].[Products]
                               Where [SupplierID] = @forncedorId";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@forncedorId", fornecedorId));

            return base.Selecionar(instrucao, parametros);
        }
    }
}
