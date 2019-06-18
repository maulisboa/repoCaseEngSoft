using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace caseEngSoftApi.Database
{
    public class Dados
    {
        public SqlConnection myConn { get; set; }
        public Boolean isTransaction { get; set; }
        public SqlTransaction trans { get; set; }

        public static string GetConnectionString(string strConnection)
        {
            string retorno;

            if (System.String.IsNullOrEmpty(strConnection))
                retorno = "Data Source=dbcaseengsoft.cm2bdqoqx0rq.ca-central-1.rds.amazonaws.com;Initial Catalog=dbCaseEngSoft;Persist Security Info=True;User ID=caseEngSoft;Password=caseEngSoft123";
            else
                retorno = strConnection;

            return retorno;
        }

        public bool Connect()
        {
            return Connect("Data Source=dbcaseengsoft.cm2bdqoqx0rq.ca-central-1.rds.amazonaws.com;Initial Catalog=dbCaseEngSoft;Persist Security Info=True;User ID=caseEngSoft;Password=caseEngSoft123");
        }
        public bool Connect(string strConnection)
        {
            string connStr;
            bool bln;

            bln = false;

            if (myConn == null)
            {
                connStr = GetConnectionString(strConnection);

                if (connStr != System.String.Empty)
                {
                    bln = true;
                    myConn = new SqlConnection(connStr);
                }
                else
                    bln = false;

            }

            if (myConn.State == ConnectionState.Closed)
                myConn.Open();

            return bln;
        }
        public void CloseConn()
        {
            if (myConn != null)
                if (myConn.State != ConnectionState.Closed)
                    myConn.Close();
        }

        public bool ExecuteQuery(string strCmdTxt)
        {
            return this.ExecuteQuery(strCmdTxt, null);
        }
        public bool ExecuteQuery(string strCmdTxt, SqlParameter[] parameters)
        {
            return this.ExecuteQuery(strCmdTxt, parameters, CommandType.Text);
        }
        public bool ExecuteQuery(string strCmdTxt, SqlParameter[] parameters, CommandType cmdType)
        {
            int intRows;

            if (myConn == null || myConn.State == ConnectionState.Closed)
                Connect();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = strCmdTxt;
            cmd.CommandType = cmdType;

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            if (!isTransaction)
            {
                intRows = cmd.ExecuteNonQuery();
                myConn.Close();
            }
            else
            {
                cmd.Transaction = trans;
                intRows = cmd.ExecuteNonQuery();
            }

            if (intRows > 0)
                return true;
            else
                return false;
        }

        public object ExecuteScalar(string strCmdTxt)
        {          
            return this.ExecuteScalar(strCmdTxt, null);
        }
        public object ExecuteScalar(string strCmdTxt, SqlParameter[] parameters)
        {
            return this.ExecuteScalar(strCmdTxt, parameters, CommandType.Text);
        }
        public object ExecuteScalar(string strCmdTxt, SqlParameter[] parameters, CommandType cmdType)
        {
            object retorno;

            if (myConn == null || myConn.State == ConnectionState.Closed)
                Connect();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = strCmdTxt;
            cmd.CommandType = cmdType;

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            if (!isTransaction)
            {
                retorno = cmd.ExecuteScalar();
                myConn.Close();
            }
            else
            {
                cmd.Transaction = trans;
                retorno = cmd.ExecuteScalar();
            }

            return retorno;
        }

        public SqlDataReader ExecuteAndGetReader(string strCmdTxt)
        {
            return this.ExecuteAndGetReader(strCmdTxt, null);
        }
        public SqlDataReader ExecuteAndGetReader(string strCmdTxt, SqlParameter[] parameters)
        {
            return this.ExecuteAndGetReader(strCmdTxt, parameters, CommandType.Text);
        }
        public SqlDataReader ExecuteAndGetReader(string strCmdTxt, SqlParameter[] parameters, CommandType cmdType)
        {
            
            if (myConn == null || myConn.State == ConnectionState.Closed)
                Connect();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConn;
            cmd.CommandText = strCmdTxt;
            cmd.CommandType = cmdType;

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            if (!isTransaction)
                return cmd.ExecuteReader();
            else
            {
                cmd.Transaction = trans;
                return cmd.ExecuteReader();
            }
        }

        public void BeginTransaction()
        {
            if (isTransaction)
                return;

            if (myConn.State == ConnectionState.Closed)
                myConn.Open();

            trans = myConn.BeginTransaction();
            isTransaction = true;
        }
        public void CommitTransaction()
        {
            if (!isTransaction)
                return;

            trans.Commit();
            myConn.Close();
            trans = null;
            isTransaction = false;
        }
        public void RollBackTransaction()
        {
            if (!isTransaction)
                return;

            trans.Rollback();
            myConn.Close();
            trans = null;
            isTransaction = false;
        }
    }

}
