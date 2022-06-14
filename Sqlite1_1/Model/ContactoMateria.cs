using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqlite1_1.Model
{
    [Table("ContactosMaterias")]
    public class ContactoMateria
    {
        public int ID { get; set; }

        [ForeignKey(typeof(Contacto))]
        public int FKContactoId { get; set; }
        
        [ForeignKey(typeof(Materia))]
        public int FKMateriaId { get; set; }
    }
}
