using FullBar.Api.Helpers;
using FullBar.Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace FullBar.Api.Repository
{
    public class PeriodoRepository : IRepository<Periodo>
    {

        public string Delete(Periodo obj)
        {
            throw new NotImplementedException();
        }

        public List<Periodo> Get(Periodo obj)
        {
            var LPeriodo = new List<Periodo>();
            SqlCommand oSqlCommand = new SqlCommand();
            SqlConnection oConnection = new SqlConnection();

            try
            {
                oConnection.ConnectionString = Config.ConnectionString;
                oConnection.Open();

                oSqlCommand.Connection = oConnection;
                oSqlCommand.CommandText = @"SELECT	IDPERIODO
		                                            ,PERIODO
                                            FROM TB_PERIODO";

                oSqlCommand.CommandType = CommandType.Text;

                using (var reader = oSqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                {
                    while (reader.Read())
                    {
                        var objPer = new Periodo();

                        objPer.idPeriodo = int.Parse(reader.GetInt32(reader.GetOrdinal("IdPeriodo")).ToString());
                        objPer.nmPeriodo = reader.GetString(reader.GetOrdinal("Periodo")).ToString();

                        LPeriodo.Add(objPer);
                    }
                }
                oSqlCommand.Dispose();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                oConnection.Close();
            }


            return LPeriodo;
        }

        public Periodo GetFirst(Periodo obj)
        {
            throw new NotImplementedException();
        }

        public string Insert(Periodo obj)
        {
            throw new NotImplementedException();
        }

        public string Update(Periodo obj)
        {
            throw new NotImplementedException();
        }
    }
}
