using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Kosheleva_WPF
{
    public partial class Seats
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seats()
        {
            this.Bookings = new HashSet<Bookings>();
        }

        public int SeatID { get; set; }
        public Nullable<int> HallID { get; set; }
        public int SeatRow { get; set; }
        public int SeatNumber { get; set; }
        public Nullable<bool> IsAvailable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bookings> Bookings { get; set; }
        public virtual Halls Halls { get; set; }
    }
}
