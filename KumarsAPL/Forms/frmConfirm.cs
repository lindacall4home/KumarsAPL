using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KumarsAPL.Forms
{

 

    public partial class frmConfirm : Form
    {
        public frmConfirm()
        {
            InitializeComponent();
        }

        public void SetConfirmText(string text)
        {
            lblText.Text = text;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Close();

        }
    }
}
