using CollectionApp.Models;
using CollectionApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Script.Serialization;

namespace CollectionApp.Controllers
{
    public class CashPointApiController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public CashPointApiController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [Route("api/cashpoint/accounts")]
        public void PostAccountToCashPoint([FromBody]CashPointAccountsVM model)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var cashPoint = _context.CashPoints
                        .Include("Accounts")
                        .FirstOrDefault(x => x.Id == model.CashPointId);

                    cashPoint.Accounts.Clear();
                    _context.SaveChanges();

                    if (model.AccountIds != null && model.AccountIds.Any())
                    {
                        foreach (var accountId in model.AccountIds)
                        {
                            var account = _context.Accounts
                                .Include("Client")
                                .Include("Currency")
                                .Include("CashPoints")
                                .Include("ClientTocc")
                                .FirstOrDefault(x => x.Id == accountId);
                            cashPoint.Accounts.Add(account);
                        }
                    }
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new Exception("Some errors", e);
                }
            }
        }

        [HttpGet]
        [Route("api/cashpoint/getaccounts")]
        public IHttpActionResult GetAccountToCashPoint([FromBody]int Id)
        {
            var cashPoints = _context.CashPoints.Include("Accounts").ToList();
            var cashPoint = cashPoints.FirstOrDefault(x => x.Id == Id);
           
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(cashPoint);
            return Ok(json);
        }
    }
}
