using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Kosheleva_WPF
{
    public partial class AgeRatings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AgeRatings()
        {
            this.Movies = new HashSet<Movies>();
        }

        public int AgeRatingID { get; set; }
        public string AgeRatingCode { get; set; }
        public int AgeRatingValue { get; set; }
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movies> Movies { get; set; }
    }
}
