using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceManager_EntityLayer;
using System.Configuration;
using ServiceManager_DataLayer;
using System.Data.SqlClient;
using System.Data;

namespace ServiceManager_DataLayer
{
    public class dal_ServiceManager : dbOperation
    {

        public Object ServiceManager(oel_ServiceManager oel_ServiceManager)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sqlConnect"].ConnectionString;
            cnn = new SqlConnection(connectionString);
            try
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                cnn.Open();
                SqlCommand cmd = new SqlCommand("ServiceManagersDetails", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", oel_ServiceManager.Name);
                cmd.Parameters.AddWithValue("@UserCode", oel_ServiceManager.User_Code);
                cmd.Parameters.AddWithValue("@Mode", oel_ServiceManager.Mode);
                cmd.Parameters.AddWithValue("@UserID", oel_ServiceManager.UserID);
                SqlParameter errorIdParam = new SqlParameter("@Error_id", SqlDbType.VarChar, 10);
                errorIdParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorIdParam);

                if (oel_ServiceManager.ReturnDs)
                {
                    DataSet dtset = new DataSet();
                    dtset = GetDataSet(cmd);
                    return dtset;
                }
                else if (oel_ServiceManager.ReturnDt)
                {
                    DataTable dt = new DataTable();
                    dt = GetData(cmd);
                    return dt;
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    string result = string.Empty;
                    result = Convert.ToString(cmd.Parameters["@Error_id"].Value);
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("An error occurred while fetching employee details.", ex);
            }
        }

        public void closeConnection()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

        }

    }
}
