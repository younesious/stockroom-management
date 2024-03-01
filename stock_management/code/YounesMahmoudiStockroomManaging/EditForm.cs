using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YounesMahmoudiStockroomManaging
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }
        public EditForm(Form1 f1)
        {
            InitializeComponent();
            string []s = f1.get_information();
            txtcode.Text = s[0];
            txtname.Text = s[1];
            txtcount.Text = s[2];
            txtprice.Text = s[3];
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnaply_Click(object sender, EventArgs e)
        {
            StockroomManaging sm = new StockroomManaging(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + Application.StartupPath + @"\Stockroom.mdf; Integrated Security = True");
            sm.Edit_Part(txtcount.Text,txtcode.Text,txtprice.Text);
            MessageBox.Show("Operation successfully done.");
            btncancel_Click(null, null);
        }
    }
}
