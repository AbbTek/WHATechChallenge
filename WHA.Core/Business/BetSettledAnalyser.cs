using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHA.Core.Domain;

namespace WHA.Core.Business
{
    public class BetSettledAnalyser
    {
        public static IList<CustomerHistoricBet> GetHistoricBets(IList<Bet> bets) {
            var result = (from b in bets
                         where b.Type == BetType.Settled
                         group b by b.CustomerID into g
                         select new CustomerHistoricBet()
                         {
                             CustomerID = g.Key,
                             TotalStaked = g.Sum(x => x.Stake),
                             TotalWon = g.Sum(x => x.Win),
                             Bets = g.Count()
                             //WonPercentage = 100 * (g.Sum(x => x.Win) / g.Sum(x => x.Stake) - 1) 
                         }).ToList();
            return result;
        }
    }
}
