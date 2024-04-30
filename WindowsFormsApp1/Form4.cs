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
    public partial class Form4 : Form
    {

        List<Order> orders = new List<Order>();

        private int _selectedIndex = 0;
        private int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (value == -1) value = 0;
                _selectedIndex = value;
            }
        }


        public Form4()
        {
            InitializeComponent();

            orders = new List<Order>();
            orders.Add(new Order() { Adress = "Россия, г. Волгоград, Ленина В.И.ул., д. 9 кв.182", ReceiverName = "Цветкова Илена Витальевна" });
            orders.Add(new Order() { Adress = "Россия, г. Нижний Тагил, Озерная ул., д. 17 кв.220", ReceiverName = "Цветков Аввакум Витальевич" });
            orders.Add(new Order() { Adress = "Россия, г. Миасс, Якуба Коласа ул., д. 1 кв.156", ReceiverName = "Кулакова Юнона Дмитриевна" });

            dataGridView1.Columns.Add("adress", "Адрес");
            dataGridView1.Columns.Add("receiver", "Имя получателя");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 0; i < orders.Count; i++)
            {
                dataGridView1.Rows.Add(orders[i].Adress, orders[i].ReceiverName);
            }

            SelectRow();
        }

        private void SelectRow()
        {
            if (dataGridView1.Rows.Count <= 0) return;

            SetData(orders[SelectedIndex]);
            dataGridView1.Rows[SelectedIndex].Selected = true;
        }

        private void SetData(Order order)
        {
            textBox1.Text = order.Adress;
            textBox2.Text = order.ReceiverName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order order = new Order
            {
                Adress = textBox1.Text,
                ReceiverName = textBox2.Text,
            };

            orders.Add(order);
            dataGridView1.Rows.Add(order.Adress, order.ReceiverName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order client = orders[SelectedIndex];
            client.Adress = textBox1.Text;
            client.ReceiverName = textBox2.Text;
            dataGridView1.Rows[SelectedIndex].Cells[0].Value = client.Adress;
            dataGridView1.Rows[SelectedIndex].Cells[1].Value = client.ReceiverName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            orders.RemoveAt(SelectedIndex);
            dataGridView1.Rows.RemoveAt(SelectedIndex);
            SelectedIndex = 0;
            //SelectRow();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedIndex = e.RowIndex;
            SelectRow();
        }
    }
}
