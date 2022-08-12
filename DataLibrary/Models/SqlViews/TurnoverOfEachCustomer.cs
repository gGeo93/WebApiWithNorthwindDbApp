using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLibrary.Models
{
    [Keyless]
    public class TurnoverOfEachCustomer
    {
        public string CustomerID { get; set; } = null!;
        public float? Turnover { get; set; }
    }
}
