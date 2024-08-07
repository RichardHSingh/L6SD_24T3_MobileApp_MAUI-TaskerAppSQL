using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNoter.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class MyTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public bool Completed { get; set; }
        public int CategoryId { get; set; }
        public string TaskColor { get; set; } = string.Empty;
    }
}
