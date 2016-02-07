using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WHACodeChallenge.Controllers.Api.Messages
{
    public class BetsStatus
    {
        public int TotalSettledBets { get; set; }
        public int TotalUnsettledBets { get; set; }
    }
}