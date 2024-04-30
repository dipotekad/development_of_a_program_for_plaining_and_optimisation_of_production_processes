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
    public partial class Form3 : Form
    {
        List<Client> clients;

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

        public Form3()
        {
            InitializeComponent();

            clients = new List<Client>();
            clients.Add(new Client() { FIO = "Третьяков Клим Куприянович", PhoneNumber = "112233445566"});
            clients.Add(new Client() { FIO = "Маслов Аскольд Владиславович", PhoneNumber = "88776644322"});
            clients.Add(new Client() { FIO = "Филиппов Натан Ярославович", PhoneNumber = "999777565531" });

            dataGridView1.Columns.Add("name", "Имя");
            dataGridView1.Columns.Add("phoneNumber", "Номер телефона");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 0; i < clients.Count; i++)
            {
                dataGridView1.Rows.Add(clients[i].FIO, clients[i].PhoneNumber);
            }

            SelectRow();
        }

        private void SelectRow()
        {
            if (dataGridView1.Rows.Count <= 0) return;

            SetData(clients[SelectedIndex]);
            dataGridView1.Rows[SelectedIndex].Selected = true;
        }

        private void SetData(Client client)
        {
            textBox1.Text = client.FIO;
            textBox2.Text = client.PhoneNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client
            {
                FIO = textBox1.Text,
                PhoneNumber = textBox2.Text,
            };

            clients.Add(client);
            dataGridView1.Rows.Add(client.FIO, client.PhoneNumber);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client client = clients[SelectedIndex];
            client.FIO = textBox1.Text;
            client.PhoneNumber = textBox2.Text;
            dataGridView1.Rows[SelectedIndex].Cells[0].Value = client.FIO;
            dataGridView1.Rows[SelectedIndex].Cells[1].Value = client.PhoneNumber;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clients.RemoveAt(SelectedIndex);
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
