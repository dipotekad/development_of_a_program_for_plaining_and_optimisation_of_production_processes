using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            if (login == "admin" && password == "admin")
            {
                MessageBox.Show("Вы вошли в систему", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (Form2 form = new Form2())
                {
                    form.ShowDialog();
                }

                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
    }
}
