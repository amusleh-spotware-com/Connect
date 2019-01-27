using Newtonsoft.Json;
using RestSharp;
using Connect.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Connect.RESTful.Models;
using Connect.RESTful.Enums;

namespace Connect.RESTful
{
    public class Client
    {
        #region Fields

        private RestClient _client;

        private readonly string _baseUrl;

        private readonly Mode _mode;

        #endregion Fields

        #region Constructor

        public Client(Mode mode = Mode.Live)
        {
            _mode = mode;

            _baseUrl = BaseUrls.GetBaseUrl(ApiType.RESTful, _mode);

            _client = new RestClient();

            _client.BaseUrl = new Uri(BaseUrl);
        }

        #endregion Constructor

        #region Properties

        public string BaseUrl => _baseUrl;

        public Mode Mode => _mode;

        #endregion Properties

        #region Methods

        public async Task<Profile> GetProfile(string accessToken)
        {
            RestRequest request = Request.Factory.GetRequest(Request.Resources.Profile, accessToken);

            return (await Request.Execute.Get<Profile>(_client, request)).FirstOrDefault();
        }

        public async Task<List<TradingAccount>> GetTradingAccounts(string accessToken)
        {
            RestRequest request = Request.Factory.GetRequest(Request.Resources.TradingAccounts, accessToken);

            return (await Request.Execute.Get<List<TradingAccount>>(_client, request)).SelectMany(dList => dList).ToList();
        }

        public async Task<List<Deal>> GetDeals(string accessToken, long accountId, long limit = 750)
        {
            string resource = Request.Resources.GetTradingAccountResource(accountId, Request.Resources.Deals);

            RestRequest request = Request.Factory.GetRequest(resource, accessToken, limit: limit);

            return (await Request.Execute.Get<List<Deal>>(_client, request)).SelectMany(dList => dList).ToList();
        }

        public async Task<List<Deal>> GetDeals(string accessToken, long accountId, DateTimeOffset startTime, DateTimeOffset endTime,
            long limit = 750)
        {
            string resource = Request.Resources.GetTradingAccountResource(accountId, Request.Resources.Deals);

            RestRequest request = Request.Factory.GetRequest(resource, accessToken, from: startTime, to: endTime, limit: limit);

            return (await Request.Execute.Get<List<Deal>>(_client, request)).SelectMany(dList => dList).ToList();
        }

        public async Task<List<CashFlow>> GetCashFlowHistory(string accessToken, long accountId, long limit = 750)
        {
            string resource = Request.Resources.GetTradingAccountResource(accountId, Request.Resources.CashFlowHistory);

            RestRequest request = Request.Factory.GetRequest(resource, accessToken, limit: limit);

            return (await Request.Execute.Get<List<CashFlow>>(_client, request)).SelectMany(dList => dList).ToList();
        }

        public async Task<List<CashFlow>> GetCashFlowHistory(string accessToken, long accountId, DateTime startTime, DateTime endTime,
            long limit = 750)
        {
            string resource = Request.Resources.GetTradingAccountResource(accountId, Request.Resources.CashFlowHistory);

            RestRequest request = Request.Factory.GetRequest(resource, accessToken, from: startTime, to: endTime, limit: limit);

            return (await Request.Execute.Get<List<CashFlow>>(_client, request)).SelectMany(dList => dList).ToList();
        }

        public async Task<List<PendingOrder>> GetPendingOrders(string accessToken, long accountId, long limit = 750)
        {
            string resource = Request.Resources.GetTradingAccountResource(accountId, Request.Resources.PendingOrders);

            RestRequest request = Request.Factory.GetRequest(resource, accessToken, limit: limit);

            return (await Request.Execute.Get<List<PendingOrder>>(_client, request)).SelectMany(dList => dList).ToList();
        }

        public async Task<List<Position>> GetPositions(string accessToken, long accountId, long limit = 750)
        {
            string resource = Request.Resources.GetTradingAccountResource(accountId, Request.Resources.Positions);

            RestRequest request = Request.Factory.GetRequest(resource, accessToken, limit: limit);

            return (await Request.Execute.Get<List<Position>>(_client, request)).SelectMany(dList => dList).ToList();
        }

        public async Task<List<Symbol>> GetSymbols(string accessToken, long accountId)
        {
            string resource = Request.Resources.GetTradingAccountResource(accountId, Request.Resources.Symbols);

            RestRequest request = Request.Factory.GetRequest(resource, accessToken);

            return (await Request.Execute.Get<List<Symbol>>(_client, request)).SelectMany(dList => dList).ToList();
        }

        public async Task<List<TickData>> GetTickData(string accessToken, long accountId, string symbolName, TickDataType type, DateTime date,
            TimeSpan from, TimeSpan to)
        {
            string resource = Request.Resources.GetSymbolTickResource(accountId, symbolName, type);

            RestRequest request = Request.Factory.GetRequest(resource, accessToken, date: date, from: from, to: to);

            return (await Request.Execute.Get<List<TickData>>(_client, request)).SelectMany(dList => dList).ToList();
        }

        public async Task<List<Trendbar>> GetTrendbar(string accessToken, long accountId, string symbolName, TrendbarType type, 
            DateTimeOffset from, DateTimeOffset to)
        {
            string resource = Request.Resources.GetSymbolTrendbarResource(accountId, symbolName, type);

            RestRequest request = Request.Factory.GetRequest(resource, accessToken, from: from, to: to, isTimeStamp: false);

            return (await Request.Execute.Get<List<Trendbar>>(_client, request)).SelectMany(dList => dList).ToList();
        }

        public async Task<HttpStatusCode> CreateDemoAccount(string accessToken, DemoTradingAccountReq account)
        {
            string resource = $"{Request.Resources.TradingAccounts}/{Request.Resources.Createdemo}";

            RestRequest request = Request.Factory.GetRequest(resource, accessToken, Method.POST);

            request.AddParameter("application/json", JsonConvert.SerializeObject(account), ParameterType.RequestBody);

            return await Request.Execute.Post(_client, request);
        }

        public async Task<DepositWithdrawRes> Deposit(string accessToken, long accountId, long amount)
        {
            string resource = Request.Resources.GetTradingAccountResource(accountId, Request.Resources.Deposit);

            RestRequest request = Request.Factory.GetRequest(resource, accessToken, Method.POST);

            DepositWithdrawReq deposit = new DepositWithdrawReq(amount);

            request.AddParameter("application/json", JsonConvert.SerializeObject(deposit), ParameterType.RequestBody);

            return await Request.Execute.Post<DepositWithdrawRes>(_client, request);
        }

        public async Task<DepositWithdrawRes> Withdraw(string accessToken, long accountId, long amount)
        {
            string resource = Request.Resources.GetTradingAccountResource(accountId, Request.Resources.Withdraw);

            RestRequest request = Request.Factory.GetRequest(resource, accessToken, Method.POST);

            DepositWithdrawReq withdraw = new DepositWithdrawReq(amount);

            request.AddParameter("application/json", JsonConvert.SerializeObject(withdraw), ParameterType.RequestBody);

            return await Request.Execute.Post<DepositWithdrawRes>(_client, request);
        }

        #endregion Methods
    }
}