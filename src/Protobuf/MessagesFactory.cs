using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.ProtocolBuffers;
namespace Connect.Protobuf
{
    public class MessagesFactory
    {
        uint lastMessagePayloadType = 0;
        ByteString lastMessagePayload = null;

        #region Building Proto messages from Byte array methods
        public ProtoMessage GetMessage(byte[] msg)
        {
            var message = ProtoMessage.CreateBuilder().MergeFrom(msg).Build();
            lastMessagePayloadType = message.PayloadType;
            lastMessagePayload = message.Payload;
            return message;
        }

        public uint GetPayloadType(byte[] msg)
        {
            if (msg != null)
                GetMessage(msg);
            return lastMessagePayloadType;
        }

        public ByteString GetPayload(byte[] msg)
        {
            if (msg != null)
                GetMessage(msg);
            return lastMessagePayload;
        }

        //public ProtoOAPingReq GetPingRequest(byte[] msg = null)
        //{
        //    return ProtoOAPingReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        //}
        //public ProtoOAPingRes GetPingResponse(byte[] msg = null)
        //{
        //    return ProtoOAPingRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        //}

        public ProtoHeartbeatEvent GetHeartbeatEvent(byte[] msg)
        {
            return ProtoHeartbeatEvent.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAErrorRes GetErrorResponse(byte[] msg)
        {
            return ProtoOAErrorRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAApplicationAuthReq GetApplicationAuthorizationRequest(byte[] msg)
        {
            return ProtoOAApplicationAuthReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAApplicationAuthRes GetApplicationAuthorizationResponse(byte[] msg)
        {
            return ProtoOAApplicationAuthRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAAccountAuthReq GetAccountAuthorizationRequest(byte[] msg)
        {
            return ProtoOAAccountAuthReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAAccountAuthRes GetAccountAuthorizationResponse(byte[] msg)
        {
            return ProtoOAAccountAuthRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOADealListRes GetDealListResponse(byte[] msg)
        {
            return ProtoOADealListRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAAssetListRes GetAssetListResponse(byte[] msg)
        {
            return ProtoOAAssetListRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAClientDisconnectEvent GetClientDisconnectEvent(byte[] msg)
        {
            return ProtoOAClientDisconnectEvent.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAAccountsTokenInvalidatedEvent GetAccountsTokenInvalidatedEvent(byte[] msg)
        {
            return ProtoOAAccountsTokenInvalidatedEvent.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOACashFlowHistoryListRes GetCashFlowHistoryListResponse(byte[] msg)
        {
            return ProtoOACashFlowHistoryListRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAExpectedMarginRes GetExpectedMarginResponse(byte[] msg)
        {
            return ProtoOAExpectedMarginRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAGetAccountListByAccessTokenRes GetAccountListByAccessTokenResponse(byte[] msg)
        {
            return ProtoOAGetAccountListByAccessTokenRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAGetTickDataRes GetTickDataResponse(byte[] msg)
        {
            return ProtoOAGetTickDataRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAGetTrendbarsRes GetTrendbarsResponse(byte[] msg)
        {
            return ProtoOAGetTrendbarsRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAMarginChangedEvent GetMarginChangedEvent(byte[] msg)
        {
            return ProtoOAMarginChangedEvent.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAOrderErrorEvent GetOrderErrorEvent(byte[] msg)
        {
            return ProtoOAOrderErrorEvent.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAReconcileRes GetReconcileResponse(byte[] msg)
        {
            return ProtoOAReconcileRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOASubscribeSpotsRes GetSubscribeSpotsResponse(byte[] msg)
        {
            return ProtoOASubscribeSpotsRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOASymbolsForConversionRes GetSymbolsForConversionResponse(byte[] msg)
        {
            return ProtoOASymbolsForConversionRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOASymbolsListRes GetSymbolsListResponse(byte[] msg)
        {
            return ProtoOASymbolsListRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOASymbolByIdRes GetSymbolByIdResponse(byte[] msg)
        {
            return ProtoOASymbolByIdRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOASymbolChangedEvent GetSymbolChangedEvent(byte[] msg)
        {
            return ProtoOASymbolChangedEvent.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOATraderRes GetTraderResponse(byte[] msg)
        {
            return ProtoOATraderRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOATraderUpdatedEvent GetTraderUpdatedEvent(byte[] msg)
        {
            return ProtoOATraderUpdatedEvent.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOATrailingSLChangedEvent GetTrailingSLChangedEvent(byte[] msg)
        {
            return ProtoOATrailingSLChangedEvent.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAUnsubscribeSpotsRes GetUnsubscribeSpotsResponse(byte[] msg)
        {
            return ProtoOAUnsubscribeSpotsRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAVersionRes GetVersionResponse(byte[] msg)
        {
            return ProtoOAVersionRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        //public ProtoOASubscribeForTradingEventsReq GetSubscribeForTradingEventsRequest(byte[] msg = null)
        //{
        //    return ProtoOASubscribeForTradingEventsReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        //}
        //public ProtoOASubscribeForTradingEventsRes GetSubscribeForTradingEventsResponse(byte[] msg = null)
        //{
        //    return ProtoOASubscribeForTradingEventsRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        //}
        //public ProtoOAUnsubscribeFromTradingEventsReq GetUnsubscribeForTradingEventsRequest(byte[] msg = null)
        //{
        //    return ProtoOAUnsubscribeFromTradingEventsReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        //}
        //public ProtoOAUnsubscribeFromTradingEventsRes GetUnsubscribeForTradingEventsResponse(byte[] msg = null)
        //{
        //    return ProtoOAUnsubscribeFromTradingEventsRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        //}
        //public ProtoOAGetSubscribedAccountsReq GetAllSubscriptionsForTradingEventsRequest(byte[] msg = null)
        //{
        //    return ProtoOAGetSubscribedAccountsReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        //}
        //public ProtoOAGetSubscribedAccountsRes GetAllSubscriptionsForTradingEventsResponse(byte[] msg = null)
        //{
        //    return ProtoOAGetSubscribedAccountsRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        //}

        public ProtoOAExecutionEvent GetExecutionEvent(byte[] msg = null)
        {
            return ProtoOAExecutionEvent.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOANewOrderReq GetCreateOrderRequest(byte[] msg)
        {
            return ProtoOANewOrderReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOACancelOrderReq GetCancelOrderRequest(byte[] msg)
        {
            return ProtoOACancelOrderReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAClosePositionReq GetClosePositionRequest(byte[] msg)
        {
            return ProtoOAClosePositionReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAAmendPositionSLTPReq GetAmendPositionStopLossTakeProfitRequest(byte[] msg)
        {
            return ProtoOAAmendPositionSLTPReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOAAmendOrderReq GetAmendOrderRequest(byte[] msg)
        {
            return ProtoOAAmendOrderReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public ProtoOASubscribeSpotsReq GetSubscribeSpotsRequest(byte[] msg)
        {
            return ProtoOASubscribeSpotsReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        //public ProtoOAGetSpotSubscriptionReq GetGetSpotSubscriptionRequest(byte[] msg = null)
        //{
        //    return ProtoOAGetSpotSubscriptionReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        //}
        //public ProtoOAGetSpotSubscriptionRes GetGetSpotSubscriptionResponse(byte[] msg = null)
        //{
        //    return ProtoOAGetSpotSubscriptionRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        //}
        //public ProtoOAGetAllSpotSubscriptionsReq GetGetAllSpotSubscriptionsRequest(byte[] msg = null)
        //{
        //    return ProtoOAGetAllSpotSubscriptionsReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        //}
        //public ProtoOAGetAllSpotSubscriptionsRes GetGetAllSpotSubscriptionsResponse(byte[] msg = null)
        //{
        //    return ProtoOAGetAllSpotSubscriptionsRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        //}
        public ProtoOASpotEvent GetSpotEvent(byte[] msg = null)
        {
            return ProtoOASpotEvent.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }
        #endregion

        #region Creating new Proto messages with parameters specified
        public ProtoMessage CreateMessage(uint payloadType, ByteString payload = null, string clientMsgId = null)
        {
            var protoMsg = ProtoMessage.CreateBuilder();
            protoMsg.PayloadType = payloadType;
            if (payload != null)
                protoMsg.SetPayload(payload);
            if (clientMsgId != null)
                protoMsg.SetClientMsgId(clientMsgId);

            return protoMsg.Build();
        }
        public ProtoMessage CreateMessage(ProtoMessage.Builder messageBuilder, string clientMsgId = null)
        {
            return CreateMessage(messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreatePingRequest(ulong timestamp, string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoPayloadType.PING_REQ, ProtoPingReq.CreateBuilder().SetTimestamp(timestamp).Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreatePingResponse(ulong timestamp, string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoPayloadType.PING_REQ, ProtoPingRes.CreateBuilder().SetTimestamp(timestamp).Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateVersionRequest(string clientMsgId = null)
        {
            var message = ProtoOAVersionReq.CreateBuilder();
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateVersionResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_VERSION_RES, ProtoOAApplicationAuthRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateHeartbeatEvent(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoPayloadType.HEARTBEAT_EVENT, ProtoHeartbeatEvent.CreateBuilder().Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAppAuthorizationRequest(string clientId, string clientSecret, string clientMsgId = null)
        {
            var message = ProtoOAApplicationAuthReq.CreateBuilder();
            message.SetClientId(clientId);
            message.SetClientSecret(clientSecret);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAppAuthorizationResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_APPLICATION_AUTH_RES, ProtoOAApplicationAuthRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAccAuthorizationRequest(string token, long accountId, string clientMsgId = null)
        {
            var message = ProtoOAAccountAuthReq.CreateBuilder();
            message.SetAccessToken(token);
            message.SetCtidTraderAccountId(accountId);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAccAuthorizationResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ACCOUNT_AUTH_RES, ProtoOAAccountAuthRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAssetClassListRequest(string clientMsgId = null)
        {
            var message = ProtoOAVersionReq.CreateBuilder();
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAssetClassListResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_RES, ProtoOAApplicationAuthRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateDealsListRequest(long accountId, long from, long to, string clientMsgId = null)
        {
            var message = ProtoOADealListReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetFromTimestamp(from);
            message.SetToTimestamp(to);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateDealsListResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_DEAL_LIST_RES, ProtoOADealListRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateReconcileRequest(long accountId, string clientMsgId = null)
        {
            var message = ProtoOAReconcileReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateReconcileResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_RECONCILE_RES, ProtoOAReconcileRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateCashflowHistoryRequest(long accountId, long from, long to, string clientMsgId = null)
        {
            var message = ProtoOACashFlowHistoryListReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetFromTimestamp(from);
            message.SetToTimestamp(to);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateCashflowHistoryResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_CASH_FLOW_HISTORY_LIST_RES, ProtoOACashFlowHistoryListRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAccountListRequest(string token, string clientMsgId = null)
        {
            var message = ProtoOAGetAccountListByAccessTokenReq.CreateBuilder();
            message.SetAccessToken(token);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAccountListResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_GET_ACCOUNTS_BY_ACCESS_TOKEN_RES, ProtoOAGetAccountListByAccessTokenRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateSymbolsListRequest(long accountId, string clientMsgId = null)
        {
            var message = ProtoOASymbolsListReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateSymbolsListResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_SYMBOLS_LIST_RES, ProtoOASymbolsListRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateTrendbarsRequest(int accountId, int symbolId, long from, long to, ProtoOATrendbarPeriod period, string clientMsgId = null)
        {
            var message = ProtoOAGetTrendbarsReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetFromTimestamp(from);
            message.SetToTimestamp(to);
            message.SetPeriod(period);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateTrendbarsResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_GET_TRENDBARS_RES, ProtoOAGetTrendbarsRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateTickDataRequest(int accountId, int symbolId, long from, long to, ProtoOAQuoteType type, string clientMsgId = null)
        {
            var message = ProtoOAGetTickDataReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetType(type);
            message.SetFromTimestamp(from);
            message.SetToTimestamp(to);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateTickDataResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_GET_TICKDATA_RES, ProtoOAGetTickDataRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateExecutionEvent(ProtoOAExecutionType executionType, ProtoOAOrder order, ProtoOAPosition position = null, string reasonCode = null, string clientMsgId = null)
        {
            var message = ProtoOAExecutionEvent.CreateBuilder();
            message.SetExecutionType(executionType);
            message.SetOrder(order);
            if (position != null)
                message.SetPosition(position);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateExecutionEvent(ProtoOAExecutionType executionType, ProtoOAOrder.Builder order, ProtoOAPosition.Builder position = null, string reasonCode = null, string clientMsgId = null)
        {
            return CreateExecutionEvent(executionType, order.Build(), position == null ? null : position.Build(), reasonCode, clientMsgId);
        }
        public ProtoMessage CreateMarketOrderRequest(long accountId, string accessToken, int symbolId, ProtoOATradeSide tradeSide, long volume, string clientMsgId = null)
        {
            var message = ProtoOANewOrderReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetOrderType(ProtoOAOrderType.MARKET);
            message.SetTradeSide(tradeSide);
            message.SetVolume(volume);
            message.SetComment("TradingApiTest.CreateMarketOrderRequest");
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateMarketRangeOrderRequest(long accountId, string accessToken, int symbolId, ProtoOATradeSide tradeSide, long volume, double baseSlippagePrice, int slippageInPoints, string clientMsgId = null)
        {
            var message = ProtoOANewOrderReq.CreateBuilder(); ;
            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetOrderType(ProtoOAOrderType.MARKET_RANGE);
            message.SetTradeSide(tradeSide);
            message.SetVolume(volume);
            message.SetBaseSlippagePrice(baseSlippagePrice);
            message.SetSlippageInPoints(slippageInPoints);
            message.SetComment("TradingApiTest.CreateMarketRangeOrderRequest");
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateLimitOrderRequest(long accountId, string accessToken, int symbolId, ProtoOATradeSide tradeSide, long volume, double limitPrice, string clientMsgId = null)
        {
            var message = ProtoOANewOrderReq.CreateBuilder(); ;
            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetOrderType(ProtoOAOrderType.LIMIT);
            message.SetTradeSide(tradeSide);
            message.SetVolume(volume);
            message.SetLimitPrice(limitPrice);
            message.SetComment("TradingApiTest.CreateLimitOrderRequest");
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            message.SetExpirationTimestamp((long)(DateTime.UtcNow.AddHours(1) - epoch).TotalMilliseconds);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateStopOrderRequest(long accountId, string accessToken, int symbolId, ProtoOATradeSide tradeSide, long volume, double stopPrice, string clientMsgId = null)
        {
            var message = ProtoOANewOrderReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetOrderType(ProtoOAOrderType.STOP);
            message.SetTradeSide(tradeSide);
            message.SetVolume(volume);
            message.SetStopPrice(stopPrice);
            message.SetComment("TradingApiTest.CreateStopOrderRequest");
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateStopLimitOrderRequest(long accountId, string accessToken, int symbolId, ProtoOATradeSide tradeSide, long volume, double stopPrice, int slippageInPoints, string clientMsgId = null)
        {
            var message = ProtoOANewOrderReq.CreateBuilder(); ;
            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetOrderType(ProtoOAOrderType.STOP_LIMIT);
            message.SetTradeSide(tradeSide);
            message.SetVolume(volume);
            message.SetSlippageInPoints(slippageInPoints);
            message.SetStopPrice(stopPrice);
            message.SetComment("TradingApiTest.CreateStopLimitOrderRequest");
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateCancelOrderRequest(long accountId, string accessToken, long orderId, string clientMsgId = null)
        {
            var message = ProtoOACancelOrderReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetOrderId(orderId);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateClosePositionRequest(long accountId, string accessToken, long positionId, long volume, string clientMsgId = null)
        {
            var message = ProtoOAClosePositionReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetPositionId(positionId);
            message.SetVolume(volume);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAmendPositionStopLossRequest(long accountId, string accessToken, long positionId, double stopLossPrice, string clientMsgId = null)
        {
            var message = ProtoOAAmendPositionSLTPReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetPositionId(positionId);
            message.SetStopLoss(stopLossPrice);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAmendPositionTakeProfitRequest(long accountId, string accessToken, long positionId, double takeProfitPrice, string clientMsgId = null)
        {
            var message = ProtoOAAmendPositionSLTPReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetPositionId(positionId);
            message.SetTakeProfit(takeProfitPrice);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAmendPositionStopLossTakeProfitRequest(long accountId, string accessToken, long positionId, double stopLossPrice, double takeProfitPrice, string clientMsgId = null)
        {
            var message = ProtoOAAmendPositionSLTPReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetPositionId(positionId);
            message.SetStopLoss(stopLossPrice);
            message.SetTakeProfit(takeProfitPrice);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAmendPositionProtectionRequest(long accountId, string accessToken, long positionId, double stopLossPrice, double takeProfitPrice, string clientMsgId = null)
        {
            var message = ProtoOAAmendPositionSLTPReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetPositionId(positionId);
            message.SetStopLoss(stopLossPrice);
            message.SetTakeProfit(takeProfitPrice);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAmendLimitOrderRequest(long accountId, string accessToken, long orderId, double limitPrice, string clientMsgId = null)
        {
            var message = ProtoOAAmendOrderReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetOrderId(orderId);
            message.SetLimitPrice(limitPrice);
            message.SetTakeProfit(limitPrice + 0.02);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateAmendStopOrderRequest(long accountId, string accessToken, long orderId, double stopPrice, string clientMsgId = null)
        {
            var message = ProtoOAAmendOrderReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.SetOrderId(orderId);
            message.SetStopPrice(stopPrice);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateSubscribeForSpotsRequest(long accountId, int symbolId, string clientMsgId = null)
        {
            var message = ProtoOASubscribeSpotsReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.AddSymbolId(symbolId);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateSubscribeForSpotsResponse(uint accountId, string clientMsgId = null)
        {
            var message = ProtoOASubscribeSpotsRes.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        public ProtoMessage CreateUnsubscribeFromSpotsRequest(int accountId, int symbolId, string clientMsgId = null)
        {
            var message = ProtoOAUnsubscribeSpotsReq.CreateBuilder();
            message.SetCtidTraderAccountId(accountId);
            message.AddSymbolId(symbolId);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }
        #endregion

        #region Creating new Proto messages Builders
        //public ProtoOAGetAllSpotSubscriptionsRes.Builder CreateGetAllSpotSubscriptionsResponseBuilder(string clientMsgId = null)
        //{
        //    return ProtoOAGetAllSpotSubscriptionsRes.CreateBuilder();
        //}
        public ProtoOASpotEvent.Builder CreateSpotEventBuilder(uint subscriptionId, string symbolName, string clientMsgId = null)
        {
            return ProtoOASpotEvent.CreateBuilder();
        }
        #endregion
    }
}
