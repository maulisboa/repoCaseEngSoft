using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace caseEngSoftApi.Database
{
    public class t_log: Dados
    {
        public int Incluir(string process, string message, string type)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                string strSql = "pr_log_insert";

                parameters.Add(new SqlParameter("@process", process));
                parameters.Add(new SqlParameter("@message", message));
                parameters.Add(new SqlParameter("@type", type));


                SqlDataReader dr = ExecuteAndGetReader(strSql.ToString(), parameters.ToArray(), CommandType.StoredProcedure);
                dr.Read();

                int ID_Log = Convert.ToInt32(dr["id_log"]);
                dr.Close();

                return ID_Log;
            }
            catch (Exception ex) { throw ex; }
            finally { CloseConn(); }
        }

        public void IncluirStr(string process, string message, string type)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                string strSql = "INSERT INTO t_log(process,message,type) ";
                    strSql += " VALUES ('" + process + "','" + message + "','" + type + "')";

                

                SqlDataReader dr = ExecuteAndGetReader(strSql, null, CommandType.Text);
                dr.Close();

            }
            catch (Exception ex) { throw ex; }
            finally { CloseConn(); }
        }


    }
}
