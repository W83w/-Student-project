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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
       
        private void Form4_Load(object sender, EventArgs e)
        {
            Obnovlenie_Admin(); //Привязка
            metroButton12.Visible = false;

            if (metroButton12.Text == "English") //Английский интерфейс
            {
                label7.Text = "Admin Cabinet";
                label3.Text = "Create a new user";
                label1.Text = "Login";
                label2.Text = "Password";
                label9.Text = "Full name";

                label4.Visible = false;
                label7.Visible = false;
                label3.Visible = false;

                label12.Visible = true;
                label11.Visible = true;
                label10.Visible = true;

                metroButton1.Text = "Refresh";
                metroButton2.Text = "Generation";
                metroButton10.Text = "Edit";
                metroButton4.Text = "Create";
                metroButton6.Text = "Delete";
                metroButton7.Text = "Close";
                metroButton8.Text = "Journal";
                metroButton9.Text = "User";
                metroButton3.Text = "Cleaning";
                metroButton11.Text = "Exit";

                Пользователи.Text = "Users";
                Дополнительное.Text = "Additional";

            }
            else
            {
                label12.Visible = false;
                label11.Visible = false;
                label10.Visible = false;
            }
            }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //БД 
        {
            label5.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
        }

        public void Obnovlenie_Admin()
        {
            DataTable data = DataConnection.vhodbb(@"SELECT * FROM table1");

            dataGridView1.DataSource = data;//Привязка
        }

        public void Messang_Ready()
        {
            MessageBox.Show("Готово/Ready");//Сообщение
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Obnovlenie_Admin();//Привязка
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Random r = new Random(); //Рандом
            textBox2.Text = r.Next(12345678, 99999999).ToString();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox4.Text = "";
            textBox2.Text = ""; //Очистка строк
            Obnovlenie_Admin();
        }

        private void metroButton4_Click(object sender, EventArgs e) //Создание пользователя
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("Заполните строчки!/Fill in the lines!");
            }
            else
            {
                string textsis = textBox1.Text;

                {
                    if (textsis.Length >= 8)
                    {
                        MessageBox.Show("Логин и пороль не должен содержать в себе более 7 символов/Login and password must not contain more than 7 characters");
                    }
                    else
                    {
                        DataTable data = DataConnection.vhodbb(@"INSERT INTO table1 (`Пользователь`, `Пароль`, `ФИО`) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "');");
                        Obnovlenie_Admin();
                        Messang_Ready();//ДОБАВЛЕНИЕ               
                    }                    
                }
            }
        }

        private void metroButton6_Click(object sender, EventArgs e) //Удаление
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Выбрать строку!/Select row!");
            }
            else
            {
                DataTable data = DataConnection.vhodbb(@"DELETE FROM table1 WHERE Код=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                Obnovlenie_Admin();
                Messang_Ready();
            }

        }

        private void metroButton8_Click(object sender, EventArgs e) //Журнал
        {
            Form3 fr3 = new Form3();
            fr3.Show();
        }

        private void metroButton9_Click(object sender, EventArgs e) //Пользователь
        {
            Form2 fr2 = new Form2();
            fr2.Show();
        }

        private void metroButton7_Click(object sender, EventArgs e) //Выход
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //БД
        {
            label5.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
        }

        private void metroButton10_Click(object sender, EventArgs e) //Изменить
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Выбрать строку!/Select row!");
            }
            else
            {
                DataTable data = DataConnection.vhodbb(@"UPDATE table1 SET `Пользователь` = '" + textBox1.Text + "', `Пароль` = '" + textBox2.Text + "', `ФИО` = '" + textBox4.Text + "' WHERE `Код` = " + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "");
                Obnovlenie_Admin();
                textBox2.Text = "";
                textBox1.Text = "";
                textBox4.Text = "";
                Messang_Ready();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
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
    }
}
