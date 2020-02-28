using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Loan.Data.Services;
using Microsoft.Owin.Logging;
using NLog;
using NLog.Web;

namespace LoanEvaluator.API
{
    [RoutePrefix("api/Loan")]
    public class LoanApiController : ApiController
    {
        private readonly IMapLoan _loan;
        private Logger logger;
        public LoanApiController(IMapLoan loan)
        {
            _loan = loan;

            logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        }
        [HttpGet]
        [Route("amount/{amount}")]
        public IHttpActionResult Get(decimal amount)
        {
            logger.Info($" amount requested {amount}");
            try
            {
                var model = _loan.GetAll(amount);
                if (model != null)
                {
                    return Ok(model);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.InnerException??e);
                return InternalServerError(e);


            }

            return NotFound();
        }
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
           
            try
            {

                var model = _loan.Get(id);
                if (model != null)
                {
                    logger.Info($" site viewed {model.Loansite} amount rate {model.Rate}");
                    return Ok(model);
                }

            }
            catch (Exception e)
            {

                logger.Error(e.InnerException ?? e);
                return InternalServerError(e);
            }

            return NotFound()
                ;
        }
       
     
    }
}
