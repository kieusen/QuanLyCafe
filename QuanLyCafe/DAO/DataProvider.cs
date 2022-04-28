using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace QuanLyCafe.DAO
{
    public class DataProvider
    {
        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        private DataProvider()
        {

        }

        public DataTable FillData(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();
            try
            {               
                using (var con = new SqlConnection(connectionStr))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(GetParameters(query, parameters));
                    }

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(data);

                    con.Close();                    
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }

            return data;
        }

        public bool ExecuteReader(string query, object[] parameters = null)
        {
            bool hasRow = false;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(GetParameters(query, parameters));
                    }

                    // So dong anh huong cau query - ap dung cho cau Insert, Delete, Update
                    var reader = cmd.ExecuteReader();
                    hasRow = reader.HasRows;

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }

            return hasRow;
        }

        public bool ExecuteNonQuery(string query, object[] parameters = null)
        {            
            int row_affects = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(GetParameters(query, parameters));
                    }

                    // So dong anh huong cau query - ap dung cho cau Insert, Delete, Update
                   row_affects = cmd.ExecuteNonQuery();
                    
                   con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }

            return row_affects > 0;
        }

        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object data = null;

            try 
            {
                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(GetParameters(query, parameters));
                    }

                    // So dong anh huong cau query
                    data = cmd.ExecuteScalar();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }

            return data;
        }

        public SqlParameter[] GetParameters(string query, object[] parameters)
        {
            List<SqlParameter> list = new List<SqlParameter>();

            int i = 0;
            foreach (var item in query.Split(' '))
            {
                if (item.Contains('@'))
                {
                    list.Add(new SqlParameter { ParameterName = item, Value = parameters[i] });

                    i++;
                }
            }
            return list.ToArray();
        }

    }
}
