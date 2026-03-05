using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Kosheleva_WPF
{
    public partial class Sessions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sessions()
        {
            this.Bookings = new HashSet<Bookings>();
        }

        public int SessionID { get; set; }
        public Nullable<int> MovieID { get; set; }
        public Nullable<int> HallID { get; set; }
        public System.DateTime SessionDate { get; set; }
        public System.TimeSpan SessionTime { get; set; }
        public decimal Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bookings> Bookings { get; set; }
        public virtual Halls Halls { get; set; }
        public virtual Movies Movies { get; set; }
    }
}
