using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Models
{
    //abstract pois ela nao pode ser instanciada mas pode ser herdada
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; } 
        public bool Active { get; set; } = true;
    }
}
