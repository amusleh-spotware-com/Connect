using Google.ProtocolBuffers;
using System;

namespace Connect.Protobuf
{
    public class MessagesFactory
    {
        #region Building Proto messages from Byte array methods

        public ProtoMessage GetMessage(byte[] message)
        {
            return ProtoMessage.CreateBuilder().MergeFrom(message).Build(); ;
        }

        public ProtoPingRes GetPingResponse(ByteString messagePayload)
        {
            return ProtoPingRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoHeartbeatEvent GetHeartbeatEvent(ByteString messagePayload)
        {
            return ProtoHeartbeatEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAErrorRes GetErrorResponse(ByteString messagePayload)
        {
            return ProtoOAErrorRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAApplicationAuthReq GetApplicationAuthorizationRequest(ByteString messagePayload)
        {
            return ProtoOAApplicationAuthReq.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAApplicationAuthRes GetApplicationAuthorizationResponse(ByteString messagePayload)
        {
            return ProtoOAApplicationAuthRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAAccountAuthReq GetAccountAuthorizationRequest(ByteString messagePayload)
        {
            return ProtoOAAccountAuthReq.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAAccountAuthRes GetAccountAuthorizationResponse(ByteString messagePayload)
        {
            return ProtoOAAccountAuthRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOADealListRes GetDealListResponse(ByteString messagePayload)
        {
            return ProtoOADealListRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAAssetListRes GetAssetListResponse(ByteString messagePayload)
        {
            return ProtoOAAssetListRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAClientDisconnectEvent GetClientDisconnectEvent(ByteString messagePayload)
        {
            return ProtoOAClientDisconnectEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAAccountsTokenInvalidatedEvent GetAccountsTokenInvalidatedEvent(ByteString messagePayload)
        {
            return ProtoOAAccountsTokenInvalidatedEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOACashFlowHistoryListRes GetCashFlowHistoryListResponse(ByteString messagePayload)
        {
            return ProtoOACashFlowHistoryListRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAExpectedMarginRes GetExpectedMarginResponse(ByteString messagePayload)
        {
            return ProtoOAExpectedMarginRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAGetAccountListByAccessTokenRes GetAccountListByAccessTokenResponse(ByteString messagePayload)
        {
            return ProtoOAGetAccountListByAccessTokenRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAGetTickDataRes GetTickDataResponse(ByteString messagePayload)
        {
            return ProtoOAGetTickDataRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAGetTrendbarsRes GetTrendbarsResponse(ByteString messagePayload)
        {
            return ProtoOAGetTrendbarsRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAMarginChangedEvent GetMarginChangedEvent(ByteString messagePayload)
        {
            return ProtoOAMarginChangedEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAOrderErrorEvent GetOrderErrorEvent(ByteString messagePayload)
        {
            return ProtoOAOrderErrorEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAReconcileRes GetReconcileResponse(ByteString messagePayload)
        {
            return ProtoOAReconcileRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOASubscribeSpotsRes GetSubscribeSpotsResponse(ByteString messagePayload)
        {
            return ProtoOASubscribeSpotsRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOASymbolsForConversionRes GetSymbolsForConversionResponse(ByteString messagePayload)
        {
            return ProtoOASymbolsForConversionRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOASymbolsListRes GetSymbolsListResponse(ByteString messagePayload)
        {
            return ProtoOASymbolsListRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOASymbolByIdRes GetSymbolByIdResponse(ByteString messagePayload)
        {
            return ProtoOASymbolByIdRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOASymbolChangedEvent GetSymbolChangedEvent(ByteString messagePayload)
        {
            return ProtoOASymbolChangedEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOATraderRes GetTraderResponse(ByteString messagePayload)
        {
            return ProtoOATraderRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOATraderUpdatedEvent GetTraderUpdatedEvent(ByteString messagePayload)
        {
            return ProtoOATraderUpdatedEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOATrailingSLChangedEvent GetTrailingSLChangedEvent(ByteString messagePayload)
        {
            return ProtoOATrailingSLChangedEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAUnsubscribeSpotsRes GetUnsubscribeSpotsResponse(ByteString messagePayload)
        {
            return ProtoOAUnsubscribeSpotsRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAVersionRes GetVersionResponse(ByteString messagePayload)
        {
            return ProtoOAVersionRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAExecutionEvent GetExecutionEvent(ByteString messagePayload = null)
        {
            return ProtoOAExecutionEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOANewOrderReq GetCreateOrderRequest(ByteString messagePayload)
        {
            return ProtoOANewOrderReq.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOACancelOrderReq GetCancelOrderRequest(ByteString messagePayload)
        {
            return ProtoOACancelOrderReq.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAClosePositionReq GetClosePositionRequest(ByteString messagePayload)
        {
            return ProtoOAClosePositionReq.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAAmendPositionSLTPReq GetAmendPositionStopLossTakeProfitRequest(ByteString messagePayload)
        {
            return ProtoOAAmendPositionSLTPReq.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOAAmendOrderReq GetAmendOrderRequest(ByteString messagePayload)
        {
            return ProtoOAAmendOrderReq.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOASubscribeSpotsReq GetSubscribeSpotsRequest(ByteString messagePayload)
        {
            return ProtoOASubscribeSpotsReq.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public ProtoOASpotEvent GetSpotEvent(ByteString messagePayload)
        {
            return ProtoOASpotEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        #endregion Building Proto messages from Byte array methods

        #region Creating new Proto messages with parameters specified

        public ProtoMessage CreateMessage(uint payloadType, ByteString payload = null, string clientMsgId = null)
        {
            var protoMsg = ProtoMessage.CreateBuilder();

            protoMsg.PayloadType = payloadType;

            if (payload != null)
            {
                protoMsg.SetPayload(payload);
            }

            if (clientMsgId != null)
            {
                protoMsg.SetClientMsgId(clientMsgId);
            }

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

        public ProtoMessage CreateAccountAuthorizationRequest(string token, long accountId, string clientMsgId = null)
        {
            var message = ProtoOAAccountAuthReq.CreateBuilder();
            message.SetAccessToken(token);
            message.SetCtidTraderAccountId(accountId);
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateAccountAuthorizationResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ACCOUNT_AUTH_RES, ProtoOAAccountAuthRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateAssetClassListRequest(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_REQ, ProtoOAVersionReq.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateAssetClassListResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_RES, ProtoOAApplicationAuthRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateDealsListRequest(long accountId, DateTimeOffset from, DateTimeOffset to, string clientMsgId = null)
        {
            var message = ProtoOADealListReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetFromTimestamp(from.ToUnixTimeMilliseconds());
            message.SetToTimestamp(to.ToUnixTimeMilliseconds());

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

        public ProtoMessage CreateCashflowHistoryRequest(long accountId, DateTimeOffset from, DateTimeOffset to, string clientMsgId = null)
        {
            var message = ProtoOACashFlowHistoryListReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetFromTimestamp(from.ToUnixTimeMilliseconds());
            message.SetToTimestamp(to.ToUnixTimeMilliseconds());

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateCashflowHistoryResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_CASH_FLOW_HISTORY_LIST_RES, ProtoOACashFlowHistoryListRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateAccountListRequest(string accessToken, string clientMsgId = null)
        {
            var message = ProtoOAGetAccountListByAccessTokenReq.CreateBuilder();

            message.SetAccessToken(accessToken);

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

        public ProtoMessage CreateTrendbarsRequest(int accountId, int symbolId, DateTimeOffset from, DateTimeOffset to, ProtoOATrendbarPeriod period, string clientMsgId = null)
        {
            var message = ProtoOAGetTrendbarsReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetFromTimestamp(from.ToUnixTimeMilliseconds());
            message.SetToTimestamp(to.ToUnixTimeMilliseconds());
            message.SetPeriod(period);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateTrendbarsResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_GET_TRENDBARS_RES, ProtoOAGetTrendbarsRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateTickDataRequest(int accountId, int symbolId, DateTimeOffset from, DateTimeOffset to, ProtoOAQuoteType type, string clientMsgId = null)
        {
            var message = ProtoOAGetTickDataReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetType(type);
            message.SetFromTimestamp(from.ToUnixTimeMilliseconds());
            message.SetToTimestamp(to.ToUnixTimeMilliseconds());

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
            {
                message.SetPosition(position);
            }

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateExecutionEvent(ProtoOAExecutionType executionType, ProtoOAOrder.Builder order, ProtoOAPosition.Builder position = null, string reasonCode = null, string clientMsgId = null)
        {
            return CreateExecutionEvent(executionType, order.Build(), position == null ? null : position.Build(), reasonCode, clientMsgId);
        }

        public ProtoMessage CreateMarketOrderRequest(long accountId, int symbolId, ProtoOATradeSide tradeSide, long volume, double? stoploss = null, double? takeProfit = null, string comment = null, string label = null, string clientMsgId = null)
        {
            var message = ProtoOANewOrderReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetOrderType(ProtoOAOrderType.MARKET);
            message.SetTradeSide(tradeSide);
            message.SetVolume(volume);

            if (stoploss.HasValue)
            {
                message.SetStopLoss(stoploss.Value);
            }

            if (takeProfit.HasValue)
            {
                message.SetTakeProfit(takeProfit.Value);
            }

            if (!string.IsNullOrEmpty(comment))
            {
                message.SetComment(comment);
            }

            if (!string.IsNullOrEmpty(label))
            {
                message.SetLabel(label);
            }

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateMarketRangeOrderRequest(long accountId, int symbolId, ProtoOATradeSide tradeSide, long volume, double baseSlippagePrice, int slippageInPoints, double? stoploss = null, double? takeProfit = null, string comment = null, string label = null, string clientMsgId = null)
        {
            var message = ProtoOANewOrderReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetOrderType(ProtoOAOrderType.MARKET_RANGE);
            message.SetTradeSide(tradeSide);
            message.SetVolume(volume);
            message.SetBaseSlippagePrice(baseSlippagePrice);
            message.SetSlippageInPoints(slippageInPoints);

            if (stoploss.HasValue)
            {
                message.SetStopLoss(stoploss.Value);
            }

            if (takeProfit.HasValue)
            {
                message.SetTakeProfit(takeProfit.Value);
            }

            if (!string.IsNullOrEmpty(comment))
            {
                message.SetComment(comment);
            }

            if (!string.IsNullOrEmpty(label))
            {
                message.SetLabel(label);
            }

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateLimitOrderRequest(long accountId, int symbolId, ProtoOATradeSide tradeSide, long volume, double price, DateTimeOffset? expirationTime = null, double? stoploss = null, double? takeProfit = null, string comment = null, string label = null, string clientMsgId = null)
        {
            var message = ProtoOANewOrderReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetOrderType(ProtoOAOrderType.LIMIT);
            message.SetTradeSide(tradeSide);
            message.SetVolume(volume);
            message.SetLimitPrice(price);

            if (expirationTime.HasValue)
            {
                message.SetExpirationTimestamp(expirationTime.Value.ToUnixTimeMilliseconds());
            }

            if (stoploss.HasValue)
            {
                message.SetStopLoss(stoploss.Value);
            }

            if (takeProfit.HasValue)
            {
                message.SetTakeProfit(takeProfit.Value);
            }

            if (!string.IsNullOrEmpty(comment))
            {
                message.SetComment(comment);
            }

            if (!string.IsNullOrEmpty(label))
            {
                message.SetLabel(label);
            }

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateStopOrderRequest(long accountId, int symbolId, ProtoOATradeSide tradeSide, long volume, double price, DateTimeOffset? expirationTime = null, double? stoploss = null, double? takeProfit = null, string comment = null, string label = null, string clientMsgId = null)
        {
            var message = ProtoOANewOrderReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetOrderType(ProtoOAOrderType.STOP);
            message.SetTradeSide(tradeSide);
            message.SetVolume(volume);
            message.SetLimitPrice(price);

            if (expirationTime.HasValue)
            {
                message.SetExpirationTimestamp(expirationTime.Value.ToUnixTimeMilliseconds());
            }

            if (stoploss.HasValue)
            {
                message.SetStopLoss(stoploss.Value);
            }

            if (takeProfit.HasValue)
            {
                message.SetTakeProfit(takeProfit.Value);
            }

            if (!string.IsNullOrEmpty(comment))
            {
                message.SetComment(comment);
            }

            if (!string.IsNullOrEmpty(label))
            {
                message.SetLabel(label);
            }

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateStopLimitOrderRequest(long accountId, int symbolId, ProtoOATradeSide tradeSide, long volume, double stopPrice, int slippageInPoints, DateTimeOffset? expirationTime = null, double? stoploss = null, double? takeProfit = null, string comment = null, string label = null, string clientMsgId = null)
        {
            var message = ProtoOANewOrderReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetOrderType(ProtoOAOrderType.STOP_LIMIT);
            message.SetTradeSide(tradeSide);
            message.SetVolume(volume);
            message.SetSlippageInPoints(slippageInPoints);
            message.SetStopPrice(stopPrice);

            if (expirationTime.HasValue)
            {
                message.SetExpirationTimestamp(expirationTime.Value.ToUnixTimeMilliseconds());
            }

            if (stoploss.HasValue)
            {
                message.SetStopLoss(stoploss.Value);
            }

            if (takeProfit.HasValue)
            {
                message.SetTakeProfit(takeProfit.Value);
            }

            if (!string.IsNullOrEmpty(comment))
            {
                message.SetComment(comment);
            }

            if (!string.IsNullOrEmpty(label))
            {
                message.SetLabel(label);
            }

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateCancelOrderRequest(long accountId, long orderId, string clientMsgId = null)
        {
            var message = ProtoOACancelOrderReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetOrderId(orderId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateClosePositionRequest(long accountId, long positionId, long volume, string clientMsgId = null)
        {
            var message = ProtoOAClosePositionReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetPositionId(positionId);
            message.SetVolume(volume);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateAmendPositionProtectionRequest(long accountId, long positionId, double? stopLossPrice = null, double? takeProfitPrice = null, string clientMsgId = null)
        {
            var message = ProtoOAAmendPositionSLTPReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetPositionId(positionId);

            if (stopLossPrice.HasValue)
            {
                message.SetStopLoss(stopLossPrice.Value);
            }

            if (takeProfitPrice.HasValue)
            {
                message.SetTakeProfit(takeProfitPrice.Value);
            }

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public ProtoMessage CreateAmendPendingOrderRequest(long accountId, long orderId, ProtoOAOrderType orderType, double? price = null, DateTimeOffset? expirationTime = null, double? stoploss = null, double? takeProfit = null, string clientMsgId = null)
        {
            var message = ProtoOAAmendOrderReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetOrderId(orderId);

            if (price.HasValue)
            {
                switch (orderType)
                {
                    case ProtoOAOrderType.LIMIT:
                        message.SetLimitPrice(price.Value);
                        break;
                    case ProtoOAOrderType.STOP:
                    case ProtoOAOrderType.STOP_LIMIT:
                        message.SetStopPrice(price.Value);
                        break;
                }
            }

            if (expirationTime.HasValue)
            {
                message.SetExpirationTimestamp(expirationTime.Value.ToUnixTimeMilliseconds());
            }

            if (stoploss.HasValue)
            {
                message.SetStopLoss(stoploss.Value);
            }

            if (takeProfit.HasValue)
            {
                message.SetTakeProfit(takeProfit.Value);
            }

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

        #endregion Creating new Proto messages with parameters specified
    }
}