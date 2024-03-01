using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YounesMahmoudiStockroomManaging
{
    public partial class Form1 : Form
    {
        StockroomManaging sm = new StockroomManaging(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\Stockroom.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowData(null, null);
        }
        void ShowData(string srch = null,string srchtype = null)
        {
            dataGridView1.DataSource = sm.ReturnInformation(srch,srchtype);
            if(dataGridView1.RowCount > 0)
            {
                btndelete.Enabled = true;
                btnedit.Enabled = true;
            }
            else
            {
                btndelete.Enabled = false;
                btnedit.Enabled = false;
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            ShowData(txtsearch.Text,cmbsearch.Text);
        }

        private void cmbsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsearch.Enabled = true;
            txtsearch.Focus();
            txtsearch.Text = null;
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            NewForm nf = new NewForm();
            nf.ShowDialog();
            ShowData();
            string flg = dataGridView1.RowCount.ToString();
            int flag = Convert.ToInt16(flg);
            dataGridView1.CurrentCell = dataGridView1.Rows[flag-1].Cells[0];
        }
       public string[] get_information()
        {
            string[] str = { dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[3].Value.ToString()};
            return str;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            int flag = dataGridView1.CurrentRow.Index;
            EditForm ef = new EditForm(this);
            ef.ShowDialog();
            ShowData();
            dataGridView1.CurrentCell = dataGridView1.Rows[flag].Cells[0];
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            
            DialogResult dr = MessageBox.Show("Do you want to delete " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "?", "Delete", MessageBoxButtons.YesNo);
             if(dr == DialogResult.Yes)
            {
                sm.Delete_Part(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                ShowData();
            }
        }
    }
}
