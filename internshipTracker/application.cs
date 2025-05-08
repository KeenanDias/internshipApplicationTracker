using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internshipTracker
{
    public class application
    {
        [Key]
        public int id;
        [Required] // Specifies this cannot be null
        [MaxLength(200)] // Specifies maximum length of the string
        public string OrganizationName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        public DateTime DateApplied { get; set; }

        public DateTime? InternshipStartDate { get; set; } // Nullable DateTime
    }
}
