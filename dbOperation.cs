using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager_DataLayer
{
    public class dbOperation
    {

        public SqlConnection cnn;



        public DataTable GetData(SqlCommand sqlcmd)
        {
            DataTable dt = new DataTable();
            try
            {
                if (sqlcmd.Connection.State == ConnectionState.Open)
                {
                    cnn.Close();
                    sqlcmd.Connection = cnn;
                }
                cnn.Open();
                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.SelectCommand = sqlcmd;

                //* fill datatable using data adpter*//
                adpt.Fill(dt);

                //*dispose objects*//
                adpt.Dispose();
                cnn.Close();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return (dt);
        }


        public DataSet GetDataSet(SqlCommand sqlcmd)
        {
            DataSet dtSet = new DataSet();
            try
            {
                if (sqlcmd.Connection.State == ConnectionState.Open)
                {
                    cnn.Close();
                    sqlcmd.Connection = cnn;
                }
                cnn.Open();
                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.SelectCommand = sqlcmd;

                //* fill datatable using data adpter*//
                adpt.Fill(dtSet);

                //*dispose objects*//
                adpt.Dispose();
                //cnn.Close();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {

                cnn.Close();
            }
            return (dtSet);
        }

    }
}
