using System;
using System.Collections.Generic;
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
            var r = CsvFilelUtil.ReadFile(HostingEnvironment.MapPath(processFile.FileURL), processFile.BetType);
            return Ok();
        }
    }
}
