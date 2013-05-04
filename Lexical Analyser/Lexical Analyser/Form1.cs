using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lexical_Analyser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1 != null)
            {
                string a = richTextBox1.Text.Trim();
                string[] satir = a.Split('\n');

            }
            else
            {
            }
        }

    }
}
