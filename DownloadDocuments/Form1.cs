using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadDocuments
{
    public partial class Form1 : Form
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["SQLConnectionString1"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Download_Click(object sender, EventArgs e)
        {
            try
            {
                // Get Data from Database 
                DataTable dttable = GetDataFromDatabase();

            }
            catch(Exception ex)
            {

            }
        }
        
        //Get Data from Procedure
        public DataTable GetDataFromDatabase()
        {
            DataView dtview = new DataView();
            dtview.Sort = "TermianlId";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionstring;
            con.Open();
            SqlCommand cmd = new SqlCommand("[dbo].[GetAllDocumentsIds]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(dt);
            return dt;
        }
    }
}
