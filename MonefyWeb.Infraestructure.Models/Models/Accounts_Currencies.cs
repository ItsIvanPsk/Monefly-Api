using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonefyWeb.Infraestructure.Models.Models
{
    public class Accounts_Currencies
    {
        public long UserId { get; set; }
        public long AccountId { get; set; }
        public virtual UserDm User { get; set; }
        public virtual AccountDm Account { get; set; }
    }
}
