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
        static public DataTable DtSelectTeg = new DataTable();
        static public DataTable DtSortClientName = new DataTable();
        static public object CountTagofclientRows;
        static public object CountClientIDRows;
        static public void SelectClientLoad(int start)
        {
            try
            {
                MyCommand.CommandText = $"SELECT client.ID, client.FirstName, client.LastName, client.Patronymic, client.Birthday, client.RegistrationDate, client.Email, client.Phone, gender.Name FROM client, gender WHERE client.GenderCode = gender.Code ORDER BY client.ID LIMIT {start}";
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
            MyCommand.CommandText = $"SELECT COUNT(*) AS count FROM client, gender WHERE client.GenderCode = gender.Code AND client.ID BETWEEN {start} AND {finish} ORDER BY client.ID";
            CountClientIDRows = MyCommand.ExecuteScalar();
            if (Convert.ToInt32(CountClientIDRows) > 0)
            {
                MyCommand.CommandText = $"SELECT client.ID, client.FirstName, client.LastName, client.Patronymic, client.Birthday, client.RegistrationDate, client.Email, client.Phone, gender.Name FROM client, gender WHERE client.GenderCode = gender.Code AND client.ID BETWEEN {start} AND {finish} ORDER BY client.ID";
                DtClientBetween.Clear();
                MyData.Fill(DtClientBetween);
            }
        }
        static public void SelectTeg(string nomer)
        {
            MyCommand.CommandText = $"SELECT tag.ID, tag.Title, tag.Color FROM tagofclient, tag WHERE tagofclient.ClientID = '{nomer}' AND tagofclient.TagID = tag.ID";
            DtSelectTeg.Clear();
            MyData.Fill(DtSelectTeg);
        }
        static public void OtborMenWoman(string nomer)
        {
            MyCommand.CommandText = $"SELECT client.ID, client.FirstName, client.LastName, client.Patronymic, client.Birthday, client.RegistrationDate, client.Email, client.Phone, gender.Name FROM client, gender WHERE client.GenderCode = gender.Code AND gender.Code = '{nomer}' ORDER BY client.ID";
            DtOtborMenWoman.Clear();
            MyData.Fill(DtOtborMenWoman);
        }
        static public void SelectCountIDCount()
        {
            MyCommand.CommandText = $"SELECT COUNT(*) AS count FROM client";
            CountTagofclientRows = MyCommand.ExecuteScalar();
        }
        static public void SelectCountID()
        {
            MyCommand.CommandText = $"SELECT ID FROM client ORDER BY ID DESC LIMIT 1";
            CountClientIDRows = MyCommand.ExecuteScalar();
        }
        static public void SortClientName(int start, int finish)
        {
            MyCommand.CommandText = $"SELECT COUNT(*) AS count FROM client, gender WHERE client.GenderCode = gender.Code AND client.ID BETWEEN {start} AND {finish} ORDER BY client.ID";
            CountClientIDRows = MyCommand.ExecuteScalar();
            if (Convert.ToInt32(CountClientIDRows) > 0)
            {
                MyCommand.CommandText = $"SELECT client.ID, client.FirstName, client.LastName, client.Patronymic, client.Birthday, client.RegistrationDate, client.Email, client.Phone, gender.Name FROM client, gender WHERE client.GenderCode = gender.Code AND client.ID BETWEEN {start} AND {finish} ORDER BY client.FirstName ASC";
                DtSortClientName.Clear();
                MyData.Fill(DtSortClientName);
            }
        }
    }
}
