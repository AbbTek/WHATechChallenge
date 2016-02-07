using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHA.Core.Domain
{
    public class Bet
    {
        public BetType Type { get; set; }
        public int CustomerID { get; set; }
        public int EventID { get; set; }
        public int ParticipantID { get; set; }
        public double Stake { get; set; }
        public double Win { get; set; }
    }
}
