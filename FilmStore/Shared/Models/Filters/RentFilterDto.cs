using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Filters
{
    public class RentFilterDto
    {
        public string ClientLastName { get; set; }
        public string Title { get; set; }
        public DateTime RentDate { get; set; }
    }
}
