using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms.Presentacion
{
    public partial class InputBoxForm : Form
    {
        public string InputText { get; private set; }
        public InputBoxForm(string prompt)
        {
            InitializeComponent();
            lblPrompt.Text = prompt;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            InputText = txtInput.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
