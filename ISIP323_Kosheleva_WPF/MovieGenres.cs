using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Kosheleva_WPF
{
    public partial class MovieGenres
    {
        public int MovieID { get; set; }
        public int GenreID { get; set; }
        public string Description { get; set; }

        public virtual Genres Genres { get; set; }
        public virtual Movies Movies { get; set; }
    }
}
