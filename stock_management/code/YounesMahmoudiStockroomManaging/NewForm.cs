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
    public partial class NewForm : Form
    {
        public NewForm()
        {
            InitializeComponent();
        }
        StockroomManaging sm = new StockroomManaging(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + Application.StartupPath + @"\Stockroom.mdf; Integrated Security = True");
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtcode.Text == "")
            {
                MessageBox.Show("Field is empty.please enter code...");
                txtcode.Focus();
            }
            else if (txtname.Text == "")
            {
                MessageBox.Show("Field is empty.please enter name...");
                txtname.Focus();
            }
            else if (txtcount.Text == "")
            {
                MessageBox.Show("Field is empty.please enter count...");
                txtcount.Focus();
            }
            else if (txtprice.Text == "")
            {
                MessageBox.Show("Field is empty.please enter price...");
                txtprice.Focus();
            }
            else if(sm.Check_Code(txtcode.Text))
            {
                MessageBox.Show("This code is already selected.please enter another values.");
                Console.Beep(1500,800);
                txtcode.Focus();
            } else
            {
                
                sm.Add_New_Part(txtcode.Text, txtname.Text, txtcount.Text, txtprice.Text);
                MessageBox.Show("Operation successfully done.");
                btncancel_Click(null, null);
            }        
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
