using BaiThi.Entity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiThi.Data
{
   public class MigrateContact
    {
        public static void CreatedContact()
        {
            var cnn = new SQLiteConnection("contact.db");
            string sqlDropContact = @"DROP TABLE IF EXISTS Contact;";
            using (var statement = cnn.Prepare(sqlDropContact))
            {
                statement.Step();
            }

            string sqlCategoryTransaction = @"CREATE TABLE IF NOT EXISTS
            Contact (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
            Name VARCHAR( 140 ),
            Phone VARCHAR( 20 )
            );
            ";

            using (ISQLiteStatement statement = cnn.Prepare(sqlCategoryTransaction))
            {
                statement.Step();
            }

            string sqlInsert = @"INSERT INTO Contact(Name, Phone) VALUES ('Hoang Nguyen','0969514098'),"+
                                                                        "('Minh Quang', '0946778772'),"+
                                                                        "('Tung Bach','0978675822'),"+
                                                                        "('Trung Kien', '09786881772')";

            using (var create = cnn.Prepare(sqlInsert))
            {

                create.Step();
            }
        }

        public static bool Save(Contact contact)
        {
            var conn = new SQLiteConnection("contact.db");
            using (var stt = conn.Prepare("INSERT INTO Contact(Name, Phone) VALUES (?, ?)"))
            {
                stt.Bind(1, contact.Name);
                stt.Bind(2, contact.Phone);
                stt.Step();
            }
            return true;
        }

        public static List<Contact> findAll()
        {
            List<Contact> list = new List<Contact>();
            var conn = new SQLiteConnection("contact.db");
            using (var stt = conn.Prepare("select * from Contact"))
            {

                while (stt.Step() == SQLiteResult.ROW)
                {
                    Contact contact = new Contact()
                    {
                        Name = (string)stt["Name"],
                        Phone = (string)stt["Phone"],
                        Id = Convert.ToInt32(stt["Id"])
                    };
                    list.Add(contact);
                }
                return list;
            }
        }

        public static List<Contact> search(string name, string phone)
        {
            var list = new List<Contact>();
            try
            {
                SQLiteConnection cnn = new SQLiteConnection("contact.db");
                var sqlString = $"select * from Contact where Name Like '%{name}%' And Phone Like '%{phone}'";
                using (var stt = cnn.Prepare(sqlString))
                {
                    while (stt.Step() == SQLiteResult.ROW)
                    {
                        var contact = new Contact()
                        {
                            Name = (string)stt["Name"],
                            Phone = (string)stt["Phone"],
                            Id = Convert.ToInt32(stt["Id"])
                        };

                        list.Add(contact);
                    }
                }
                Debug.WriteLine(list[0]);
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Co loi list" + ex);
                return null;
            }
        }
    }
}
