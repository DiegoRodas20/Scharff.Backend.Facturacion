using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Domain.Entities
{
    public class ContactModel
    {
        public int Id { get; set; }
        public Boolean? Status { get; set; }
        public int IdClient { get; set; }
        public int TypeContactParameter { get; set; }
        public int AreaContactParameter { get; set; }
        public string FullName { get; set; }
        public string Commentary { get; set; }
        public DateTime? CreationDate { get; set; }
        public int AuthorCreation { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int AuthorUpdate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
