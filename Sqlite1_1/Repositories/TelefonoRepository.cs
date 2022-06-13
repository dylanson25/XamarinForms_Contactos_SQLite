using SQLite;
using Sqlite1_1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqlite1_1.Repositories
{
    public class TelefonoRepository
    {
        SQLiteConnection connection;
        public TelefonoRepository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<Telefono>();
        }
        public void Init()
        {
            connection.CreateTable<Telefono>();
        }
        public void InsertOrUpdate(Telefono Tel)
        {
            if (Tel.ID == 0)
            {
                connection.Insert(Tel);
            }
            else
            {
                connection.Update(Tel);
            }
        }
        public Telefono GetById(int ID)
        {
            return connection.Table<Telefono>().FirstOrDefault(item => item.ID == ID);

        }

        public List<Telefono> GetAll()
        {
            return connection.Table<Telefono>().ToList();
        }
        public void DeleteItem(Telefono telefono)
        {
            
            connection.Delete(telefono);
        }
        public void DeleteItem(int id)
        {
            Telefono tel = GetById(id);
            connection.Delete(tel);
        }
    }
}
