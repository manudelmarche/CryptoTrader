using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Binance.API.Csharp.Client;
using Binance.API.Csharp.Client.Models.General;
using System.Threading.Tasks;
using Binance.API.Csharp.Client.Models.Market;

namespace CryptoTrader.Controllers
{
    public class AccountController : ApiController
    {
        private static readonly ApiClient apiClient = new ApiClient("MsQFFgMIvMBMfXxW8edzuLPBInt4eMlrG6gZA0YTmYtqWShcJCAtdWnHhBd1kaXg", "ylzZsHA5rgb2HvaSU4g2yX6dqShshouQZ3m7ULh3wypPDOUjLirQoiBWtjgk0T6j");
        private static readonly BinanceClient binanceClient = new BinanceClient(apiClient, false);

        // GET: api/Account
        public async Task<AccountInfo> Get()
        {
            return await Task.Run(() => binanceClient.GetAccountInfo());
        }

        //[Route("api/Account/Balance/{UserId:int}/{age:int}")]
        [Route("api/Account/Balance")]
        [HttpGet]
        public async Task<string> GetBalance()
        {
            var totalBalance = 0.0;

            var bucht = await Task.Run(() => binanceClient.GetAccountInfo());
            foreach (Balance balance in bucht.Balances)
            {
                totalBalance += (double)balance.Free;
            }

            return totalBalance.ToString();
        }

        // GET: api/Account/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
