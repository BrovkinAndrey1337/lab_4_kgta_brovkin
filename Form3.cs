using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Practic_1_Degtev
{
    public partial class Form3 : Form
    {
        public Form3(Encryption enc)
        {
            InitializeComponent();
            textBox1.Text = enc.getKey();
            textBox2.Text = enc.getEncodeText();
            textBox1.ReadOnly = true;
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox2.ReadOnly = true;
            textBox2.SelectionStart = textBox1.Text.Length;
            Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(textBox1.Text));
            Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(textBox2.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("KEY.txt", string.Empty);
            File.WriteAllText("TEXT.txt", string.Empty);
            StreamWriter SW = new StreamWriter(new FileStream("KEY.txt", FileMode.OpenOrCreate, FileAccess.Write), Encoding.GetEncoding(1251));
            StreamWriter SW2 = new StreamWriter(new FileStream("TEXT.txt", FileMode.OpenOrCreate, FileAccess.Write), Encoding.GetEncoding(1251));

            SW.Write(textBox1.Text);
            SW2.Write(textBox2.Text);
            SW.Close();
            SW2.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new Form2();
            Hide();
            Close();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
