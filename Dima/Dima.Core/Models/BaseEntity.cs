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
        public long Id { get; init; }
        public DateTime CreationDate { get; init; } = DateTime.Now;
        public DateTime? UpdateDate { get; private set; } 
        public bool Active { get; private set; } = true;

        public void UpdateValues() 
        {
            UpdateDate = DateTime.Now;
        }

        public void DisableEntity()
        {
            UpdateDate = DateTime.Now;
            Active = false;
        }
    }
}
