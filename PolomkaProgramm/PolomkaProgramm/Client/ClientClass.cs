using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolomkaProgramm
{
    class ClientClass : ClassConnectBD
    {
        static public DataTable DtClientLoad = new DataTable();
        static public DataTable DtClientBetween = new DataTable();
        static public DataTable DtOtborMenWoman = new DataTable();
        static public object CountTagofclientRows;
        static public object CountClientIDRows;
        static public void SelectClientLoad(int start)
        {
            try
            {
                MyCommand.CommandText = $"SELECT client.ID, client.FirstName, client.LastName, client.Patronymic, client.Birthday, client.RegistrationDate, client.Email, client.Phone, gender.Name, tag.Title, tag.Color FROM client, gender, tagofclient, tag WHERE client.GenderCode = gender.Code AND client.ID = tagofclient.ClientID AND tagofclient.TagID = tag.ID ORDER BY tagofclient.ClientID LIMIT {start}";
                DtClientLoad.Clear();
                MyData.Fill(DtClientLoad);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка в запросе, неудалось вывести таблицу с клиентами", "Ошибка", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        static public void SelectClientBetween(int start,int finish)
        {
            MyCommand.CommandText = $"SELECT COUNT(*) AS count FROM client, gender, tagofclient, tag WHERE client.GenderCode = gender.Code AND client.ID = tagofclient.ClientID AND tagofclient.TagID = tag.ID AND tagofclient.ClientID BETWEEN {start} AND {finish} ORDER BY tagofclient.ClientID";
            CountClientIDRows = MyCommand.ExecuteScalar();
            if (Convert.ToInt32(CountClientIDRows) > 0)
            {
                MyCommand.CommandText = $"SELECT client.ID, client.FirstName, client.LastName, client.Patronymic, client.Birthday, client.RegistrationDate, client.Email, client.Phone, gender.Name, tag.Title, tag.Color FROM client, gender, tagofclient, tag WHERE client.GenderCode = gender.Code AND client.ID = tagofclient.ClientID AND tagofclient.TagID = tag.ID AND tagofclient.ClientID BETWEEN {start} AND {finish} ORDER BY tagofclient.ClientID";
                DtClientBetween.Clear();
                MyData.Fill(DtClientBetween);
            }
        }
        static public void OtborMenWoman(string nomer)
        {
            MyCommand.CommandText = $"SELECT client.ID, client.FirstName, client.LastName, client.Patronymic, client.Birthday, client.RegistrationDate, client.Email, client.Phone, gender.Name, tag.Title, tag.Color FROM client, gender, tagofclient, tag WHERE client.GenderCode = gender.Code AND client.ID = tagofclient.ClientID AND tagofclient.TagID = tag.ID AND gender.Code = '{nomer}' ORDER BY tagofclient.ClientID";
            DtOtborMenWoman.Clear();
            MyData.Fill(DtOtborMenWoman);
        }
        static public void SelectCountIDCount()
        {
            MyCommand.CommandText = $"SELECT COUNT(*) AS count FROM tagofclient";
            CountTagofclientRows = MyCommand.ExecuteScalar();
        }
        static public void SelectCountID()
        {
            MyCommand.CommandText = $"SELECT ClientID FROM tagofclient ORDER BY ClientID DESC LIMIT 1";
            CountClientIDRows = MyCommand.ExecuteScalar();
        }
    }
}
