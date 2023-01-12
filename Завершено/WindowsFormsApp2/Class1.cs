using System;

using MySql.Data.MySqlClient;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Data;

using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class DataConnection
    {
        static public DataTable vhodbb(string a)
        {
            DataTable dt = new DataTable();//Создаем DataTable
                                           //Генерация строки подключения к базе
            MySqlConnectionStringBuilder mysqlconstr = new MySqlConnectionStringBuilder();
            mysqlconstr.Server = Properties.Settings.Default.Host;//ip хоста
            mysqlconstr.Port = Properties.Settings.Default.Port;
            mysqlconstr.Database = Properties.Settings.Default.DBName;//название базы
            mysqlconstr.UserID = Properties.Settings.Default.DBUser;//имя юзера
            mysqlconstr.Password = Properties.Settings.Default.DBPass;//пасс
            mysqlconstr.CharacterSet = Properties.Settings.Default.DBCharacterSet;//кодировка соединения
                                                                                  //Описываем соединение с базой (передаем строку подключения в параметрах)
            MySqlConnection connect = new MySqlConnection(mysqlconstr.ToString());
            //Экранируем запрос
            string queryString = @a;
            //Описываем запрос (передаем строку запроса и инстанс подключения в качестве аргументов)
            MySqlCommand command = new MySqlCommand(queryString, connect);
            //Попытаемся открыть соединение и выполнить запрос - в случае ошибки - выдаем ошибку, которую выдал сервер
           try
            {
                connect.Open();//открываем соединение
                               //command.ExecuteNonQuery(); //Если требуется выполниить запрос не требующий возврата результата
                MySqlDataReader dr = command.ExecuteReader();//Выполняем команду и получаем ридер
                if (dr.HasRows)
                {
                    dt.Load(dr);//Загружаем результат в DataTable
                }
                connect.Close();//Закрываем соединение
            }

            catch (Exception ex)//Если возникла ошибка
            {
                MessageBox.Show(ex.Message);//выводим ее
            }
            return dt;//возвращаем DataTable
        }    

    }
}

