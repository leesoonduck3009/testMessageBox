using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormMessageBox
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMessageBox formMessageBox = new FormMessageBox("Show thông tin thành công mỹ mãn", "Thông báo", MessageBoxButtons.OK);
            formMessageBox.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            DialogResult dialog = FormMessageBox.Show("Bạn sẽ mất thông tin này","Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Error);
            if(dialog == DialogResult.Yes)
            {
                FormMessageBox messageBox = new FormMessageBox("Thanh cong");
                messageBox.ShowDialog();
            }  
            
        }
    }
}
