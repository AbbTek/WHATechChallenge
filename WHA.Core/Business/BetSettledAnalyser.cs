using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHA.Core.Domain;

namespace WHA.Core.Business
{
    public static class BetSettledAnalyser
    {
        public static IList<Bet> SettledBets { get; private set; }
        public static IDictionary<int, CustomerHistoricBet> CustomersHistoricBets { get; private set; }
        public static IList<Bet> UnsettledBets { get; set; }

        static BetSettledAnalyser()
        {
            SettledBets = new List<Bet>();
            UnsettledBets = new List<Bet>();
            CustomersHistoricBets = new Dictionary<int, CustomerHistoricBet>();
        }

        public static IDictionary<int, CustomerHistoricBet> GetHistoricBets(IList<Bet> bets)
        {
            var result = (from b in bets
                          where b.Type == BetType.Settled
                          group b by b.CustomerID into g
                          select new CustomerHistoricBet()
                          {
                              CustomerID = g.Key,
                              TotalStaked = g.Sum(x => x.Stake),
                              TotalWon = g.Sum(x => x.Win),
                              Bets = g.Count()
                          }).ToDictionary(x => x.CustomerID);
            return result;
        }

        public static void SetSettledBets(IList<Bet> bets)
        {
            SettledBets = bets;
            CustomersHistoricBets = GetHistoricBets(SettledBets);
        }

        public static void SetUnsettledBets(IList<Bet> bets)
        {
            UnsettledBets = bets;
        }

        /// <summary>
        /// Get the historic winners with high winnings
        /// </summary>
        /// <param name="greaterThan">Percentage</param>
        /// <returns></returns>
        public static IEnumerable<CustomerHistoricBet> GetCustomersAccordingWinnings(double greaterThan)
        {
            return (from hb in BetSettledAnalyser.CustomersHistoricBets
                    where hb.Value.TotalWonPercentege >= greaterThan
                    select hb.Value
                ).ToList();
        }

        public static IEnumerable<Bet> GetUnsettledFromWinners()
        {
            var winners = GetCustomersAccordingWinnings(60);
            return (from us in UnsettledBets
                     join win in winners on us.CustomerID equals win.CustomerID
                     orderby us.CustomerID
                     select us).ToList();
        }

        public static IEnumerable<Bet> GetUnsettledOver(int times)
        {
            return (from hb in BetSettledAnalyser.CustomersHistoricBets
                    join ub in UnsettledBets on hb.Key equals ub.CustomerID
                    where ub.Stake >= hb.Value.AverageStaked * times
                    orderby ub.CustomerID
                    select ub).ToList();
        }

        public static IEnumerable<Bet> GetUnsettledWouldWinOver(double toWin)
        {
            return (from ub in UnsettledBets
                    where ub.Win >= toWin
                    orderby ub.CustomerID
                    select ub
                    ).ToList();
        }
    }
}
