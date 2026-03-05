using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Kosheleva_WPF
{
    public partial class Movies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movies()
        {
            this.MovieGenres = new HashSet<MovieGenres>();
            this.Sessions = new HashSet<Sessions>();
        }

        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Rating { get; set; }
        public string PosterPath { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> AgeRatingID { get; set; }

        public virtual AgeRatings AgeRatings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieGenres> MovieGenres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sessions> Sessions { get; set; }
    }
}
