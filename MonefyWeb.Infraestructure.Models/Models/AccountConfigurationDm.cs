using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonefyWeb.Infraestructure.Models.Models
{
    public class AccountConfigurationDm
    {
        public long Id { get; set; }
        public int CurrencyFormat { get; set; }
        public int CurrencyDefault { get; set; }
        public int FirstDayOfWeek { get; set; }
        public long AccountId { get; set; }
        public virtual AccountDm Account { get; set; }
    }
}
