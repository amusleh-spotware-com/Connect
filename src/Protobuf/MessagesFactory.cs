using Connect.Protobuf.Models;
using Google.ProtocolBuffers;
using System.Collections.Generic;

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

        public static ProtoMessage CreatePingRequest(PingRequestMessageArgs messageArgs)
        {
            return CreateMessage((uint)ProtoPayloadType.PING_REQ,
                ProtoPingReq.CreateBuilder().SetTimestamp(messageArgs.Timestamp).Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreatePingResponse(ulong timestamp, string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoPayloadType.PING_REQ,
                ProtoPingRes.CreateBuilder().SetTimestamp(timestamp).Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateVersionRequest(string clientMsgId = null)
        {
            var message = ProtoOAVersionReq.CreateBuilder();
            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateVersionResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_VERSION_RES,
                ProtoOAApplicationAuthRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateHeartbeatEvent(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoPayloadType.HEARTBEAT_EVENT, ProtoHeartbeatEvent.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAppAuthorizationRequest(AppAuthorizationRequestMessageArgs messageArgs)
        {
            var message = ProtoOAApplicationAuthReq.CreateBuilder();

            message.SetClientId(messageArgs.ClientId);
            message.SetClientSecret(messageArgs.ClientSecret);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAppAuthorizationResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_APPLICATION_AUTH_RES, ProtoOAApplicationAuthRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAccountAuthorizationRequest(AccountAuthorizationRequestMessageArgs messageArgs)
        {
            var message = ProtoOAAccountAuthReq.CreateBuilder();

            message.SetAccessToken(messageArgs.Token);
            message.SetCtidTraderAccountId(messageArgs.AccountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAccountAuthorizationResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ACCOUNT_AUTH_RES, ProtoOAAccountAuthRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAssetClassListRequest(AssetClassListRequestMessageArgs messageArgs)
        {
            var message = ProtoOAAssetClassListReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);

            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_REQ, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAssetClassListResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_RES, ProtoOAAssetClassListRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateDealsListRequest(DealsListRequestMessageArgs messageArgs)
        {
            var message = ProtoOADealListReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);
            message.SetFromTimestamp(messageArgs.From.ToUnixTimeMilliseconds());
            message.SetToTimestamp(messageArgs.To.ToUnixTimeMilliseconds());

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
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

        public static ProtoMessage CreateCashflowHistoryRequest(CashflowHistoryRequestMessageArgs messageArgs)
        {
            var message = ProtoOACashFlowHistoryListReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);
            message.SetFromTimestamp(messageArgs.From.ToUnixTimeMilliseconds());
            message.SetToTimestamp(messageArgs.To.ToUnixTimeMilliseconds());

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateCashflowHistoryResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_CASH_FLOW_HISTORY_LIST_RES, ProtoOACashFlowHistoryListRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateAccountListRequest(AccountListRequestMessageArgs messageArgs)
        {
            var message = ProtoOAGetAccountListByAccessTokenReq.CreateBuilder();

            message.SetAccessToken(messageArgs.Token);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAccountListResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_GET_ACCOUNTS_BY_ACCESS_TOKEN_RES, ProtoOAGetAccountListByAccessTokenRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolsListRequest(SymbolsListRequestMessageArgs messageArgs)
        {
            var message = ProtoOASymbolsListReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolsListResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_SYMBOLS_LIST_RES, ProtoOASymbolsListRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateTrendbarsRequest(TrendbarsRequestMessageArgs messageArgs)
        {
            var message = ProtoOAGetTrendbarsReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);
            message.SetSymbolId(messageArgs.SymbolId);
            message.SetFromTimestamp(messageArgs.From.ToUnixTimeMilliseconds());
            message.SetToTimestamp(messageArgs.To.ToUnixTimeMilliseconds());
            message.SetPeriod(messageArgs.Period);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateTrendbarsResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_GET_TRENDBARS_RES, ProtoOAGetTrendbarsRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateTickDataRequest(TickDataRequestMessageArgs messageArgs)
        {
            var message = ProtoOAGetTickDataReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);
            message.SetSymbolId(messageArgs.SymbolId);
            message.SetType(messageArgs.QuoteType);
            message.SetFromTimestamp(messageArgs.From.ToUnixTimeMilliseconds());
            message.SetToTimestamp(messageArgs.To.ToUnixTimeMilliseconds());

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateTickDataResponse(string clientMsgId = null)
        {
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_GET_TICKDATA_RES, ProtoOAGetTickDataRes.CreateBuilder().Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateExecutionEvent(ExecutionEventMessageArgs messageArgs)
        {
            var message = ProtoOAExecutionEvent.CreateBuilder();

            message.SetExecutionType(messageArgs.ExecutionType);

            if (messageArgs.Order != null)
            {
                message.SetOrder(messageArgs.Order);
            }
            else if (messageArgs.OrderBuilder != null)
            {
                message.SetOrder(messageArgs.OrderBuilder.Build());
            }

            if (messageArgs.Position != null)
            {
                message.SetPosition(messageArgs.Position);
            }
            else if (messageArgs.PositionBuilder != null)
            {
                message.SetPosition(messageArgs.PositionBuilder.Build());
            }

            if (!string.IsNullOrEmpty(messageArgs.ErrorCode))
            {
                message.SetErrorCode(messageArgs.ErrorCode);
            }

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateOrderRequest(OrderRequestMessageArgs messageArgs)
        {
            var message = ProtoOANewOrderReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);
            message.SetSymbolId(messageArgs.SymbolId);
            message.SetOrderType(messageArgs.OrderType);
            message.SetTradeSide(messageArgs.TradeSide);
            message.SetVolume(messageArgs.Volume);

            if (!string.IsNullOrEmpty(messageArgs.Comment))
            {
                message.SetComment(messageArgs.Comment);
            }

            if (!string.IsNullOrEmpty(messageArgs.Label))
            {
                message.SetLabel(messageArgs.Label);
            }

            switch (messageArgs.OrderType)
            {
                case ProtoOAOrderType.MARKET:
                case ProtoOAOrderType.MARKET_RANGE:
                    MarketOrderRequestMessageArgs marketOrderMessageArgs = messageArgs as MarketOrderRequestMessageArgs;

                    if (marketOrderMessageArgs.RelativeStopLoss.HasValue)
                    {
                        message.SetRelativeStopLoss(marketOrderMessageArgs.RelativeStopLoss.Value);
                    }

                    if (marketOrderMessageArgs.RelativeTakeProfit.HasValue)
                    {
                        message.SetRelativeTakeProfit(marketOrderMessageArgs.RelativeTakeProfit.Value);
                    }

                    if (marketOrderMessageArgs.PositionId.HasValue)
                    {
                        message.SetPositionId(marketOrderMessageArgs.PositionId.Value);
                    }

                    if (marketOrderMessageArgs.OrderType == ProtoOAOrderType.MARKET_RANGE)
                    {
                        MarketRangeOrderRequestMessageArgs marketRangeOrderMessageArgs = messageArgs as MarketRangeOrderRequestMessageArgs;

                        message.SetBaseSlippagePrice(marketRangeOrderMessageArgs.BaseSlippagePrice);
                        message.SetSlippageInPoints(marketRangeOrderMessageArgs.SlippageInPoints);
                    }

                    break;

                case ProtoOAOrderType.LIMIT:
                case ProtoOAOrderType.STOP:
                case ProtoOAOrderType.STOP_LIMIT:
                    PendingOrderRequestMessageArgs pendingOrderMessageArgs = messageArgs as PendingOrderRequestMessageArgs;

                    if (pendingOrderMessageArgs.ExpirationTime.HasValue)
                    {
                        message.SetExpirationTimestamp(pendingOrderMessageArgs.ExpirationTime.Value.ToUnixTimeMilliseconds());
                    }

                    if (pendingOrderMessageArgs.StopLossInPrice.HasValue)
                    {
                        message.SetStopLoss(pendingOrderMessageArgs.StopLossInPrice.Value);
                    }

                    if (pendingOrderMessageArgs.TakeProfitInPrice.HasValue)
                    {
                        message.SetTakeProfit(pendingOrderMessageArgs.TakeProfitInPrice.Value);
                    }

                    if (pendingOrderMessageArgs.OrderType == ProtoOAOrderType.LIMIT)
                    {
                        message.SetLimitPrice(pendingOrderMessageArgs.Price);
                    }
                    else
                    {
                        message.SetStopPrice(pendingOrderMessageArgs.Price);

                        if (pendingOrderMessageArgs.OrderType == ProtoOAOrderType.STOP_LIMIT)
                        {
                            StopLimitOrderRequestMessageArgs stopLimitOrderMessageArgs = pendingOrderMessageArgs as StopLimitOrderRequestMessageArgs;

                            message.SetSlippageInPoints(stopLimitOrderMessageArgs.SlippageInPoints);
                        }
                    }

                    break;
            }

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateCancelOrderRequest(CancelOrderRequestMessageArgs messageArgs)
        {
            var message = ProtoOACancelOrderReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);
            message.SetOrderId(messageArgs.OrderId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateClosePositionRequest(ClosePositionRequestMessageArgs messageArgs)
        {
            var message = ProtoOAClosePositionReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);
            message.SetPositionId(messageArgs.PositionId);
            message.SetVolume(messageArgs.Volume);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAmendPositionProtectionRequest(AmendPositionProtectionRequestMessageArgs messageArgs)
        {
            var message = ProtoOAAmendPositionSLTPReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);
            message.SetPositionId(messageArgs.PositionId);

            if (messageArgs.StopLossPrice.HasValue)
            {
                message.SetStopLoss(messageArgs.StopLossPrice.Value);
            }

            if (messageArgs.TakeProfitPrice.HasValue)
            {
                message.SetTakeProfit(messageArgs.TakeProfitPrice.Value);
            }

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAmendPendingOrderRequest(AmendPendingOrderRequestMessageArgs messageArgs)
        {
            var message = ProtoOAAmendOrderReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);
            message.SetOrderId(messageArgs.OrderId);

            if (messageArgs.Price.HasValue)
            {
                switch (messageArgs.OrderType)
                {
                    case ProtoOAOrderType.LIMIT:
                        message.SetLimitPrice(messageArgs.Price.Value);
                        break;

                    case ProtoOAOrderType.STOP:
                    case ProtoOAOrderType.STOP_LIMIT:
                        message.SetStopPrice(messageArgs.Price.Value);
                        break;
                }
            }

            if (messageArgs.ExpirationTime.HasValue)
            {
                message.SetExpirationTimestamp(messageArgs.ExpirationTime.Value.ToUnixTimeMilliseconds());
            }

            if (messageArgs.StopLossPrice.HasValue)
            {
                message.SetStopLoss(messageArgs.StopLossPrice.Value);
            }

            if (messageArgs.TakeProfitPrice.HasValue)
            {
                message.SetTakeProfit(messageArgs.TakeProfitPrice.Value);
            }

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSubscribeForSpotsRequest(SubscribeForSpotsRequestMessageArgs messageArgs)
        {
            var message = ProtoOASubscribeSpotsReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);
            message.AddSymbolId(messageArgs.SymbolId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSubscribeForSpotsResponse(long accountId, string clientMsgId = null)
        {
            var message = ProtoOASubscribeSpotsRes.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateUnsubscribeFromSpotsRequest(SubscribeForSpotsRequestMessageArgs messageArgs)
        {
            var message = ProtoOAUnsubscribeSpotsReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);
            message.AddSymbolId(messageArgs.SymbolId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateTraderRequest(TraderRequestMessageArgs messageArgs)
        {
            var message = ProtoOATraderReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateTraderResponse(long accountId, string clientMsgId = null)
        {
            var message = ProtoOATraderRes.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateTraderUpdatedEvent(TraderUpdatedEventMessageArgs messageArgs)
        {
            var message = ProtoOATraderUpdatedEvent.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateCtidProfileRequest(CtidProfileRequestMessageArgs messageArgs)
        {
            var message = ProtoOAGetCtidProfileByTokenReq.CreateBuilder();

            message.SetAccessToken(messageArgs.Token);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateCtidProfileResponse(string accessToken, string clientMsgId = null)
        {
            var message = ProtoOAGetCtidProfileByTokenRes.CreateBuilder();

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolByIdRequest(SymbolByIdRequestMessageArgs messageArgs)
        {
            var message = ProtoOASymbolByIdReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);

            message.AddRangeSymbolId(messageArgs.SymbolIds);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolByIdResponse(long accountId, List<ProtoOASymbol> symbols, string clientMsgId = null)
        {
            var message = ProtoOASymbolByIdRes.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);

            message.AddRangeSymbol(symbols);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolsForConversionRequest(SymbolsForConversionRequestMessageArgs messageArgs)
        {
            var message = ProtoOASymbolsForConversionReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);
            message.SetFirstAssetId(messageArgs.FirstAssetId);
            message.SetLastAssetId(messageArgs.LastAssetId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolsForConversionResponse(long accountId, int index, ProtoOALightSymbol lightSymbol, string clientMsgId = null)
        {
            var message = ProtoOASymbolsForConversionRes.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbol(index, lightSymbol);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolCategoryListRequest(SymbolCategoryListRequestMessageArgs messageArgs)
        {
            var message = ProtoOASymbolCategoryListReq.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolCategoryListResponse(long accountId, int index, ProtoOASymbolCategory symbolCategory, string clientMsgId = null)
        {
            var message = ProtoOASymbolCategoryListRes.CreateBuilder();

            message.SetCtidTraderAccountId(accountId);
            message.SetSymbolCategory(index, symbolCategory);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), clientMsgId);
        }

        public static ProtoMessage CreateSymbolChangedEvent(SymbolChangedEventMessageArgs messageArgs)
        {
            var message = ProtoOASymbolChangedEvent.CreateBuilder();

            message.SetCtidTraderAccountId(messageArgs.AccountId);
            message.SetSymbolId(messageArgs.Index, messageArgs.SymbolId);

            return CreateMessage((uint)message.PayloadType, message.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        #endregion Creating new Proto messages with parameters specified
    }
}