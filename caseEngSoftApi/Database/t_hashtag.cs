using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using caseEngSoftApi.Models;
using Microsoft.EntityFrameworkCore;

namespace caseEngSoftApi.Database
{
    public class t_hashtag: Dados
    {
        public int Incluir(string hashtag_name)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                string strSql = "pr_hashtag_insert";

                parameters.Add(new SqlParameter("@hashtag", hashtag_name));
                parameters.Add(new SqlParameter("@id_user", "1"));


                SqlDataReader dr = ExecuteAndGetReader(strSql.ToString(), parameters.ToArray(), CommandType.StoredProcedure);
                dr.Read();

                int id = Convert.ToInt32(dr["id_hashtag"]);
                dr.Close();

                return id;
            }
            catch (Exception ex) { throw ex; }
            finally { CloseConn(); }
        }

        public hashtagDTO Consultar(long id_hashtag)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                string strSql = "pr_hashtag_consult";
                parameters.Add(new SqlParameter("@id_hashtag", id_hashtag));

                SqlDataReader dr = ExecuteAndGetReader(strSql.ToString(), parameters.ToArray(), CommandType.StoredProcedure);
                hashtagDTO obj = new hashtagDTO();

                if (dr.Read())
                {
                    obj.id_hashtag = Convert.ToInt32(dr["id_hashtag"]);
                    obj.hashtag_name = dr["hashtag_name"].ToString();
                }

                dr.Close();
                return obj;
            }
            catch (Exception ex) { throw ex; }
            finally { CloseConn(); }
        }
        public List<hashtagDTO> Listar()
        {
            try
            {
                string strSql = "pr_hashtag_list";

                List<SqlParameter> parameters = new List<SqlParameter>();
                

                SqlDataReader dr = ExecuteAndGetReader(strSql.ToString(), parameters.ToArray(), CommandType.StoredProcedure);
                List<hashtagDTO> lista = new List<hashtagDTO>();

                while (dr.Read())
                    lista.Add(SetHashtag(dr));
                
                    
                dr.Close();
                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { CloseConn(); }
        }

        public bool Alterar(long id_hashtag, string hashtag_name)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                string strSql = "pr_hashtag_update";
                parameters.Add(new SqlParameter("@id_hashtag", id_hashtag));
                parameters.Add(new SqlParameter("@hashtag", hashtag_name));

                return ExecuteQuery(strSql, parameters.ToArray(), CommandType.StoredProcedure);
            }
            catch (Exception ex) { throw ex; }
            finally { CloseConn(); }
        }

        public bool Excluir(long id_hashtag)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                string strSql = "pr_hashtag_delete";
                parameters.Add(new SqlParameter("@id_hashtag", id_hashtag));
              
                return ExecuteQuery(strSql, parameters.ToArray(), CommandType.StoredProcedure);
            }
            catch (Exception ex) { throw ex; }
            finally { CloseConn(); }
        }

        private hashtagDTO SetHashtag(SqlDataReader dr)
        {
            hashtagDTO obj = new hashtagDTO();

            obj.id_hashtag = Convert.ToInt32(dr["id_hashtag"]);
            obj.hashtag_name = dr["hashtag"].ToString();
           
            return obj;
        }
    }
}
