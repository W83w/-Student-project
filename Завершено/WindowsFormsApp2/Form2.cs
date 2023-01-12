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
using System.IO;

using System.Data.SqlClient;



namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            metroTextBox1.Text = Properties.Settings.Default.check;//Чек
            metroTextBox2.Text = Properties.Settings.Default.export;//Експорт таблицы
        }
   
        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start(); // Время
            label3.Text = DateTime.Now.ToLongTimeString();
            label4.Text = DateTime.Now.ToShortDateString();
            DataTable data = DataConnection.vhodbb(@"SELECT * FROM table4"); //БД
            textBox5.Text = label4.Text;
            textBox7.Text = "00.00.0000";  //Настройки
            comboBox3.Text = "Новый";

            Privazka();

            if (metroButton12.Text == "English") //Английский интерфейс
            {
                label1.Text = "Search: ";
                metroButton1.Text = "Refresh";
                metroButton3.Text = "Export";
                metroButton11.Text = "Check";
                metroButton2.Text = "Exit";
                metroButton4.Text = "Close";
                metroButton6.Text = "Refresh";
                metroButton7.Text = "Create";
                metroButton8.Text = "Edit";
                metroButton9.Text = "Clear";
                metroButton10.Text = "Delete";
                label14.Visible = false;  //
                label18.Visible = true;  //


                label5.Text = "Name of the organization";
                label6.Text = "Contact Information";
                label7.Text = "Full name of customer";
                label8.Text = "Date";
                label9.Text = "Quantity";
                label10.Text = "Type of casting";
                label11.Text = "Detail";
                label12.Text = "Status";
                label13.Text = "Date of completion";
                label16.Text = "Location";
                label17.Text = "Location";
                label19.Text = "Price";

                tabPage1.Text = "Main";
                tabPage2.Text = "Additional";
                tabPage3.Text = "Site";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "") //Ошибка
            {
                MessageBox.Show("Задайте параметр поиска / Set search parameter");
            }
            else //Поиск
            {
                DataTable data = DataConnection.vhodbb(@"SELECT * FROM table4 WHERE " + comboBox2.Text + " LIKE '" + "%" + textBox1.Text + "%" + "';");

                dataGridView1.DataSource = data;
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //Данные из БД
        {
            label2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
            textBox7.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value.ToString();
            textBox9.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[10].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) //Время
        {
            string s = DateTime.Now.ToString("dd MMM yyyy | HH:mm:ss"); //Дата
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e) //Дата
        {
            label3.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        //Фильтер для поиска

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        public void information_o_zapolnrnie()
        {
            information_o_zapolnrnie();
        }


        private void label14_Click(object sender, EventArgs e) //Переход
        {
            Form5 fr5 = new Form5();
            fr5.Show();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
         
        }

      
        private void ToCsV(DataGridView dGV, string filename) //Экспорт
        {
            string stOutput = "";
             // Экспорт заголовков:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Экспорт данных.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf8 = Encoding.UTF8;
            byte[] output = utf8.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); // Пишем закодированный файл
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Privazka();//Привязка
            textBox5.Text = label4.Text;
            textBox7.Text = "00.00.0000";
            comboBox3.Text = "Новый";
         }

        public void DialogBoxVexodsforme()//Выход
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



        private void metroButton2_Click(object sender, EventArgs e) //Выход
        {
            DialogBoxVexodsforme();//Выход

        }
         
        public void DialogBoxVexodpolnei()//Выход из программы
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?/Do you really want to leave? ", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }


        private void metroButton4_Click(object sender, EventArgs e) //Выход из программы
        {
            DialogBoxVexodpolnei();
        }

        private void metroButton3_Click(object sender, EventArgs e) //Экспорт
        {
           
            Properties.Settings.Default.export = metroTextBox2.Text;
            Properties.Settings.Default.Save();

            string filename = metroTextBox2.Text;
            ToCsV(dataGridView1, filename);
            MessageBox.Show("Готово:/Ready: " + filename);
        }

       public void Privazka()
        {
            DataTable data = DataConnection.vhodbb(@"SELECT * FROM table4");

            dataGridView1.DataSource = data;//Привязка
        }//Привязка


        private void metroButton6_Click(object sender, EventArgs e) //Обновление
        {
            Privazka();
            textBox5.Text = label4.Text;
            textBox7.Text = "00.00.0000";
            comboBox3.Text = "Новый";
        }

        static void ErorZAPOLNISTRING() //Ошибка заполните строчки
        {
           MessageBox.Show("Заполните строчки!/Fill in the lines!");

        }
        static void Ready()//Сообщкние о готовности
        {
            MessageBox.Show("Готово/Ready");

        }
          
        private void metroButton7_Click(object sender, EventArgs e) //Создание
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                ErorZAPOLNISTRING();
            }
            else
            {
                if (textBox7.Text == "" || textBox9.Text == "")
                {
                    textBox7.Text = "00.00.0000";
                    textBox9.Text = "None";
                   
                    DataTable data = DataConnection.vhodbb(@"INSERT INTO table4 (`Название_организации`, `Контактная_информация`, `ФИО_заказчика`, `Дата`, `Количество`, `Вид_литья`, `Деталь`, `Статус`, `Дата_сдачи`, `Цена`) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox8.Text + "', '" + comboBox3.Text + "', '" + textBox7.Text + "', '" + textBox9.Text + "');");

                    data = DataConnection.vhodbb(@"SELECT * FROM table4");

                    textBox2.Clear();

                    textBox3.Clear();

                    textBox4.Clear();

                    dataGridView1.DataSource = data;
                    /// @"INSERT INTO Users (`Название_организации`, `Контактная_информация`, `ФИО_заказчика`, `Дата`, `Количество`, `Вид_литья`, `Деталь`, `Статус`, `Дата_сдачи`) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox8.Text + "', '" + comboBox3.Text + "', '" + textBox7.Text + "');";
                    MessageBox.Show("Готово/Ready");
                }
                else
                {
                   
                    DataTable data = DataConnection.vhodbb(@"INSERT INTO table4 (`Название_организации`, `Контактная_информация`, `ФИО_заказчика`, `Дата`, `Количество`, `Вид_литья`, `Деталь`, `Статус`, `Дата_сдачи`, `Цена`) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox8.Text + "', '" + comboBox3.Text + "', '" + textBox7.Text + "', '" + textBox9.Text + "');");

                    data = DataConnection.vhodbb(@"SELECT * FROM table4");

                    textBox2.Clear();

                    textBox3.Clear();

                    textBox4.Clear();

                    dataGridView1.DataSource = data;
                    /// @"INSERT INTO Users (`Название_организации`, `Контактная_информация`, `ФИО_заказчика`, `Дата`, `Количество`, `Вид_литья`, `Деталь`, `Статус`, `Дата_сдачи`) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox8.Text + "', '" + comboBox3.Text + "', '" + textBox7.Text + "');";
                    Ready();
                }
            }

        }
       
        private void metroButton8_Click(object sender, EventArgs e) //Редактирование
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                ErorZAPOLNISTRING();
            }
            else
            {
                if (textBox7.Text == "" || textBox9.Text == "")
                {
                    textBox7.Text = "00.00.0000";
                    textBox9.Text = "None";
                    ForClass();
                    Ready();
                }
                else
                {
                    ForClass();
                    Ready();
                }

            }
        }

        public void ForClass()//Чтобы кода меньше было
        {
          
                DataTable data = DataConnection.vhodbb(@"UPDATE table4 SET `Название_организации` = '" + textBox2.Text + "', `Контактная_информация` = '" + textBox3.Text + "', `ФИО_заказчика` = '" + textBox4.Text + "', `Дата` = '" + textBox5.Text + "', `Количество` = '" + textBox6.Text + "', `Вид_литья` = '" + comboBox1.Text + "', `Деталь` = '" + textBox8.Text + "' , `Статус` = '" + comboBox3.Text + "' , `Дата_сдачи` = '" + textBox7.Text + "' , `Цена` = '" + textBox9.Text + "' WHERE `id` = " + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "");
                data = DataConnection.vhodbb(@"SELECT * FROM table4");
                dataGridView1.DataSource = data;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            
        }

         private void metroButton9_Click(object sender, EventArgs e) //Очистка
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void metroButton10_Click(object sender, EventArgs e) //Удаление
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Выбрать строку!/Select row!");
            }
            else
            {
                DataTable data = DataConnection.vhodbb(@"INSERT INTO table2 (`id`, `Название_организации`, `Контактная_информация`, `ФИО_заказчика`, `Дата`, `Количество`, `Вид_литья`, `Деталь`, `Статус`, `Дата_сдачи`, `Цена`) VALUES ('" + label2.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox8.Text + "', '" + comboBox3.Text + "', '" + textBox7.Text + "', '" + textBox9.Text + "');");

                data = DataConnection.vhodbb(@"DELETE FROM table4 WHERE id=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                data = DataConnection.vhodbb(@"SELECT * FROM table4");
                dataGridView1.DataSource = data;

                Ready();
            }
        }

        private void button1_Click_1(object sender, EventArgs e) //Чек
        {
            StreamWriter sw = new StreamWriter(@"Чек.doc");
            sw.WriteLine("Добро пожаловать");
            sw.WriteLine(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox8.Text, textBox7.Text);
            sw.WriteLine(textBox3.Text);
            sw.WriteLine(textBox4.Text);
            sw.WriteLine("Дата");
            sw.WriteLine(textBox5.Text);
            sw.WriteLine("Количество");
            sw.WriteLine(textBox6.Text);
            sw.WriteLine("Деталь");
            sw.WriteLine(textBox8.Text);
            sw.WriteLine(textBox7.Text);
            sw.WriteLine(textBox3.Text);

            sw.Close();

            Ready();
        }

        private void metroButton11_Click(object sender, EventArgs e)  //Чек
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                ErorZAPOLNISTRING();
            }
            else
            { 
                DialogResult result = MessageBox.Show("Вы хотите распечатать чек?/Do you want to print a check?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                    Properties.Settings.Default.check = metroTextBox1.Text;

                    Properties.Settings.Default.Save();
                    StreamWriter sw = new StreamWriter(metroTextBox1.Text);
                    //StreamWriter sw = new StreamWriter(@"Чек.doc");
                        sw.WriteLine("Добро пожаловать");
                        sw.WriteLine(textBox2.Text);
                        sw.WriteLine(textBox3.Text);
                        sw.WriteLine("ФИО");
                        sw.WriteLine(textBox4.Text);
                        sw.WriteLine("Дата");
                        sw.WriteLine(textBox5.Text);
                        sw.WriteLine("Количество");
                        sw.WriteLine(textBox6.Text);
                        sw.WriteLine("Деталь");
                        sw.WriteLine(textBox8.Text);
                       sw.WriteLine("Цена");
                       sw.WriteLine(textBox9.Text);
                        sw.WriteLine("Дата формирования чека");
                        sw.WriteLine(label3.Text);
                        sw.WriteLine(label4.Text);
                        sw.WriteLine("Спасибо за покупку");
                    
                        sw.Close();
                     MessageBox.Show("Готово:/Ready: " + metroTextBox1.Text);
                                        }
                    else
                    {
                        return;
                    }
                }

            }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox5.Text = label4.Text; //Дата
        }

        private void metroButton12_Click(object sender, EventArgs e) 
        {
            if (metroButton12.Text == "Rus")
            {
                label10.Text = "werwer";
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            information_o_zapolnrnie();//Переход
         }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            metroTextBox1.Text = "Чек.doc";
            metroTextBox2.Text = "Отчет.doc";


            Properties.Settings.Default.check = metroTextBox1.Text;
          
            Properties.Settings.Default.export = metroTextBox2.Text;
            Properties.Settings.Default.Save();
        }
    }
    }
    





