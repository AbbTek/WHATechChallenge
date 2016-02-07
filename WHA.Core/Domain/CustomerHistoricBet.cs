using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHA.Core.Domain
{
    [DebuggerDisplay("{CustomerID} - {Bets} - {TotalStaked} - {TotalWon} ")]
    public class CustomerHistoricBet
    {
        public int CustomerID { get; set; }
        public int Bets { get; set; }
        public double TotalStaked { get; set; }
        public double TotalWon { get; set; }
    }
}