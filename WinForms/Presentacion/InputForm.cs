using Forms.model;
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
    public partial class InputForm : Form
    {

        public string ProductId { get; private set; }
        public string Quantity { get; private set; }
        public InputForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductId = textBox1.Text;
            
            Quantity = textBox2.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
