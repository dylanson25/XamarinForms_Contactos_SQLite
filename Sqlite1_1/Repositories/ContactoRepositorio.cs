using SQLite;
using Sqlite1_1.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace Sqlite1_1.Repositories
{
    public class ContactoRepositorio
    {
       SQLiteConnection connection;
       
        public ContactoRepositorio()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<Contacto>();
        }
        public void Init()
        {
            connection.CreateTable<Contacto>();
        }

        public void InsertOrUpdate(Contacto contacto)
        {
            if(contacto.ID == 0)
            {
                connection.Insert(contacto);
            }
            else
            {
                connection.Update(contacto);
            }
        }

        public Contacto GetById(int ID)
        {
            return connection.Table<Contacto>().FirstOrDefault(item => item.ID == ID);            
            
        }

        public List<Contacto> GetAll()
        {
            return connection.Table<Contacto>().ToList();
        }
        public void DeleteItem(int id)
        {
            Contacto contacto = GetById(id);
            connection.Delete(contacto);
        }
    }
}
