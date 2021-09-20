using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Maintenance_Units.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlconnection;   // create instance of sql client data    

        //create the connection of DataAccessLayer 
       public DataAccessLayer()
        {
            sqlconnection = new SqlConnection("Server = RIYAD; ; Database = MaintenaceUnits_db; Uid=riyad ; Pwd=61158;");
        }
        //Method for open the connection
        public void Open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {

                sqlconnection.Open();


            }


        }

        // Method for closing the connection
        public void close()
        {
            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();

            }
        }

        //Method to Read Data From Database
        public DataTable SelectData(String Stored_Procedure, SqlParameter[] Param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            sqlcmd.Connection = sqlconnection;
            if (Param != null)
            {
                for (int i = 0; i < Param.Length; i++)
                {
                    sqlcmd.Parameters.Add(Param[i]);

                }

            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Method to insert , update and Delete Data From Database
        public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);

            }
            sqlcmd.ExecuteNonQuery();
        }
    }
}
