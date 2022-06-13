using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqlite1_1.Model
{
    [Table("Telefonos")]
    public class Telefono
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Numero { get; set; }
        
        [ForeignKey(typeof(Contacto))]
        public int FKContactoId { get; set; }
    }
}
