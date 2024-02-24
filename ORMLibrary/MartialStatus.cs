using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORMLibrary
{
    public partial class MartialStatus
    {
        public MartialStatus()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
