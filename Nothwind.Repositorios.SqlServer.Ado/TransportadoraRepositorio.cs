using Northwind.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Nothwind.Repositorios.SqlServer.Ado
{
    public class TransportadoraRepositorio : RepositorioListBase
    {
        public List<Transportadora> Selecionar()
        {
            return base.Selecionar<Transportadora>("TransportadoraSelecionar", Mapear, null);
            
            //var transportadoras = new List<Transportadora>();
            //using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString))
            //{
            //    conexao.Open();
            //    const string nomeProcedure = "TransportadoraSelecionar";

            //    using (var comando = new SqlCommand(nomeProcedure, conexao))
            //    {
            //        comando.CommandType = CommandType.StoredProcedure;

            //        using (var registro = comando.ExecuteReader())
            //        {
            //            while (registro.Read())
            //            {
            //                transportadoras.Add(Mapear(registro));
            //            }


            //        }
            //    }
            //}


            //return transportadoras;


        }

        public Transportadora Selecionar(int ID)
        {

            return base.Selecionar<Transportadora>("TransportadoraSelecionar", Mapear, new SqlParameter("shipperid", ID)).FirstOrDefault();
            
            //Transportadora transportadora = null;

            //using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString))
            //{
            //    conexao.Open();
            //    const string nomeProcedure = "TransportadoraSelecionar";

            //    using (var comando = new SqlCommand(nomeProcedure, conexao))
            //    {
            //        comando.CommandType = CommandType.StoredProcedure;
            //        comando.Parameters.AddWithValue("shipperid", id);
            //        //comando.Parameters.Add(new SqlParameter());

            //        using (var registro = comando.ExecuteReader())
            //        {
            //            if (registro.Read())
            //            {
            //                transportadora = Mapear(registro);

            //            }
            //        }
            //    }

            //}
            //return transportadora;
        }

        public void Inserir(Transportadora transportadora)
        {
            transportadora.Id = Convert.ToInt32(base.ExecuteScalar("TransportadoraInserir", Mapear(transportadora)));
            
            //using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString))
            //{
            //    conexao.Open();
            //    const string nomeProcedure = "TransportadoraInserir";

            //    using (var comando = new SqlCommand(nomeProcedure, conexao))
            //    {
            //        comando.CommandType = CommandType.StoredProcedure;
            //        comando.Parameters.AddRange(Mapear(transportadora));
            //        //comando.Parameters.Add(new SqlParameter());
            //        transportadora.Id = Convert.ToInt32(comando.ExecuteScalar());

            //    }

            //}
        }

        public void Excluir(int id)
        {
            base.ExecuteNonQuery("TransportadoraExcluir",
                new SqlParameter("shipperid", id));
        }

        public void Atualizar(Transportadora transportadora)
        {
            var parametros = Mapear(transportadora).ToList();
            parametros.Add(new SqlParameter("shipperid", transportadora.Id));
            base.ExecuteNonQuery("TransportadoraAtualizar", parametros.ToArray());
        }

        private SqlParameter[] Mapear(Transportadora transportadora)
        {
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("companyName", transportadora.Nome));
            parametros.Add(new SqlParameter("phone", transportadora.Telefone));

            return parametros.ToArray();
        }



        private Transportadora Mapear(SqlDataReader registro)
        {
            var transportadora = new Transportadora();
            transportadora.Id = Convert.ToInt32(registro["ShipperId"]);
            transportadora.Nome = registro["CompanyName"].ToString();
            transportadora.Telefone = Convert.ToString(registro["Phone"]);

            return transportadora;
        }
    }

}