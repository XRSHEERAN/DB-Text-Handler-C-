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
    
    public partial class db_navigation : Form
    {
      
        public db_navigation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Run(new mdb_manage(openFileDialog1.FileName));
            
            

        }
        /// <summary>
        /// choose database to be managed. "Access" database only with the restriction on file type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Access 2003 DB|*.mdb|Access 2007+ DB|*.accdb"; //restrictions
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = "Selected: " + openFileDialog1.SafeFileName;
            
        }
    }
}
