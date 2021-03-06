using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqlite1_1.Model
{
    [Table("ActasNacimiento")]
    public class ActaNacimiento
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime FechaNacimiento { get; set; }

        [ForeignKey(typeof(Contacto))]
        public int FKActaNacimientoId { get; set; }
    }
}
