using SQLite;
using Sqlite1_1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqlite1_1.Repositories
{
    public class ActaNacimientoRepository
    {
        SQLiteConnection connection;
        public ActaNacimientoRepository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<ActaNacimiento>();
        }
        public void Init()
        {
            connection.CreateTable<ActaNacimiento>();
        }
        public void InsertOrUpdate(ActaNacimiento acta)
        {
            if (acta.ID == 0)
            {
                connection.Insert(acta);
            }
            else
            {
                connection.Update(acta);
            }
        }
        public ActaNacimiento GetById(int ID)
        {
            return connection.Table<ActaNacimiento>().FirstOrDefault(item => item.ID == ID);

        }

        public List<ActaNacimiento> GetAll()
        {
            return connection.Table<ActaNacimiento>().ToList();
        }
        public void DeleteItem(int id)
        {
            ActaNacimiento acta = GetById(id);
            connection.Delete(acta);
        }
    }
}
