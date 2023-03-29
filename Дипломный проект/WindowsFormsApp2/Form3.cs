using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

       

        private void Form3_Load(object sender, EventArgs e)
        {
            Obnovlenie_Karzina();//Привязка

            metroButton12.Visible = false;
            if (metroButton12.Text == "English") //Английский интерфейс
            {
                label1.Text = "Journal:";

                metroButton1.Text = "Refresh";
                metroButton2.Text = "Create";
                metroButton4.Text = "Delete";

                metroButton3.Text = "Exit";
                metroButton5.Text = "Close";
            }

        }

        public void Obnovlenie_Karzina()
        {
            DataTable data = DataConnection.vhodbb(@"SELECT * FROM table2");

            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //БД
        {
            label2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value.ToString();
            textBox11.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[10].Value.ToString();
            //// label2 перемещение информации
        }



        private void metroButton1_Click(object sender, EventArgs e)
        {
            Obnovlenie_Karzina();//Привязка
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Заполните строчки!/Fill in the lines!");
            }
            else
            {
                DataTable data = DataConnection.vhodbb(@"INSERT INTO table4 (`Название_организации`, `Контактная_информация`, `ФИО_заказчика`, `Дата`, `Количество`, `Вид_литья`, `Деталь`, `Статус`, `Дата_сдачи`, `Цена`) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "');");
                //Создание в основной таблице
                data = DataConnection.vhodbb(@"DELETE FROM table2 WHERE id=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                //Удаление из таблицы с карзиной
                Obnovlenie_Karzina();

                textBox2.Clear();

                textBox3.Clear();

                textBox4.Clear();

            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            //Сообщение
            DialogResult result = MessageBox.Show("Выйти в авторизацию?/Log out? ", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form1 fr1 = new Form1();
                fr1.Show();
                this.Hide();
            }
            else
            {
                return;
            }
        }

        private void metroButton4_Click(object sender, EventArgs e) //Удаление
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Выбрать строку!/Select row!");
            }
            else
            {
                DataTable data = DataConnection.vhodbb(@"DELETE FROM table2 WHERE id=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Obnovlenie_Karzina();//Таблица с корзиной
            }
        }

        private void metroButton5_Click(object sender, EventArgs e) //Выход
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?/Do you really want to leave?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
            else
            {
                return;
            }
        }
    }
    }
    

