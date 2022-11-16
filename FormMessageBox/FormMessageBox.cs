using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormMessageBox
{

    public partial class FormMessageBox : Form
    {
        bool mouseDown = false;
        Point lastLocation;




        public FormMessageBox(string text, string Caption = "",MessageBoxButtons boxButtons = MessageBoxButtons.OK, MessageBoxIcon messageBoxIcon= MessageBoxIcon.None )
        {
            InitializeComponent();
            IntiializeIcon(messageBoxIcon);
            IntitializeMessageButtons(boxButtons);
            this.labelTitle.Text = Caption;
            this.button4.Text = text;
            
          
        }
        private void IntitializeMessageButtons(MessageBoxButtons boxButtons)
        {
            
                if (boxButtons == MessageBoxButtons.OK)
                {
                    this.OK();
                }
                else if (boxButtons == MessageBoxButtons.YesNo)
                {
                    this.YesNo();
                }
            
        }
        private void IntiializeIcon(MessageBoxIcon messageBoxIcon)
        {
            switch(messageBoxIcon)
            {
                case MessageBoxIcon.Error:
                    this.pBoxIcon.Image = Properties.Resources.warning1;
                    this.pBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
            }    
        }
        private void OK()
        {

            this.button2.Text = "OK";
            this.button2.DialogResult = DialogResult.OK;
            this.button1.Hide();
            this.button3.Hide();

        }
        private void YesNo()
        {
            this.button2.Hide();
            this.button1.Text = "Yes";
            button1.DialogResult = DialogResult.Yes;
            this.button3.Text = "No";
            button3.DialogResult = DialogResult.No;
        }
         public static DialogResult Show(string text)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text))
                result = msgForm.ShowDialog();
            return result;
        }
        public static DialogResult Show(string text, string caption)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text, caption))
                result = msgForm.ShowDialog();
            return result;
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text, caption, buttons))
                result = msgForm.ShowDialog();
            return result;
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult result;
            using (var msgForm = new FormMessageBox(text, caption, buttons, icon))
                result = msgForm.ShowDialog();
            return result;
        }
        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelUp_MouseDown(object sender, MouseEventArgs e)
        {

            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panelUp_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panelUp_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            panelUp_MouseMove(sender, e);

        }

        private void labelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            panelUp_MouseUp(sender, e);

        }

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            panelUp_MouseDown(sender, e);
        }
    }

}
    