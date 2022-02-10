using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolomkaProgramm
{
    public partial class MainAdministator : Form
    {
        static public bool[] mass = new bool[] { true, false, false, false };
        static public int[] numbers;
        static public bool Str10 = false;
        static public bool Str20 = false;
        static public bool Str30 = false;
        static public bool StrAll = false;
        static public bool Otbor = true;
        static public string element;
        public MainAdministator()
        {
            InitializeComponent();
            ClientClass.SelectCountIDCount();
            ClientClass.SelectClientLoad(10);
            ClientClass.SelectCountID();
            dataGridView1.DataSource = ClientClass.DtClientLoad;
            button3.Click += (s, e) =>
            {
                int i = 0;
                int[] numbers = new int[dataGridView1.Rows.Count];
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    element = dataGridView1["ID", i].Value.ToString();
                    numbers[i] = Convert.ToInt32(dataGridView1["ID", i].Value.ToString());
                }
                element = Convert.ToString(numbers.Max());
                switch (i)
                {
                    case 10:
                        if (mass[0] == true)
                        {
                            ClientClass.SelectClientBetween(Convert.ToInt32(element) + 1, Convert.ToInt32(element) + 10);
                            dataGridView1.DataSource = ClientClass.DtClientBetween;
                            Str10 = true;
                        }
                        break;
                    case 20:
                        if (mass[1] == true)
                        {
                            ClientClass.SelectClientBetween(Convert.ToInt32(element) + 1, Convert.ToInt32(element) + 20);
                            dataGridView1.DataSource = ClientClass.DtClientBetween;
                            Str20 = true;
                        }
                        break;
                    case 30:
                        if (mass[2] == true)
                        {
                            ClientClass.SelectClientBetween(Convert.ToInt32(element) + 1, Convert.ToInt32(element) + 30);
                            dataGridView1.DataSource = ClientClass.DtClientBetween;
                            Str30 = true;
                        }
                        break;
                    default:
                            ClientClass.SelectClientBetween(Convert.ToInt32(element) + 1, Convert.ToInt32(element) + 10);
                            if (Convert.ToInt32(ClientClass.CountClientIDRows) > 0)
                                dataGridView1.DataSource = ClientClass.DtClientBetween;
                        break;
                }
            };
            button2.Click += (s, e) =>
            {
                int i = 0;
                int[] numbers = new int[dataGridView1.Rows.Count];
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    element = dataGridView1["ID", i].Value.ToString();
                    numbers[i] = Convert.ToInt32(dataGridView1["ID", i].Value.ToString());
                }
                element = Convert.ToString(numbers.Min());
                switch (i)
                {
                    case 10:
                        if (mass[0] == true)
                        {
                            ClientClass.SelectClientBetween(Convert.ToInt32(element) - 10, Convert.ToInt32(element) - 1);
                            if (Convert.ToInt32(ClientClass.CountClientIDRows) > 0)
                                dataGridView1.DataSource = ClientClass.DtClientBetween;
                        }
                        else if (mass[1] == true)
                            goto case 20;
                        else if (mass[2]==true)
                            goto case 30;
                        break;
                    case 20:
                        if (mass[1] == true)
                        {
                            ClientClass.SelectClientBetween(Convert.ToInt32(element) - 20, Convert.ToInt32(element) - 1);
                            if (Convert.ToInt32(ClientClass.CountClientIDRows) > 0)
                                dataGridView1.DataSource = ClientClass.DtClientBetween;
                        }
                        else if (mass[0] == true)
                            goto case 10;
                        else if (mass[2] == true)
                            goto case 30;
                        break;
                    case 30:
                        if (mass[2] == true)
                        {
                            ClientClass.SelectClientBetween(Convert.ToInt32(element) - 30, Convert.ToInt32(element) - 1);
                            if (Convert.ToInt32(ClientClass.CountClientIDRows) > 0)
                                dataGridView1.DataSource = ClientClass.DtClientBetween;
                        }
                        else if (mass[0] == true)
                            goto case 10;
                        else if (mass[1] == true)
                            goto case 20;
                        break;
                    default:
                        if (Str10 == true & mass[0] == true)
                        {
                            ClientClass.SelectClientBetween(Convert.ToInt32(element) - 10, Convert.ToInt32(element) - 1);
                            if (Convert.ToInt32(ClientClass.CountClientIDRows) > 0)
                                dataGridView1.DataSource = ClientClass.DtClientBetween;
                            Str10 = false;
                        }
                        else if (Str20 == true & mass[1] == true)
                        {
                            ClientClass.SelectClientBetween(Convert.ToInt32(element) - 20, Convert.ToInt32(element) - 1);
                            if (Convert.ToInt32(ClientClass.CountClientIDRows) > 0)
                                dataGridView1.DataSource = ClientClass.DtClientBetween;
                            Str20 = false;
                        }
                        else if (Str30 == true & mass[2] == true)
                        {
                            ClientClass.SelectClientBetween(Convert.ToInt32(element) - 30, Convert.ToInt32(element) - 1);
                            if (Convert.ToInt32(ClientClass.CountClientIDRows) > 0)
                                dataGridView1.DataSource = ClientClass.DtClientBetween;
                            Str30 = false;
                        }
                        break;
                }
            };
            button4.Click += (s, e) =>
            {
                mass[0] = true;
                for (int i = 0; i < mass.Length; i++)
                {
                    if (i == 0)
                        continue;
                    else
                        mass[i] = false;
                }
                ProverkaTrueFals(0);
                SwitchList();
                button3.Enabled = true;
                button2.Enabled = true;
                Otbor = true;
            };
            button5.Click += (s, e) =>
            {
                mass[1] = true;
                for (int i = 0; i < mass.Length; i++)
                {
                    if (i == 1)
                        continue;
                    else
                        mass[i] = false;
                }
                ProverkaTrueFals(1);
                SwitchList();
                button3.Enabled = true;
                button2.Enabled = true;
                Otbor = true;
            };
            button6.Click += (s, e) =>
            {
                mass[2] = true;
                for (int i = 0; i < mass.Length; i++)
                {
                    if (i == 2)
                        continue;
                    else
                        mass[i] = false;
                }
                ProverkaTrueFals(2);
                SwitchList();
                button3.Enabled = true;
                button2.Enabled = true;
                Otbor = true;
            };
            button7.Click += (s, e) =>
            {
                mass[3] = true;
                for (int i = 0; i < mass.Length; i++)
                {
                    if (i == 3)
                        continue;
                    else
                        mass[i] = false;
                }
                ProverkaTrueFals(3);
                SwitchList();
                button3.Enabled = false;
                button2.Enabled = false;
                Otbor = true;
            };

        }
        private void ProverkaTrueFals(int start)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                if (i == start)
                    mass[i] = true;
                else
                    mass[i] = false;
            }
        }
        private int CurrentPage()
        {
            int CountTagofclientRows;
            CountTagofclientRows = dataGridView1.Rows.Count;
            return CountTagofclientRows;
        }
        private void SwitchList()
        {
            if (mass[0] == true)
                SelectCurrentPage(10);
            else if (mass[1] == true)
                SelectCurrentPage(20);
            else if (mass[2] == true)
                SelectCurrentPage(30);
            else if (mass[3] == true)
                SelectCurrentPage(Convert.ToInt32(ClientClass.CountTagofclientRows));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = CurrentPage().ToString();
            ClientClass.SelectCountIDCount();
            label3.Text = ClientClass.CountTagofclientRows.ToString();
        }
        private void SelectCurrentPage(int start)
        {
            ClientClass.SelectClientLoad(start);
            dataGridView1.DataSource = ClientClass.DtClientLoad;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int max, min;

            if (Otbor == true)
            {
                numbers = new int[dataGridView1.Rows.Count];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    numbers[i] = Convert.ToInt32(dataGridView1["ID", i].Value.ToString());
                }
                max = numbers.Max();
                min = numbers.Min();
                Otbor = false;
                if (comboBox1.SelectedIndex == 0)
                {
                    ClientClass.OtborMenWoman("1");
                    dataGridView1.DataSource = ClientClass.DtOtborMenWoman;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    ClientClass.OtborMenWoman("2");
                    dataGridView1.DataSource = ClientClass.DtOtborMenWoman;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    ClientClass.SelectClientBetween(numbers.Min(), numbers.Max());
                    dataGridView1.DataSource = ClientClass.DtClientBetween;
                }
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    ClientClass.OtborMenWoman("1");
                    dataGridView1.DataSource = ClientClass.DtOtborMenWoman;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    ClientClass.OtborMenWoman("2");
                    dataGridView1.DataSource = ClientClass.DtOtborMenWoman;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    ClientClass.SelectClientBetween(numbers.Min(), numbers.Max());
                    dataGridView1.DataSource = ClientClass.DtClientBetween;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1[1,i].FormattedValue.ToString().Contains(textBox1.Text.Trim()))
                {
                    dataGridView1.CurrentCell = dataGridView1[1, i];
                    return;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1[2, i].FormattedValue.ToString().Contains(textBox2.Text.Trim()))
                {
                    dataGridView1.CurrentCell = dataGridView1[2, i];
                    return;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1[3, i].FormattedValue.ToString().Contains(textBox3.Text.Trim()))
                {
                    dataGridView1.CurrentCell = dataGridView1[3, i];
                    return;
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1[6, i].FormattedValue.ToString().Contains(textBox4.Text.Trim()))
                {
                    dataGridView1.CurrentCell = dataGridView1[6, i];
                    return;
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1[7, i].FormattedValue.ToString().Contains(textBox5.Text.Trim()))
                {
                    dataGridView1.CurrentCell = dataGridView1[7, i];
                    return;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientClass.SelectTeg(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            dataGridView2.DataSource = ClientClass.DtSelectTeg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int max, min;
            numbers = new int[dataGridView1.Rows.Count];
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                numbers[i] = Convert.ToInt32(dataGridView1["ID", i].Value.ToString());
            }
            max = numbers.Max();
            min = numbers.Min();
            ClientClass.SortClientName(,);
            dataGridView1.DataSource = ClientClass.DtSortClientName;
        }
    }
}
