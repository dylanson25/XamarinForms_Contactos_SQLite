using SQLite;
using Sqlite1_1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqlite1_1.Repositories
{
    public class MateriaRepository
    {
        SQLiteConnection connection;

        public MateriaRepository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<Materia>();
            
        }
        private void AgregaDesdeInicio(string nombre)
        {
            Materia materia = GetByNombre(nombre);
            if(materia == null)
            {
                InsertOrUpdate(new Materia() { Nombre = nombre });
            }
        }
        public void Init()
        {
            connection.CreateTable<Materia>();
            AgregaDesdeInicio("MATEMATICAS");
            AgregaDesdeInicio("POO");
            AgregaDesdeInicio("ESTRUCTURA DE DATOS");
            AgregaDesdeInicio("BASE DE DATOS");
            AgregaDesdeInicio("INGIENERIA DE SOFTWARE");
            AgregaDesdeInicio("CONTROL DE CALIDAD");
            AgregaDesdeInicio("DESARROLLO DE APP");
            AgregaDesdeInicio("METODOS NUMERICS");
            AgregaDesdeInicio("PROBALIDAD Y ESTADISTICA");
            AgregaDesdeInicio("ALGEBRA");
            AgregaDesdeInicio("DESARROLLO WEB");
            AgregaDesdeInicio("DISEÑO DE INTERFAZ");
        }
        public void InsertOrUpdate(Materia materia)
        {
            if (materia.ID == 0)
            {
                connection.Insert(materia);
            }
            else
            {
                connection.Update(materia);
            }
        }
        public Materia GetById(int ID)
        {
            return connection.Table<Materia>().FirstOrDefault(item => item.ID == ID);

        }
       public Materia GetByNombre(string nombre)
       {
            return connection.Table<Materia>().FirstOrDefault(item => item.Nombre == nombre);

       }

        public List<Materia> GetAll()
        {
            return connection.Table<Materia>().ToList();
        }
        public void DeleteItem(Materia materia)
        {

            connection.Delete(materia);
        }
        public void DeleteItem(int id)
        {
            Materia tel = GetById(id);
            connection.Delete(tel);
        }
    }
}
