using Google.ProtocolBuffers;
using System.Collections.Generic;

namespace Connect.Trading
{
    public static class MessageFactory
    {
        #region Message creation methods with parameters

        public static ProtoMessage CreateMessage(uint payloadType, ByteString payload = null, string clientMsgId = null)
        {
            ProtoMessage.Builder protoMsg = ProtoMessage.CreateBuilder();

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
            return CreateMessage(
                (uint)ProtoPayloadType.PING_REQ, ProtoPingReq.CreateBuilder().SetTimestamp(timestamp).Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreatePingResponse(ulong timestamp, string clientMsgId = null)
        {
            return CreateMessage(
                (uint)ProtoPayloadType.PING_REQ, ProtoPingRes.CreateBuilder().SetTimestamp(timestamp).Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateHeartbeatEvent(string clientMsgId = null)
        {
            return CreateMessage(
                (uint)ProtoPayloadType.HEARTBEAT_EVENT, ProtoHeartbeatEvent.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAuthorizationRequest(string clientId, string clientSecret, string clientMsgId = null)
        {
            ProtoOAAuthReq.Builder _msg = ProtoOAAuthReq.CreateBuilder();

            _msg.SetClientId(clientId);
            _msg.SetClientSecret(clientSecret);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAuthorizationResponse(string clientMsgId = null)
        {
            return CreateMessage(
                (uint)ProtoOAPayloadType.OA_AUTH_RES, ProtoOAAuthRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSubscribeForTradingEventsRequest(long accountId, string accessToken, string clientMsgId = null)
        {
            ProtoOASubscribeForTradingEventsReq.Builder _msg = ProtoOASubscribeForTradingEventsReq.CreateBuilder();

            _msg.SetAccountId(accountId);
            _msg.SetAccessToken(accessToken);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSubscribeForTradingEventsResponse(string clientMsgId = null)
        {
            return CreateMessage(
                (uint)ProtoOAPayloadType.OA_SUBSCRIBE_FOR_TRADING_EVENTS_RES,
                ProtoOASubscribeForTradingEventsRes.CreateBuilder().Build().ToByteString(),
                clientMsgId);
        }

        public static ProtoMessage CreateUnsubscribeForTradingEventsRequest(long accountId, string clientMsgId = null)
        {
            ProtoOAUnsubscribeFromTradingEventsReq.Builder _msg = ProtoOAUnsubscribeFromTradingEventsReq.CreateBuilder();

            _msg.SetAccountId(accountId);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateUnsubscribeForTradingEventsResponse(string clientMsgId = null)
        {
            return CreateMessage(
                (uint)ProtoOAPayloadType.OA_UNSUBSCRIBE_FROM_TRADING_EVENTS_RES,
                ProtoOAUnsubscribeFromTradingEventsRes.CreateBuilder().Build().ToByteString(),
                clientMsgId);
        }

        public static ProtoMessage CreateAllSubscriptionsForTradingEventsRequest(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.OA_GET_SUBSCRIBED_ACCOUNTS_REQ,
                ProtoOAGetSubscribedAccountsReq.CreateBuilder().Build().ToByteString(),
                clientMsgId);
        }

        public static ProtoMessage CreateAllSubscriptionsForTradingEventsResponse(List<long> accountIdsList, string clientMsgId = null)
        {
            var _msg = ProtoOAGetSubscribedAccountsRes.CreateBuilder();
            foreach (var accountId in accountIdsList)
                _msg.AddAccountId(accountId);
            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateExecutionEvent(
            ProtoOAExecutionType executionType,
            ProtoOAOrder order,
            ProtoOAPosition position = null,
            string reasonCode = null,
            string clientMsgId = null)
        {
            ProtoOAExecutionEvent.Builder _msg = ProtoOAExecutionEvent.CreateBuilder();

            _msg.SetExecutionType(executionType);
            _msg.SetOrder(order);

            if (position != null)
            {
                _msg.SetPosition(position);
            }

            if (reasonCode != null)
            {
                _msg.SetReasonCode(reasonCode);
            }

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateExecutionEvent(
            ProtoOAExecutionType executionType,
            ProtoOAOrder.Builder order,
            ProtoOAPosition.Builder position = null,
            string reasonCode = null,
            string clientMsgId = null)
        {
            return CreateExecutionEvent(executionType, order.Build(), position == null ? null : position.Build(), reasonCode, clientMsgId);
        }

        public static ProtoMessage CreateMarketOrderRequest(
            long accountId,
            string accessToken,
            string symbolName,
            ProtoTradeSide tradeSide,
            long volume,
            string comment = null,
            int? stopLossInPips = null,
            int? takeProfitInPips = null,
            double? stopLossPrice = null,
            double? takeProfitPrice = null,
            long? positionId = null,
            string clientMsgId = null)
        {
            ProtoOACreateOrderReq.Builder _msg = ProtoOACreateOrderReq.CreateBuilder();

            _msg.SetAccountId(accountId);
            _msg.SetAccessToken(accessToken);
            _msg.SetSymbolName(symbolName);
            _msg.SetOrderType(ProtoOAOrderType.OA_MARKET);
            _msg.SetTradeSide(tradeSide);
            _msg.SetVolume(volume);

            if (stopLossInPips.HasValue)
            {
                _msg.SetRelativeStopLossInPips(stopLossInPips.Value);
            }

            if (takeProfitInPips.HasValue)
            {
                _msg.SetRelativeTakeProfitInPips(takeProfitInPips.Value);
            }

            if (stopLossPrice.HasValue)
            {
                _msg.SetStopLossPrice(stopLossPrice.Value);
            }

            if (takeProfitPrice.HasValue)
            {
                _msg.SetTakeProfitPrice(takeProfitPrice.Value);
            }

            if (comment != null)
            {
                _msg.SetComment(comment);
            }

            if (positionId.HasValue)
            {
                _msg.SetPositionId(positionId.Value);
            }

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateMarketRangeOrderRequest(
            long accountId,
            string accessToken,
            string symbolName,
            ProtoTradeSide tradeSide,
            long volume,
            long slippageInPips,
            double baseSlippagePrice,
            string comment = null,
            int? stopLossInPips = null,
            int? takeProfitInPips = null,
            double? stopLossPrice = null,
            double? takeProfitPrice = null,
            long? positionId = null,
            string clientMsgId = null)
        {
            ProtoOACreateOrderReq.Builder _msg = ProtoOACreateOrderReq.CreateBuilder();

            _msg.SetAccountId(accountId);
            _msg.SetAccessToken(accessToken);
            _msg.SetSymbolName(symbolName);
            _msg.SetOrderType(ProtoOAOrderType.OA_MARKET_RANGE);
            _msg.SetTradeSide(tradeSide);
            _msg.SetVolume(volume);
            _msg.SetBaseSlippagePrice(baseSlippagePrice);
            _msg.SetSlippageInPips(slippageInPips);

            if (stopLossInPips.HasValue)
            {
                _msg.SetRelativeStopLossInPips(stopLossInPips.Value);
            }

            if (takeProfitInPips.HasValue)
            {
                _msg.SetRelativeTakeProfitInPips(takeProfitInPips.Value);
            }

            if (stopLossPrice.HasValue)
            {
                _msg.SetStopLossPrice(stopLossPrice.Value);
            }

            if (takeProfitPrice.HasValue)
            {
                _msg.SetTakeProfitPrice(takeProfitPrice.Value);
            }

            if (comment != null)
            {
                _msg.SetComment(comment);
            }

            if (positionId.HasValue)
            {
                _msg.SetPositionId(positionId.Value);
            }

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateLimitOrderRequest(
            long accountId,
            string accessToken,
            string symbolName,
            ProtoTradeSide tradeSide,
            long volume,
            double limitPrice,
            string comment = null,
            int? stopLossInPips = null,
            int? takeProfitInPips = null,
            double? stopLossPrice = null,
            double? takeProfitPrice = null,
            long? expirationTimestamp = null,
            string clientMsgId = null)
        {
            ProtoOACreateOrderReq.Builder _msg = ProtoOACreateOrderReq.CreateBuilder();

            _msg.SetAccountId(accountId);
            _msg.SetAccessToken(accessToken);
            _msg.SetSymbolName(symbolName);
            _msg.SetOrderType(ProtoOAOrderType.OA_LIMIT);
            _msg.SetTradeSide(tradeSide);
            _msg.SetVolume(volume);
            _msg.SetLimitPrice(limitPrice);

            if (stopLossInPips.HasValue)
            {
                _msg.SetRelativeStopLossInPips(stopLossInPips.Value);
            }

            if (takeProfitInPips.HasValue)
            {
                _msg.SetRelativeTakeProfitInPips(takeProfitInPips.Value);
            }

            if (stopLossPrice.HasValue)
            {
                _msg.SetStopLossPrice(stopLossPrice.Value);
            }

            if (takeProfitPrice.HasValue)
            {
                _msg.SetTakeProfitPrice(takeProfitPrice.Value);
            }

            if (comment != null)
            {
                _msg.SetComment(comment);
            }

            if (expirationTimestamp.HasValue)
            {
                _msg.SetExpirationTimestamp(expirationTimestamp.Value);
            }

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateStopOrderRequest(
            long accountId,
            string accessToken,
            string symbolName,
            ProtoTradeSide tradeSide,
            long volume,
            double stopPrice,
            string comment = null,
            int? stopLossInPips = null,
            int? takeProfitInPips = null,
            double? stopLossPrice = null,
            double? takeProfitPrice = null,
            long? expirationTimestamp = null,
            string clientMsgId = null)
        {
            ProtoOACreateOrderReq.Builder _msg = ProtoOACreateOrderReq.CreateBuilder();

            _msg.SetAccountId(accountId);
            _msg.SetAccessToken(accessToken);
            _msg.SetSymbolName(symbolName);
            _msg.SetOrderType(ProtoOAOrderType.OA_STOP);
            _msg.SetTradeSide(tradeSide);
            _msg.SetVolume(volume);
            _msg.SetStopPrice(stopPrice);

            if (stopLossInPips.HasValue)
            {
                _msg.SetRelativeStopLossInPips(stopLossInPips.Value);
            }

            if (takeProfitInPips.HasValue)
            {
                _msg.SetRelativeTakeProfitInPips(takeProfitInPips.Value);
            }

            if (stopLossPrice.HasValue)
            {
                _msg.SetStopLossPrice(stopLossPrice.Value);
            }

            if (takeProfitPrice.HasValue)
            {
                _msg.SetTakeProfitPrice(takeProfitPrice.Value);
            }

            if (comment != null)
            {
                _msg.SetComment(comment);
            }

            if (expirationTimestamp.HasValue)
            {
                _msg.SetExpirationTimestamp(expirationTimestamp.Value);
            }

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateCancelOrderRequest(long accountId, string accessToken, long orderId, string clientMsgId = null)
        {
            ProtoOACancelOrderReq.Builder _msg = ProtoOACancelOrderReq.CreateBuilder();

            _msg.SetAccountId(accountId);
            _msg.SetAccessToken(accessToken);
            _msg.SetOrderId(orderId);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateClosePositionRequest(long accountId,
            string accessToken,
            long positionId,
            long volume,
            string clientMsgId = null)
        {
            ProtoOAClosePositionReq.Builder _msg = ProtoOAClosePositionReq.CreateBuilder();

            _msg.SetAccountId(accountId);
            _msg.SetAccessToken(accessToken);
            _msg.SetPositionId(positionId);
            _msg.SetVolume(volume);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAmendPositionStopLossRequest(long accountId,
            string accessToken,
            long positionId,
            double stopLossPrice,
            string clientMsgId = null)
        {
            ProtoOAAmendPositionStopLossTakeProfitReq.Builder _msg = ProtoOAAmendPositionStopLossTakeProfitReq.CreateBuilder();

            _msg.SetAccountId(accountId);
            _msg.SetAccessToken(accessToken);
            _msg.SetPositionId(positionId);
            _msg.SetStopLossPrice(stopLossPrice);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAmendPositionTakeProfitRequest(long accountId,
            string accessToken,
            long positionId,
            double takeProfitPrice,
            string clientMsgId = null)
        {
            ProtoOAAmendPositionStopLossTakeProfitReq.Builder _msg = ProtoOAAmendPositionStopLossTakeProfitReq.CreateBuilder();

            _msg.SetAccountId(accountId);
            _msg.SetAccessToken(accessToken);
            _msg.SetPositionId(positionId);
            _msg.SetTakeProfitPrice(takeProfitPrice);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAmendPositionProtectionRequest(
            long accountId,
            string accessToken,
            long positionId,
            double? stopLossPrice,
            double? takeProfitPrice,
            string clientMsgId = null)
        {
            ProtoOAAmendPositionStopLossTakeProfitReq.Builder _msg = ProtoOAAmendPositionStopLossTakeProfitReq.CreateBuilder();

            _msg.SetAccountId(accountId);
            _msg.SetAccessToken(accessToken);
            _msg.SetPositionId(positionId);

            if (stopLossPrice.HasValue)
            {
                _msg.SetStopLossPrice(stopLossPrice.Value);
            }

            if (takeProfitPrice.HasValue)
            {
                _msg.SetTakeProfitPrice(takeProfitPrice.Value);
            }

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAmendLimitOrderRequest(long accountId,
            string accessToken,
            long orderId,
            double limitPrice,
            double? stopLossPrice = null,
            double? takeProfitPrice = null,
            long? expirationTimestamp = null,
            string clientMsgId = null)
        {
            ProtoOAAmendOrderReq.Builder _msg = ProtoOAAmendOrderReq.CreateBuilder();

            _msg.SetAccountId(accountId);
            _msg.SetAccessToken(accessToken);
            _msg.SetOrderId(orderId);
            _msg.SetLimitPrice(limitPrice);

            if (stopLossPrice.HasValue)
            {
                _msg.SetStopLossPrice(stopLossPrice.Value);
            }

            if (takeProfitPrice.HasValue)
            {
                _msg.SetTakeProfitPrice(takeProfitPrice.Value);
            }

            if (expirationTimestamp.HasValue)
            {
                _msg.SetExpirationTimestamp(expirationTimestamp.Value);
            }

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAmendStopOrderRequest(
            long accountId,
            string accessToken,
            long orderId,
            double stopPrice,
            double? stopLossPrice = null,
            double? takeProfitPrice = null,
            long? expirationTimestamp = null,
            string clientMsgId = null)
        {
            ProtoOAAmendOrderReq.Builder _msg = ProtoOAAmendOrderReq.CreateBuilder();

            _msg.SetAccountId(accountId);
            _msg.SetAccessToken(accessToken);
            _msg.SetOrderId(orderId);
            _msg.SetStopPrice(stopPrice);

            if (stopLossPrice.HasValue)
            {
                _msg.SetStopLossPrice(stopLossPrice.Value);
            }

            if (takeProfitPrice.HasValue)
            {
                _msg.SetTakeProfitPrice(takeProfitPrice.Value);
            }

            if (expirationTimestamp.HasValue)
            {
                _msg.SetExpirationTimestamp(expirationTimestamp.Value);
            }

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSubscribeForSpotsRequest(long accountId, string accessToken, string symbolName, string clientMsgId = null)
        {
            ProtoOASubscribeForSpotsReq.Builder _msg = ProtoOASubscribeForSpotsReq.CreateBuilder();

            _msg.SetAccountId(accountId);
            _msg.SetAccessToken(accessToken);
            _msg.SetSymblolName(symbolName);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSubscribeForSpotsResponse(uint subscriptionId, string clientMsgId = null)
        {
            ProtoOASubscribeForSpotsRes.Builder _msg = ProtoOASubscribeForSpotsRes.CreateBuilder();

            _msg.SetSubscriptionId(subscriptionId);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateUnsubscribeFromAllSpotsRequest(string clientMsgId = null)
        {
            ProtoOAUnsubscribeFromSpotsReq.Builder _msg = ProtoOAUnsubscribeFromSpotsReq.CreateBuilder();

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateUnsubscribeAccountFromSpotsRequest(uint subscriptionId, string clientMsgId = null)
        {
            ProtoOAUnsubscribeFromSpotsReq.Builder _msg = ProtoOAUnsubscribeFromSpotsReq.CreateBuilder();

            _msg.SetSubscriptionId(subscriptionId);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateUnsubscribeFromSymbolSpotsRequest(string symbolName, string clientMsgId = null)
        {
            ProtoOAUnsubscribeFromSpotsReq.Builder _msg = ProtoOAUnsubscribeFromSpotsReq.CreateBuilder();

            _msg.SetSymblolName(symbolName);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateUnsubscribeAccountFromSymbolSpotsRequest(uint subscriptionId, string symbolName, string clientMsgId = null)
        {
            ProtoOAUnsubscribeFromSpotsReq.Builder _msg = ProtoOAUnsubscribeFromSpotsReq.CreateBuilder();

            _msg.SetSubscriptionId(subscriptionId);
            _msg.SetSymblolName(symbolName);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateUnsubscribeFromSpotsResponse(string clientMsgId = null)
        {
            ProtoOAUnsubscribeFromSpotsRes.Builder _msg = ProtoOAUnsubscribeFromSpotsRes.CreateBuilder();

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateGetSpotSubscriptionRequest(uint subscriptionId, string clientMsgId = null)
        {
            ProtoOAGetSpotSubscriptionReq.Builder _msg = ProtoOAGetSpotSubscriptionReq.CreateBuilder();

            _msg.SetSubscriptionId(subscriptionId);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateGetSpotSubscriptionResponse(ProtoOASpotSubscription spotSubscription, string clientMsgId = null)
        {
            ProtoOAGetSpotSubscriptionRes.Builder _msg = ProtoOAGetSpotSubscriptionRes.CreateBuilder();

            _msg.SetSpotSubscription(spotSubscription);

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateGetAllSpotSubscriptionsRequest(string clientMsgId = null)
        {
            ProtoOAGetAllSpotSubscriptionsReq.Builder _msg = ProtoOAGetAllSpotSubscriptionsReq.CreateBuilder();

            return CreateMessage((uint)_msg.PayloadType, _msg.Build().ToByteString(), clientMsgId);
        }

        #endregion Message creation methods with parameters

        #region Message creation methods from byte arrays

        public static ProtoMessage GetMessage(byte[] msg) => ProtoMessage.CreateBuilder().MergeFrom(msg).Build();

        public static ByteString GetPayload(byte[] msg) => ProtoMessage.CreateBuilder().MergeFrom(msg).Build().Payload;

        public static uint GetPayloadType(byte[] msg) => ProtoMessage.CreateBuilder().MergeFrom(msg).Build().PayloadType;

        public static ProtoPingReq GetPingRequest(byte[] msg = null)
        {
            return ProtoPingReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoPingRes GetPingResponse(byte[] msg = null)
        {
            ProtoMessage protoMessage = ProtoMessage.CreateBuilder().MergeFrom(msg).Build();

            return ProtoPingRes.CreateBuilder().MergeFrom(protoMessage.Payload).Build();
        }

        public static ProtoHeartbeatEvent GetHeartbeatEvent(byte[] msg = null)
        {
            ProtoMessage protoMessage = ProtoMessage.CreateBuilder().MergeFrom(msg).Build();

            return ProtoHeartbeatEvent.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoErrorRes GetErrorResponse(byte[] msg = null)
        {
            return ProtoErrorRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAAuthReq GetAuthorizationRequest(byte[] msg = null)
        {
            return ProtoOAAuthReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAAuthRes GetAuthorizationResponse(byte[] msg = null)
        {
            return ProtoOAAuthRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOASubscribeForTradingEventsReq GetSubscribeForTradingEventsRequest(byte[] msg = null)
        {
            return ProtoOASubscribeForTradingEventsReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOASubscribeForTradingEventsRes GetSubscribeForTradingEventsResponse(byte[] msg = null)
        {
            return ProtoOASubscribeForTradingEventsRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAUnsubscribeFromTradingEventsReq GetUnsubscribeForTradingEventsRequest(byte[] msg = null)
        {
            return ProtoOAUnsubscribeFromTradingEventsReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAUnsubscribeFromTradingEventsRes GetUnsubscribeForTradingEventsResponse(byte[] msg = null)
        {
            return ProtoOAUnsubscribeFromTradingEventsRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAGetSubscribedAccountsReq GetAllSubscriptionsForTradingEventsRequest(byte[] msg = null)
        {
            return ProtoOAGetSubscribedAccountsReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAGetSubscribedAccountsRes GetAllSubscriptionsForTradingEventsResponse(byte[] msg = null)
        {
            return ProtoOAGetSubscribedAccountsRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAExecutionEvent GetExecutionEvent(byte[] msg = null)
        {
            return ProtoOAExecutionEvent.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOACreateOrderReq GetCreateOrderRequest(byte[] msg = null)
        {
            return ProtoOACreateOrderReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOACancelOrderReq GetCancelOrderRequest(byte[] msg = null)
        {
            return ProtoOACancelOrderReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAClosePositionReq GetClosePositionRequest(byte[] msg = null)
        {
            return ProtoOAClosePositionReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAAmendPositionStopLossTakeProfitReq GetAmendPositionStopLossTakeProfitRequest(byte[] msg = null)
        {
            return ProtoOAAmendPositionStopLossTakeProfitReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAAmendOrderReq GetAmendOrderRequest(byte[] msg = null)
        {
            return ProtoOAAmendOrderReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOASubscribeForSpotsReq GetSubscribeForSpotsRequest(byte[] msg = null)
        {
            return ProtoOASubscribeForSpotsReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOASubscribeForSpotsRes GetSubscribeForSpotsResponse(byte[] msg = null)
        {
            return ProtoOASubscribeForSpotsRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAUnsubscribeFromSpotsReq GetUnsubscribeFromSpotsRequest(byte[] msg = null)
        {
            return ProtoOAUnsubscribeFromSpotsReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAUnsubscribeFromSpotsRes GetUnsubscribeFromSpotsResponse(byte[] msg = null)
        {
            return ProtoOAUnsubscribeFromSpotsRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAGetSpotSubscriptionReq GetGetSpotSubscriptionRequest(byte[] msg = null)
        {
            return ProtoOAGetSpotSubscriptionReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAGetSpotSubscriptionRes GetGetSpotSubscriptionResponse(byte[] msg = null)
        {
            return ProtoOAGetSpotSubscriptionRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAGetAllSpotSubscriptionsReq GetGetAllSpotSubscriptionsRequest(byte[] msg = null)
        {
            return ProtoOAGetAllSpotSubscriptionsReq.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOAGetAllSpotSubscriptionsRes GetGetAllSpotSubscriptionsResponse(byte[] msg = null)
        {
            return ProtoOAGetAllSpotSubscriptionsRes.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        public static ProtoOASpotEvent GetSpotEvent(byte[] msg = null)
        {
            return ProtoOASpotEvent.CreateBuilder().MergeFrom(GetPayload(msg)).Build();
        }

        #endregion Message creation methods from byte arrays
    }
}