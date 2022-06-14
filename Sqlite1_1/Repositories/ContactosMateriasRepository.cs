using SQLite;
using Sqlite1_1.Model;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sqlite1_1.Repositories
{
    public class ContactosMateriasRepository
    {
        SQLiteConnection connection;
        public ContactosMateriasRepository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<ContactoMateria>();
        }

        public void Init()
        {
            connection.CreateTable<ContactoMateria>();
        }
        public void InsertOrUpdate(ContactoMateria ContactosMaterias)
        {
            if (ContactosMaterias.ID == 0)
            {
                connection.InsertWithChildren(ContactosMaterias);
            }
            else
            {
                //connection.Update(ContactosMaterias);                
                //App.ActaNacimientoDb.InsertOrUpdate(ContactosMaterias.ActaNacimiento);

                connection.InsertOrReplaceWithChildren(ContactosMaterias);

            }
        }

        public ContactoMateria GetById(int Id)
        {
            return connection.Table<ContactoMateria>().FirstOrDefault(item => item.ID == Id);
            //return connection.GetAllWithChildren<ContactosMaterias>(item => item.Id == Id).FirstOrDefault();



        }

        public List<ContactoMateria> GetAll()
        {

            return connection.GetAllWithChildren<ContactoMateria>().ToList();
        }


        public void DeleteItem(int Id)
        {
            ContactoMateria ContactosMaterias = GetById(Id);
            connection.Delete(ContactosMaterias);
        }
    }
}
