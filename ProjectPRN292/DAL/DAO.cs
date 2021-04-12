using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;

namespace ProjectPRN292.DAL
{
    class DAO
    {
        static string strConn = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        static public SqlConnection conn = new SqlConnection(strConn);

        static public DataTable GetDataTable(string sqlSelect)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        static public DataTable GetDataTable(SqlCommand cmd)
        {

            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = new SqlConnection(strConn);
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        static public bool UpdateTable(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return false;
            }

        }

        static public List<int> getListData(SqlCommand cmd)
        {

            List<int> ls = new List<int>();

            conn.Open();
            cmd.Connection = conn;
            SqlDataReader dr = cmd.ExecuteReader();

            cmd.Connection = conn;

            while (dr.Read())
                ls.Add(dr.GetInt32(0));
            conn.Close();
            return ls;

        }
        static public List<string> getListString(SqlCommand cmd)
        {
            List<string> ls = new List<string>();

            conn.Open();
            cmd.Connection = conn;
            SqlDataReader dr = cmd.ExecuteReader();

            cmd.Connection = conn;

            while (dr.Read())
                ls.Add(dr.GetString(0));
            conn.Close();
            return ls;
        }
    }
}





