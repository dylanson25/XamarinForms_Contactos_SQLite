using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sqlite1_1.Model
{
    [Table("Materias")]
    public class Materia
    {
        [PrimaryKey,  AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }

        [ManyToMany(typeof(ContactoMateria), CascadeOperations = CascadeOperation.All  )]
        public ObservableCollection<Contacto> Contactos { get; set; }
    }
}
