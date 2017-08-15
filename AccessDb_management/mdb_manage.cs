
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;  
namespace WindowsFormsApplication2
{
    public partial class mdb_manage : Form
    {
        String File_name;
        public mdb_manage()
        {
            InitializeComponent();
        }
        public mdb_manage(String File_path)
        {
            File_name = File_path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String db_cnstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + openFileDialog1.FileName + "'";
            OleDbConnection db_cn = new OleDbConnection(db_cnstr);
            OleDbCommand db_cmd = new OleDbCommand();
            db_cn.Open();
            db_cmd.CommandText = "alter   table   testTB   add   a   char(20)";
            db_cmd.Connection = db_cn;
            db_cmd.ExecuteNonQuery();
        }
    }
}
