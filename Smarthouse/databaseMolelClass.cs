using System;
using System.Collections.Generic;
using SQLite;

namespace Smarthouse
{
    public class databaseMolelClass
    {
        public static SQLiteConnection database { get; set; }

        public databaseMolelClass (string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<user>();
            database.CreateTable<device>();
            database.CreateTable<type>();
            database.CreateTable<userDevice>();
        }

        public IEnumerable<user> Getuser ()
        {
            return database.Table<user>().ToList();
        }
        public user Getuser (int id)
        {
            return database.Get<user>(id);
        }

        public int Deleteuser (int id)
        {
            return database.Delete<user>(id);
        }

        public int Saveuser (user item)
        {
            if (item.id != 0)
            {
                database.Update(item);
                return item.id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public IEnumerable<device> GetDevice ()
        {
            return database.Table<device>().ToList();
        }
        public device GetDevice (int id)
        {
            return database.Get<device>(id);
        }

        public int DeletDevice (int id)
        {
            return database.Delete<device>(id);
        }

        public int SaveDevice (device item)
        {
            if (item.id != 0)
            {
                database.Update(item);
                return item.id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public IEnumerable<type> GetType ()
        {
            return database.Table<type>().ToList();
        }
        public type GetType (int id)
        {
            return database.Get<type>(id);
        }

        public IEnumerable<userDevice> GetUserDevice ()
        {
            return database.Table<userDevice>().ToList();
        }
        public userDevice GetUserDevice (int id)
        {
            return database.Get<userDevice>(id);
        }

        public int SaveUserDevice (userDevice item)
        {
            if (item.id != 0)
            {
                database.Update(item);
                return item.id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }

    [Table("user")]
    public class user
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }
        
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string logn { get; set; }

        public string password { get; set; }

    }

    [Table("device")]
    public class device
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }

        public string name { get; set; }

        public int idType { get; set; }

        public bool isEnable { get; set; }
    }

    [Table("type")]
    public class type
    {

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }

        public string name { get; set; }

        public byte[] logo { get; set; }
    }

    [Table("userDevice")]
    public class userDevice
    {

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }

        public int idUser { get; set; }

        public int idDevice { get; set; }
    }
}


