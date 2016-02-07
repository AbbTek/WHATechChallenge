using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using WHA.Core.Business;
using WHA.Core.Domain;
using WHACodeChallenge.Controllers.Api.Messages;

namespace WHACodeChallenge.Controllers.Api
{
    public class BetsController : ApiController
    {
        public IHttpActionResult ProcessFile([FromBody]ProcessFile processFile)
        {
            var path = HostingEnvironment.MapPath(processFile.FileURL);
            var readBets = CsvFilelUtil.ReadFile(path, processFile.BetType);

            switch (processFile.BetType)
            {
                case BetType.Settled:
                    BetSettledAnalyser.SetSettledBets(readBets);
                    break;
                case BetType.Unsettled:
                    BetSettledAnalyser.SetUnsettledBets(readBets);
                    break;
            }

           
            File.Delete(path);
            return Ok();
        }

        public BetsStatus GetStatus()
        {
            var status = new BetsStatus() {
                TotalSettledBets = BetSettledAnalyser.SettledBets.Count,
                TotalUnsettledBets = BetSettledAnalyser.UnsettledBets.Count
            };
            return status;
        }

        public IEnumerable<CustomerHistoricBet> GetCustomersAccordingWinnings(double greaterThan)
        {
            return BetSettledAnalyser.GetCustomersAccordingWinnings(greaterThan);
        }

        public IEnumerable<Bet> GetUnsettledFromWinners()
        {
            return BetSettledAnalyser.GetUnsettledFromWinners();
        }

        public IEnumerable<Bet> GetUnsettledOver(int times)
        {
            return BetSettledAnalyser.GetUnsettledOver(times);
        }

        public IEnumerable<Bet> GetUnsettledWouldWinOver(double toWin)
        {
            return BetSettledAnalyser.GetUnsettledWouldWinOver(toWin);
        }
    }
}
