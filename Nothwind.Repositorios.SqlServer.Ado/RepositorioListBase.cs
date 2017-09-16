﻿using Northwind.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothwind.Repositorios.SqlServer.Ado
{
    public delegate T MapeamentoHandler<T>(SqlDataReader reader);
    public class RepositorioListBase
    {
        private string _stringConexao = ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString;

        public List<T> Selecionar<T>(string nomeProcedure, MapeamentoHandler<T> metodoDeMapeamento, params SqlParameter[] parametros)
        {
            var lista = new List<T>();

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                //const string nomeProcedure = "ListaSelecionar";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    using (var registro = comando.ExecuteReader())
                    {
                        while (registro.Read())
                        {
                            lista.Add(metodoDeMapeamento(registro));
                        }


                    }
                }
            }


            return lista;


        }
        public object ExecuteScalar(string nomeProcedure, params SqlParameter[] parametros)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                //const string nomeProcedure = "TransportadoraInserir";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(parametros);

                    //comando.Parameters.Add(new SqlParameter());
                    return comando.ExecuteScalar();

                }

            }
        }


        public void ExecuteNonQuery(string nomeProcedure, params SqlParameter[] parametros)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                //const string nomeProcedure = "TransportadoraInserir";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(parametros);

                    comando.ExecuteNonQuery();


                }
            }


        }
    }
}