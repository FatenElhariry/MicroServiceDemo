using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Kernal.Models
{
    public class Entity
    {
        public long Id { get; set; }

        // Audit 
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public long DeletedBy { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Entity)) return false;
            
            return Id == (obj as Entity)?.Id;
        }

        public static bool operator ==(Entity a, Entity b) => a.Equals(b);
        public static bool operator !=(Entity a, Entity b) => !a.Equals(b);

            

    }
}
