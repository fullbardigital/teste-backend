using FullBar.Api.Helpers;
using FullBar.Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FullBar.Api.Repository
{
    public class CursoRepository : IRepository<Curso>
    {

        public string Delete(Curso obj)
        {
            throw new NotImplementedException();
        }

        public List<Curso> Get(Curso obj)
        {
            var LCurso = new List<Curso>();
            SqlCommand oSqlCommand = new SqlCommand();
            SqlConnection oConnection = new SqlConnection();

            try
            {
                oConnection.ConnectionString = Config.ConnectionString;
                oConnection.Open();

                oSqlCommand.Connection = oConnection;
                oSqlCommand.CommandText = @"SELECT	IDCURSO
		                                            ,CURSO
                                            FROM TB_CURSO";

                oSqlCommand.CommandType = CommandType.Text;

                using (var reader = oSqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                {
                    while (reader.Read())
                    {
                        var objCur = new Curso();

                        objCur.idCurso = int.Parse(reader.GetInt32(reader.GetOrdinal("IdCurso")).ToString());
                        objCur.nmCurso = reader.GetString(reader.GetOrdinal("Curso")).ToString();

                        LCurso.Add(objCur);
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


            return LCurso;
        }

        public Curso GetFirst(Curso obj)
        {
            throw new NotImplementedException();
        }

        public string Insert(Curso obj)
        {
            throw new NotImplementedException();
        }

        public string Update(Curso obj)
        {
            throw new NotImplementedException();
        }
    }
}
