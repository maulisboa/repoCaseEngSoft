using System;
using System.Collections.Generic;


using System.Data;
using System.Data.SqlClient;


namespace caseEngSoftApi.Database
{
    public class SecurityUsers: Dados
    {
        public bool Login(string login, string senha)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                string strSql = "pr_user_login";
                parameters.Add(new SqlParameter("@login", login));
                parameters.Add(new SqlParameter("@senha", senha));

                SqlDataReader dr = ExecuteAndGetReader(strSql.ToString(), parameters.ToArray(), CommandType.StoredProcedure);
                dr.Read();

                bool ret = Convert.ToBoolean(dr["ret"]);
                dr.Close();

                return ret;

            }
            catch (Exception ex) { throw ex; }
            finally { CloseConn(); }
        }
    }
}
