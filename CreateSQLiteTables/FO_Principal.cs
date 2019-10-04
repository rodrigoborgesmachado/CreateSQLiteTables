using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateSQLiteTables
{
    public partial class FO_Principal : Form
    {
        public FO_Principal()
        {
            InitializeComponent();
            textBox1.Enabled = false;
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text))
            {
                MessageBox.Show("Preencher um arquivo válido");
            }

            if (Util.SQLiteExecutter.CreateCommands(this.textBox1.Text))
            {
                MessageBox.Show("Gerado com sucesso!");
            }
            else
            {
                MessageBox.Show("Gerado com erro!");
            }
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog_f = new OpenFileDialog();
            
            if (dialog_f.ShowDialog() == DialogResult.OK)
                this.textBox1.Text = dialog_f.FileName.ToString();
        }
    }
}
