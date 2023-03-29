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
using MySql.Data.MySqlClient;
using MetroFramework.Components;
using MetroFramework.Forms;


namespace WindowsFormsApp2
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();

            PassBox.PasswordChar = '*';

            HostBox.Text = Properties.Settings.Default.Host; //Хост
            PortUpDown.Value = Properties.Settings.Default.Port; //Порт
            DbNameBox.Text = Properties.Settings.Default.DBName; //Имя БД
            UserBox.Text = Properties.Settings.Default.DBUser; //Логин
            PassBox.Text = Properties.Settings.Default.DBPass;//Пароль
            CharsetBox.Text = Properties.Settings.Default.DBCharacterSet;//Кодировка соединения
            comboBox1.Text = Properties.Settings.Default.Langv; //Язык

        }
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink; //Часы
            MaximizeBox = false;
            if (metroButton1.Text == "Вход") // Выбор языка
            {
                comboBox1.Text = "Russian";
                Properties.Settings.Default.Langv = comboBox1.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
       
        }

        private void SaveButton_Click(object sender, EventArgs e) //Сохранение
        {
            Properties.Settings.Default.Host = HostBox.Text; //Хост
            Properties.Settings.Default.Port = Convert.ToUInt32(PortUpDown.Value); //Порт
            Properties.Settings.Default.DBName = DbNameBox.Text; //Имя БД
            Properties.Settings.Default.DBUser = UserBox.Text; //Логин
            Properties.Settings.Default.DBPass = PassBox.Text; //Пароль
            Properties.Settings.Default.DBCharacterSet = CharsetBox.Text; //Кодировка соединения
            Properties.Settings.Default.Langv = comboBox1.Text; //Язык
            Properties.Settings.Default.Save(); //Сохранение

            if (comboBox1.Text == "English") //Английский интерфейс
            {
                metroButton1.Text = "Enter";
                metroButton2.Text = "Close";
                label4.Text = "Login";
                label3.Text = "Password";
               
                label8.Text = "DB Name";
                label9.Text = "Login";
                label10.Text = "Password";
                label11.Text = "Coding";
                button5.Text = "Connect";

                tabPage1.Text = "Login";
                tabPage2.Text = "Customization";

            }
            else if (metroButton1.Text == "Enter")
            {
                MessageBox.Show("Перезагрузите программу!"); //Ошибка
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnectionStringBuilder mysqlconstr = new MySqlConnectionStringBuilder();

                mysqlconstr.Server = HostBox.Text;//ip хоста
                mysqlconstr.Port = Convert.ToUInt32(PortUpDown.Value);
                mysqlconstr.Database = DbNameBox.Text;//Название БД
                mysqlconstr.UserID = UserBox.Text;//Логин
                mysqlconstr.Password = PassBox.Text;//Пароль
                mysqlconstr.CharacterSet = CharsetBox.Text;//Кодировка соединения
                //Описываем соединение с базой (передаем строку подключения в параметрах)
                MySqlConnection connect = new MySqlConnection(mysqlconstr.ToString());

                connect.Open();

                if (connect.State == ConnectionState.Open)
                {
                    MessageBox.Show("Подключение прошло успешно!/Connection was successful!");// Подключение прошло успешно
                }
                else
                {
                    MessageBox.Show("Не удалось открыть соединение/Could not open connection");// Не удалось открыть соединение
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии соединения!/Error opening connection! " + ex.ToString()); //Ошибка подключения
           }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            if ((textBox1.Text == "admin1234") && (textBox2.Text == "admin1234"))//Логин и пароль администратора
            {
                Form4 fr4 = new Form4();
                fr4.Show();
                this.Hide();
            }
            else // Или авторизация пользователя
            {
              DataTable data = DataConnection.vhodbb("SELECT * FROM table1 WHERE Пользователь = '" + textBox1.Text + "' AND Пароль = '" + textBox2.Text + "'");
              if (/*dataGridView1.RowCount*/ data.Rows.Count == 1)

                {
                    Form2 f2 = new Form2();
                    f2.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль/Incorrect login or password"); //Ошибка
                }

            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?/Do you really want to leave?", "Output", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) //Выбор 
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


