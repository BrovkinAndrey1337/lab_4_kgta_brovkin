using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practic_1_Degtev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 encrypt = new Form2();
            encrypt.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form4();
            Hide();
            form.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool flag = true;
            try
            {
                Encryption test = new Encryption("#привет");
                flag = false;
            }
            catch (Exception ex) { }
            try
            {
                Encryption test = new Encryption("");
                flag = false;
            }
            catch (Exception ex) { }
            try
            {
                Encryption test = new Encryption("сос мыслом&");
                flag = false;
            }
            catch (Exception ex) {}
            try
            {
                Encryption test = new Encryption("одна из этих бyкв на английской раскладке");
                flag = false;
            }
            catch (Exception ex) { }
            if (flag == true)
                MessageBox.Show("Тест успешно проведен");
            else
                MessageBox.Show("Тест провален");
        }
    }
}
