using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Kosheleva_WPF
{
    public partial class Bookings
    {
        public int BookingID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> SessionID { get; set; }
        public Nullable<int> SeatID { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public virtual Seats Seats { get; set; }
        public virtual Sessions Sessions { get; set; }
        public virtual Users Users { get; set; }
    }
}
