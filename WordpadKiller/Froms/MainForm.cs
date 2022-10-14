using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WordpadKiller
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            List<string> size = new() { "8","10","12","14","16","18","20","22","24","26","28","30","32","34","36","38"};
            comboBox1.Items.AddRange(FontFamily.Families.Select(f => f.Name).ToArray());
            comboBox2.Items.AddRange(Enum.GetNames(typeof(KnownColor)));
            comboBox3.DataSource = size;
        }

        private void Loadbutton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files|*.*|Text Files|*.txt";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                StreamReader sr = new(openFileDialog1.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                LoadtextBox.Text = openFileDialog1.FileName;
            }
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                StreamWriter sw = new(saveFileDialog1.FileName);
                sw.Write(richTextBox1.Text);
                SavetextBox.Text = saveFileDialog1.FileName;
            }
        }

        private void LeftbuttonAlg_Click(object sender, EventArgs e)
        {
            richTextBox1.RightToLeft = RightToLeft.No;
        }

        private void RightbuttonAlg_Click(object sender, EventArgs e)
        {
            richTextBox1.RightToLeft = RightToLeft.Yes;
        }

        private void Centerbuttonalg_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(comboBox1.Font, FontStyle.Bold);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(comboBox1.Font, FontStyle.Underline);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(comboBox1.Font, FontStyle.Italic);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentsize = comboBox3.Text;
            richTextBox1.Font = new Font(comboBox1.Text ,float.Parse(currentsize));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color color = Color.FromName(comboBox2.Text);
            richTextBox1.ForeColor = color;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentsize = comboBox3.Text;
            richTextBox1.Font = new Font(comboBox1.Text, float.Parse(currentsize));
        }
    }
}
