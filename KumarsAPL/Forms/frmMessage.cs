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
    public partial class frmMessage : Form
    {
        public frmMessage()
        {
            InitializeComponent();
        }

        public void SetMessageText(string text)
        {
            lblText.Text = text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
