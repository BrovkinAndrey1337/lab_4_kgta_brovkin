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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practic_1_Degtev
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выбор файла";
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox1.Text = File.ReadAllText(ofd.FileName, Encoding.GetEncoding(1251));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно открыть файл: " + ex.Message);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Ошибка: Введите текст и ключ");
            else
            {
                try
                {
                    var bytes = Encoding.Default.GetBytes(textBox1.Text);
                    var convertedData = Encoding.UTF8.GetString(bytes);
                    var bytes2 = Encoding.Default.GetBytes(textBox2.Text);
                    var convertedData2 = Encoding.UTF8.GetString(bytes);
                    Encryption enc = new Encryption(textBox2.Text, textBox1.Text);
                    MessageBox.Show(enc.Decode());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выбор файла";
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox2.Text = File.ReadAllText(ofd.FileName, Encoding.GetEncoding(1251));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно открыть файл: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form form = new Form1();
            Hide();
            form.ShowDialog();
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

