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

        public double AverageStaked {
            get
            {
                return TotalStaked / Bets;
            }
        }

        public double TotalWonPercentege
        {
            get
            {
                return 100 * (TotalWon / TotalStaked - 1);
            }
        }
    }
}