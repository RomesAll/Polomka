using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolomkaProgramm
{
    class ClassConnectBD
    {
        static public string ConnectionLine = "Database = polomkabd; DataSource = localhost; user = root; password = qwerty; charset = utf8";
        static public MySqlConnection MyConnect;
        static public MySqlCommand MyCommand;
        static public MySqlDataAdapter MyData;
        static public void Connvetion()
        {
            try
            {
                MyConnect = new MySqlConnection(ConnectionLine);
                MyConnect.Open();
                MyCommand = new MySqlCommand() { Connection = MyConnect};
                MyData = new MySqlDataAdapter(MyCommand);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Неудалось подключиться к бд","Ошибка",System.Windows.Forms.MessageBoxButtons.OK);
            }
        }
    }
}
