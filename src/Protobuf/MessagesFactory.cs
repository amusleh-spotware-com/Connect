using Google.ProtocolBuffers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Connect.Protobuf
{
    public static class MessagesFactory
    {
        #region Building Proto messages from Byte array methods

        public static ProtoMessage GetMessage(byte[] message)
        {
            return ProtoMessage.CreateBuilder().MergeFrom(message).Build(); ;
        }

        public static ProtoPingRes GetPingResponse(ByteString messagePayload)
        {
            return ProtoPingRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoHeartbeatEvent GetHeartbeatEvent(ByteString messagePayload)
        {
            return ProtoHeartbeatEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAErrorRes GetErrorResponse(ByteString messagePayload)
        {
            return ProtoOAErrorRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAApplicationAuthRes GetApplicationAuthorizationResponse(ByteString messagePayload)
        {
            return ProtoOAApplicationAuthRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAAccountAuthRes GetAccountAuthorizationResponse(ByteString messagePayload)
        {
            return ProtoOAAccountAuthRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOADealListRes GetDealListResponse(ByteString messagePayload)
        {
            return ProtoOADealListRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAAssetListRes GetAssetListResponse(ByteString messagePayload)
        {
            return ProtoOAAssetListRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAClientDisconnectEvent GetClientDisconnectEvent(ByteString messagePayload)
        {
            return ProtoOAClientDisconnectEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAAccountsTokenInvalidatedEvent GetAccountsTokenInvalidatedEvent(ByteString messagePayload)
        {
            return ProtoOAAccountsTokenInvalidatedEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOACashFlowHistoryListRes GetCashFlowHistoryListResponse(ByteString messagePayload)
        {
            return ProtoOACashFlowHistoryListRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAExpectedMarginRes GetExpectedMarginResponse(ByteString messagePayload)
        {
            return ProtoOAExpectedMarginRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAGetAccountListByAccessTokenRes GetAccountListResponse(ByteString messagePayload)
        {
            return ProtoOAGetAccountListByAccessTokenRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAGetTickDataRes GetTickDataResponse(ByteString messagePayload)
        {
            return ProtoOAGetTickDataRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAGetTrendbarsRes GetTrendbarsResponse(ByteString messagePayload)
        {
            return ProtoOAGetTrendbarsRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAMarginChangedEvent GetMarginChangedEvent(ByteString messagePayload)
        {
            return ProtoOAMarginChangedEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAOrderErrorEvent GetOrderErrorEvent(ByteString messagePayload)
        {
            return ProtoOAOrderErrorEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAReconcileRes GetReconcileResponse(ByteString messagePayload)
        {
            return ProtoOAReconcileRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOASubscribeSpotsRes GetSubscribeSpotsResponse(ByteString messagePayload)
        {
            return ProtoOASubscribeSpotsRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOASymbolsForConversionRes GetSymbolsForConversionResponse(ByteString messagePayload)
        {
            return ProtoOASymbolsForConversionRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOASymbolsListRes GetSymbolsListResponse(ByteString messagePayload)
        {
            return ProtoOASymbolsListRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOASymbolByIdRes GetSymbolByIdResponse(ByteString messagePayload)
        {
            return ProtoOASymbolByIdRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOASymbolChangedEvent GetSymbolChangedEvent(ByteString messagePayload)
        {
            return ProtoOASymbolChangedEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOATraderRes GetTraderResponse(ByteString messagePayload)
        {
            return ProtoOATraderRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOATraderUpdatedEvent GetTraderUpdatedEvent(ByteString messagePayload)
        {
            return ProtoOATraderUpdatedEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOATrailingSLChangedEvent GetTrailingSLChangedEvent(ByteString messagePayload)
        {
            return ProtoOATrailingSLChangedEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAUnsubscribeSpotsRes GetUnsubscribeSpotsResponse(ByteString messagePayload)
        {
            return ProtoOAUnsubscribeSpotsRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAVersionRes GetVersionResponse(ByteString messagePayload)
        {
            return ProtoOAVersionRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAExecutionEvent GetExecutionEvent(ByteString messagePayload = null)
        {
            return ProtoOAExecutionEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOASpotEvent GetSpotEvent(ByteString messagePayload)
        {
            return ProtoOASpotEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAGetCtidProfileByTokenRes GetCtidProfileResponse(ByteString messagePayload)
        {
            return ProtoOAGetCtidProfileByTokenRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOASymbolCategoryListRes GetSymbolCategoryListResponse(ByteString messagePayload)
        {
            return ProtoOASymbolCategoryListRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        #endregion Building Proto messages from Byte array methods

        #region Creating new Proto messages with parameters specified

        public static ProtoMessage CreateMessage(uint payloadType, ByteString payload = null, string clientMsgId = null)
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

        public static ProtoMessage CreateMessage(ProtoMessage.Builder messageBuilder, string clientMsgId = null)
        {
            return CreateMessage(messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreatePingRequest(ulong timestamp, string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoPayloadType.PING_REQ, ProtoPingReq.CreateBuilder().SetTimestamp(timestamp).Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreatePingResponse(ulong timestamp, string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoPayloadType.PING_REQ, ProtoPingRes.CreateBuilder().SetTimestamp(timestamp).Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateVersionRequest(string clientMsgId = null)
        {
            var message = ProtoOAVersionReq.CreateBuilder();
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateVersionResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_VERSION_RES, ProtoOAApplicationAuthRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateHeartbeatEvent(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoPayloadType.HEARTBEAT_EVENT, ProtoHeartbeatEvent.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAppAuthorizationRequest(string clientId, string clientSecret, string clientMsgId = null)
        {
            var message = ProtoOAApplicationAuthReq.CreateBuilder();

            message.SetClientId(clientId);
            message.SetClientSecret(clientSecret);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAppAuthorizationResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_APPLICATION_AUTH_RES, ProtoOAApplicationAuthRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAccountAuthorizationRequest(string token, long accountId, string clientMsgId = null)
        {
            var message = ProtoOAAccountAuthReq.CreateBuilder();

            message.SetAccessToken(token);
            message.SetCtidTraderAccountId(accountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAccountAuthorizationResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ACCOUNT_AUTH_RES, ProtoOAAccountAuthRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAssetClassListRequest(long accountId, string clientMsgId = null)
        {
            var message = ProtoOAAssetClassListReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);

            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_REQ, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAssetClassListResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_RES, ProtoOAAssetClassListRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateDealsListRequest(long accountId, DateTimeOffset from, DateTimeOffset to, string clientMsgId = null)
        {
            var message = ProtoOADealListReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetFromTimestamp(from.ToUnixTimeMilliseconds());
            message.SetToTimestamp(to.ToUnixTimeMilliseconds());

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateDealsListResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_DEAL_LIST_RES, ProtoOADealListRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateReconcileRequest(long accountId, string clientMsgId = null)
        {
            var message = ProtoOAReconcileReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateReconcileResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_RECONCILE_RES, ProtoOAReconcileRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateCashflowHistoryRequest(long accountId, DateTimeOffset from, DateTimeOffset to, string clientMsgId = null)
        {
            var message = ProtoOACashFlowHistoryListReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetFromTimestamp(from.ToUnixTimeMilliseconds());
            message.SetToTimestamp(to.ToUnixTimeMilliseconds());

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateCashflowHistoryResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_CASH_FLOW_HISTORY_LIST_RES, ProtoOACashFlowHistoryListRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAccountListRequest(string accessToken, string clientMsgId = null)
        {
            var message = ProtoOAGetAccountListByAccessTokenReq.CreateBuilder();

            message.SetAccessToken(accessToken);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAccountListResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_GET_ACCOUNTS_BY_ACCESS_TOKEN_RES, ProtoOAGetAccountListByAccessTokenRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolsListRequest(long accountId, string clientMsgId = null)
        {
            var message = ProtoOASymbolsListReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolsListResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_SYMBOLS_LIST_RES, ProtoOASymbolsListRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateTrendbarsRequest(long accountId, long symbolId, DateTimeOffset from, DateTimeOffset to, ProtoOATrendbarPeriod period, string clientMsgId = null)
        {
            var message = ProtoOAGetTrendbarsReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetFromTimestamp(from.ToUnixTimeMilliseconds());
            message.SetToTimestamp(to.ToUnixTimeMilliseconds());
            message.SetPeriod(period);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateTrendbarsResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_GET_TRENDBARS_RES, ProtoOAGetTrendbarsRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateTickDataRequest(long accountId, long symbolId, DateTimeOffset from, DateTimeOffset to, ProtoOAQuoteType type, string clientMsgId = null)
        {
            var message = ProtoOAGetTickDataReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(symbolId);
            message.SetType(type);
            message.SetFromTimestamp(from.ToUnixTimeMilliseconds());
            message.SetToTimestamp(to.ToUnixTimeMilliseconds());

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateTickDataResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_GET_TICKDATA_RES, ProtoOAGetTickDataRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateExecutionEvent(ProtoOAExecutionType executionType, ProtoOAOrder order, ProtoOAPosition position = null, string reasonCode = null, string clientMsgId = null)
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

        public static ProtoMessage CreateExecutionEvent(ProtoOAExecutionType executionType, ProtoOAOrder.Builder order, ProtoOAPosition.Builder position = null, string reasonCode = null, string clientMsgId = null)
        {
            return CreateExecutionEvent(executionType, order.Build(), position == null ? null : position.Build(), reasonCode, clientMsgId);
        }

        public static ProtoMessage CreateMarketOrderRequest(long accountId, long symbolId, ProtoOATradeSide tradeSide, long volume, double? stoploss = null, double? takeProfit = null, string comment = null, string label = null, long? positionId = null, string clientMsgId = null)
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

            if (positionId.HasValue)
            {
                message.SetPositionId(positionId.Value);
            }

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateMarketRangeOrderRequest(long accountId, long symbolId, ProtoOATradeSide tradeSide, long volume, double baseSlippagePrice, int slippageInPoints, double? stoploss = null, double? takeProfit = null, string comment = null, string label = null, long? positionId = null, string clientMsgId = null)
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

            if (positionId.HasValue)
            {
                message.SetPositionId(positionId.Value);
            }

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateLimitOrderRequest(long accountId, long symbolId, ProtoOATradeSide tradeSide, long volume, double price, DateTimeOffset? expirationTime = null, double? stoploss = null, double? takeProfit = null, string comment = null, string label = null, string clientMsgId = null)
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

        public static ProtoMessage CreateStopOrderRequest(long accountId, long symbolId, ProtoOATradeSide tradeSide, long volume, double price, DateTimeOffset? expirationTime = null, double? stoploss = null, double? takeProfit = null, string comment = null, string label = null, string clientMsgId = null)
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

        public static ProtoMessage CreateStopLimitOrderRequest(long accountId, long symbolId, ProtoOATradeSide tradeSide, long volume, double stopPrice, int slippageInPoints, DateTimeOffset? expirationTime = null, double? stoploss = null, double? takeProfit = null, string comment = null, string label = null, string clientMsgId = null)
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

        public static ProtoMessage CreateCancelOrderRequest(long accountId, long orderId, string clientMsgId = null)
        {
            var message = ProtoOACancelOrderReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetOrderId(orderId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateClosePositionRequest(long accountId, long positionId, long volume, string clientMsgId = null)
        {
            var message = ProtoOAClosePositionReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetPositionId(positionId);
            message.SetVolume(volume);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAmendPositionProtectionRequest(long accountId, long positionId, double? stopLossPrice = null, double? takeProfitPrice = null, string clientMsgId = null)
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

        public static ProtoMessage CreateAmendPendingOrderRequest(long accountId, long orderId, ProtoOAOrderType orderType, double? price = null, DateTimeOffset? expirationTime = null, double? stoploss = null, double? takeProfit = null, string clientMsgId = null)
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

        public static ProtoMessage CreateSubscribeForSpotsRequest(long accountId, long symbolId, string clientMsgId = null)
        {
            var message = ProtoOASubscribeSpotsReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.AddSymbolId(symbolId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSubscribeForSpotsResponse(long accountId, string clientMsgId = null)
        {
            var message = ProtoOASubscribeSpotsRes.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateUnsubscribeFromSpotsRequest(long accountId, long symbolId, string clientMsgId = null)
        {
            var message = ProtoOAUnsubscribeSpotsReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.AddSymbolId(symbolId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateTraderResponse(long accountId, string clientMsgId = null)
        {
            var message = ProtoOATraderRes.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateTraderRequest(long accountId, string clientMsgId = null)
        {
            var message = ProtoOATraderReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateTraderUpdatedEvent(long accountId, string clientMsgId = null)
        {
            var message = ProtoOATraderUpdatedEvent.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateCtidProfileResponse(string accessToken, string clientMsgId = null)
        {
            var message = ProtoOAGetCtidProfileByTokenRes.CreateBuilder();

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateCtidProfileRequest(string accessToken, string clientMsgId = null)
        {
            var message = ProtoOAGetCtidProfileByTokenReq.CreateBuilder();

            message.SetAccessToken(accessToken);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolByIdResponse(long accountId, List<ProtoOASymbol> symbols, string clientMsgId = null)
        {
            var message = ProtoOASymbolByIdRes.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);

            message.AddRangeSymbol(symbols);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolByIdRequest(long accountId, List<long> symbolIds, string clientMsgId = null)
        {
            var message = ProtoOASymbolByIdReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);

            message.AddRangeSymbolId(symbolIds);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolsForConversionResponse(long accountId, int index, ProtoOALightSymbol lightSymbol, string clientMsgId = null)
        {
            var message = ProtoOASymbolsForConversionRes.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbol(index, lightSymbol);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolsForConversionRequest(long accountId, long firstAssetId, long lastAssetId, string clientMsgId = null)
        {
            var message = ProtoOASymbolsForConversionReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetFirstAssetId(firstAssetId);
            message.SetLastAssetId(lastAssetId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolCategoryListResponse(long accountId, int index, ProtoOASymbolCategory symbolCategory, string clientMsgId = null)
        {
            var message = ProtoOASymbolCategoryListRes.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolCategory(index, symbolCategory);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolCategoryListRequest(long accountId, string clientMsgId = null)
        {
            var message = ProtoOASymbolCategoryListReq.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolChangedEvent(long accountId, int index, long symbolId, string clientMsgId = null)
        {
            var message = ProtoOASymbolChangedEvent.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolId(index, symbolId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        #endregion Creating new Proto messages with parameters specified
    }
}