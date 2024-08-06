using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TaskNoter.Data
{
    [Table("TaskNoter")]
    public class DBTaskItems
    {
        [PrimaryKey, AutoIncrement]

        [Column("ID")]
        public int Id { get; set; }

        [Column("Task_Name")]
        public string Name { get; set; } = string.Empty;

        [Column("Task_Description")]
        public string Description { get; set; } = string.Empty;

        [Column("Completion")]
        public bool IsCompleted { get; set; }
    }
}
