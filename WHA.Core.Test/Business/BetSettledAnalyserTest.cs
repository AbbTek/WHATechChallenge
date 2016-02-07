using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHA.Core.Business;
using WHA.Core.Domain;

namespace WHA.Core.Test.Business
{
    [TestClass]
    public class BetSettledAnalyserTest
    {
        [TestMethod]
        public void The_method_should_calculate_historic_bets()
        {
            //Arrange 
            List<Bet> bets = new List<Bet>()
            {
                new Bet() { CustomerID = 1, Type= BetType.Settled, Stake=300, Win=5000 },
                new Bet() { CustomerID = 1, Type= BetType.Settled, Stake=100, Win=0 },
                new Bet() { CustomerID = 1, Type= BetType.Settled, Stake=20, Win=600 },
                new Bet() { CustomerID = 1, Type= BetType.Settled, Stake=10, Win=15 },
                new Bet() { CustomerID = 2, Type= BetType.Settled, Stake=30, Win=50 },
                new Bet() { CustomerID = 2, Type= BetType.Settled, Stake=12, Win=0 },
                new Bet() { CustomerID = 3, Type= BetType.Settled, Stake=60, Win=1000 },
                new Bet() { CustomerID = 3, Type= BetType.Settled, Stake=40, Win=50 },
                new Bet() { CustomerID = 3, Type= BetType.Settled, Stake=10, Win=25 },
                new Bet() { CustomerID = 4, Type= BetType.Settled, Stake=10, Win=20 },
                new Bet() { CustomerID = 4, Type= BetType.Settled, Stake=40, Win=0 },
                new Bet() { CustomerID = 4, Type= BetType.Settled, Stake=50, Win=0 },
            };

            //Action
            BetSettledAnalyser.GetHistoricBets(bets);
        }
    }
}
