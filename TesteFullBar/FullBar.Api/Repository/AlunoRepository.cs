using FullBar.Api.Helpers;
using FullBar.Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FullBar.Api.Repository
{
    public class AlunoRepository : IRepository<Aluno>
    {

        public string Delete(Aluno obj)
        {
            SqlCommand oSqlCommand = new SqlCommand();
            SqlConnection oConnection = new SqlConnection();

            try
            {
                oConnection.ConnectionString = Config.ConnectionString;
                oConnection.Open();

                oSqlCommand.Connection = oConnection;
                oSqlCommand.CommandText = @"Delete TB_Aluno
                                            where idaluno = @idaluno";

                oSqlCommand.Parameters.AddWithValue("@idaluno", obj.id);
                oSqlCommand.CommandType = CommandType.Text;
                oSqlCommand.ExecuteNonQuery();

                oSqlCommand.Dispose();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                oConnection.Close();
            }

            return "Sucesso";
        }

        public List<Aluno> Get(Aluno obj)
        {
            var LAlunos = new List<Aluno>();
            SqlCommand oSqlCommand = new SqlCommand();
            SqlConnection oConnection = new SqlConnection();

            try
            {
                oConnection.ConnectionString = Config.ConnectionString;
                oConnection.Open();

                oSqlCommand.Connection = oConnection;
                oSqlCommand.CommandText = @"SELECT	IDALUNO
		                                    ,NOME
		                                    ,RA
		                                    ,AL.IDPERIODO
		                                    ,PERIODO
		                                    ,AL.IDCURSO
		                                    ,CURSO
                                    FROM TB_ALUNO AL
                                    JOIN TB_PERIODO PER ON PER.IDPERIODO = AL.IDPERIODO
                                    JOIN TB_CURSO CUR ON CUR.IDCURSO = AL.IDCURSO";

                oSqlCommand.CommandType = CommandType.Text;
                //oSqlCommand.Parameters.AddWithValue("@NOME", obj.Nome);
                //oSqlCommand.Parameters.AddWithValue("@RA", obj.RA);
                //oSqlCommand.Parameters.AddWithValue("@ID_CURSO", obj.Id_Curso);

                using (var reader = oSqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                {
                    while (reader.Read())
                    {
                        Aluno objAluno = new Aluno();

                        objAluno.id = int.Parse(reader.GetInt32(reader.GetOrdinal("IDALUNO")).ToString());
                        objAluno.Nome = reader.GetString(reader.GetOrdinal("NOME")).ToString();
                        objAluno.RA = reader.GetString(reader.GetOrdinal("RA")).ToString();
                        objAluno.idCurso = int.Parse(reader.GetInt32(reader.GetOrdinal("IDCURSO")).ToString());
                        objAluno.idPeriodo = int.Parse(reader.GetInt32(reader.GetOrdinal("IDPERIODO")).ToString());
                        objAluno.Periodo = new Periodo();
                        objAluno.Periodo.idPeriodo = int.Parse(reader.GetInt32(reader.GetOrdinal("IDPERIODO")).ToString());
                        objAluno.Periodo.nmPeriodo = reader.GetString(reader.GetOrdinal("PERIODO")).ToString();
                        objAluno.Curso = new Curso();
                        objAluno.Curso.idCurso = int.Parse(reader.GetInt32(reader.GetOrdinal("IDCURSO")).ToString());
                        objAluno.Curso.nmCurso = reader.GetString(reader.GetOrdinal("CURSO")).ToString();

                        LAlunos.Add(objAluno);
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


            return LAlunos;
        }

        public Aluno GetFirst(Aluno obj)
        {
            var Aluno = new Aluno();
            SqlCommand oSqlCommand = new SqlCommand();
            SqlConnection oConnection = new SqlConnection();

            try
            {
                oConnection.ConnectionString = Config.ConnectionString;
                oConnection.Open();

                oSqlCommand.Connection = oConnection;
                oSqlCommand.CommandText = @"SELECT	IDALUNO
		                                    ,NOME
		                                    ,RA
		                                    ,AL.IDPERIODO
		                                    ,PERIODO
		                                    ,AL.IDCURSO
		                                    ,CURSO
                                    FROM TB_ALUNO AL
                                    JOIN TB_PERIODO PER ON PER.IDPERIODO = AL.IDPERIODO
                                    JOIN TB_CURSO CUR ON CUR.IDCURSO = AL.IDCURSO
                                    WHERE IDALUNO = @ID";

                Console.WriteLine(obj.id);

                oSqlCommand.CommandType = CommandType.Text;
                oSqlCommand.Parameters.AddWithValue("@ID", obj.id);

                using (var reader = oSqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                {
                    if (reader.Read())
                    {
                        Aluno.id = int.Parse(reader.GetInt32(reader.GetOrdinal("IDALUNO")).ToString());
                        Aluno.Nome = reader.GetString(reader.GetOrdinal("NOME")).ToString();
                        Aluno.RA = reader.GetString(reader.GetOrdinal("RA")).ToString();
                        Aluno.idCurso = int.Parse(reader.GetInt32(reader.GetOrdinal("IDCURSO")).ToString());
                        Aluno.idPeriodo = int.Parse(reader.GetInt32(reader.GetOrdinal("IDPERIODO")).ToString());
                        Aluno.Periodo = new Periodo();
                        Aluno.Periodo.idPeriodo = int.Parse(reader.GetInt32(reader.GetOrdinal("IDPERIODO")).ToString());
                        Aluno.Periodo.nmPeriodo = reader.GetString(reader.GetOrdinal("PERIODO")).ToString();
                        Aluno.Curso = new Curso();
                        Aluno.Curso.idCurso = int.Parse(reader.GetInt32(reader.GetOrdinal("IDCURSO")).ToString());
                        Aluno.Curso.nmCurso = reader.GetString(reader.GetOrdinal("CURSO")).ToString();

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

            return Aluno;
        }

        public string Insert(Aluno obj)
        {
            SqlCommand oSqlCommand = new SqlCommand();
            SqlConnection oConnection = new SqlConnection();

            try
            {
                oConnection.ConnectionString = Config.ConnectionString;
                oConnection.Open();

                oSqlCommand.Connection = oConnection;
                oSqlCommand.CommandText = @"Insert into TB_Aluno 
                                        values (@NOME
                                                , @RA
                                                , @IDPERIODO
                                                , @IDCURSO)";

                oSqlCommand.Parameters.AddWithValue("@NOME", obj.Nome);
                oSqlCommand.Parameters.AddWithValue("@RA", obj.RA);
                oSqlCommand.Parameters.AddWithValue("@IDPERIODO", obj.idPeriodo);
                oSqlCommand.Parameters.AddWithValue("@IDCURSO", obj.idCurso);

                oSqlCommand.CommandType = CommandType.Text;
                oSqlCommand.ExecuteNonQuery();

                oSqlCommand.Dispose();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                oConnection.Close();
            }

            return "Sucesso";
        }

        public string Update(Aluno obj)
        {
            SqlCommand oSqlCommand = new SqlCommand();
            SqlConnection oConnection = new SqlConnection();

            try
            {
                oConnection.ConnectionString = Config.ConnectionString;
                oConnection.Open();

                oSqlCommand.Connection = oConnection;
                oSqlCommand.CommandText = @"Update TB_Aluno
                                            set nome = @nome
                                                ,ra = @ra
                                                ,idperiodo = @idperiodo
                                                ,idcurso = @idcurso
                                             where idaluno = @idaluno";

                oSqlCommand.Parameters.AddWithValue("@idaluno", obj.id);
                oSqlCommand.Parameters.AddWithValue("@nome", obj.Nome);
                oSqlCommand.Parameters.AddWithValue("@ra", obj.RA);
                oSqlCommand.Parameters.AddWithValue("@idperiodo", obj.idPeriodo);
                oSqlCommand.Parameters.AddWithValue("@idcurso", obj.idCurso);

                oSqlCommand.CommandType = CommandType.Text;
                oSqlCommand.ExecuteNonQuery();

                oSqlCommand.Dispose();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                oConnection.Close();
            }

            return "Sucesso";
        }
    }
}
