using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DailyTask.Models
{
    public class TareaModel
    {
        public enum listac { estudio, personal, trabajo, otros }
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }

        public string NombreTarea { get; set; }

        public listac Categoria { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }
    }
}
