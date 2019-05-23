using Connect.Protobuf.MessageArgs;
using Connect.Protobuf.MessageArgs.Abstractions;
using Google.ProtocolBuffers;
using System;

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

        public static ProtoOAAssetClassListRes GetAssetClassListResponse(ByteString messagePayload)
        {
            return ProtoOAAssetClassListRes.CreateBuilder().MergeFrom(messagePayload).Build();
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

        public static ProtoOADepthEvent GetDepthEvent(ByteString messagePayload)
        {
            return ProtoOADepthEvent.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOASubscribeDepthQuotesRes GetSubscribeDepthQuotesResponse(ByteString messagePayload)
        {
            return ProtoOASubscribeDepthQuotesRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAUnsubscribeDepthQuotesRes GetUnsubscribeDepthQuotesResponse(ByteString messagePayload)
        {
            return ProtoOAUnsubscribeDepthQuotesRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        public static ProtoOAAccountLogoutRes GetAccountLogoutResponse(ByteString messagePayload)
        {
            return ProtoOAAccountLogoutRes.CreateBuilder().MergeFrom(messagePayload).Build();
        }

        #endregion Building Proto messages from Byte array methods

        #region Creating new Proto messages with parameters specified

        public static ProtoMessage CreateMessage(IMessageArgs messageArgs)
        {
            switch (messageArgs.PayloadType)
            {
                case (int)ProtoPayloadType.PING_REQ:
                    return CreatePingRequest(messageArgs as PingRequestMessageArgs);

                case (int)ProtoPayloadType.HEARTBEAT_EVENT:
                    return CreateHeartbeatEvent(messageArgs as HeartbeatEventMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_VERSION_REQ:
                    return CreateVersionRequest(messageArgs as VersionRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_APPLICATION_AUTH_REQ:
                    return CreateAppAuthorizationRequest(messageArgs as AppAuthorizationRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_ACCOUNT_AUTH_REQ:
                    return CreateAccountAuthorizationRequest(messageArgs as AccountAuthorizationRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_REQ:
                    return CreateAssetListRequest(messageArgs as AssetListRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_ASSET_CLASS_LIST_REQ:
                    return CreateAssetClassListRequest(messageArgs as AssetClassListRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_DEAL_LIST_REQ:
                    return CreateDealsListRequest(messageArgs as DealsListRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_CASH_FLOW_HISTORY_LIST_REQ:
                    return CreateCashflowHistoryRequest(messageArgs as CashflowHistoryRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_GET_ACCOUNTS_BY_ACCESS_TOKEN_REQ:
                    return CreateAccountListRequest(messageArgs as AccountListRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_LIST_REQ:
                    return CreateSymbolsListRequest(messageArgs as SymbolsListRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_GET_TRENDBARS_REQ:
                    return CreateTrendbarsRequest(messageArgs as TrendbarsRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_GET_TICKDATA_REQ:
                    return CreateTickDataRequest(messageArgs as TickDataRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_NEW_ORDER_REQ:
                    return CreateOrderRequest(messageArgs as OrderRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_CANCEL_ORDER_REQ:
                    return CreateCancelOrderRequest(messageArgs as CancelOrderRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_CLOSE_POSITION_REQ:
                    return CreateClosePositionRequest(messageArgs as ClosePositionRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_AMEND_ORDER_REQ:
                    return CreateAmendPendingOrderRequest(messageArgs as AmendPendingOrderRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_AMEND_POSITION_SLTP_REQ:
                    return CreateAmendPositionProtectionRequest(messageArgs as AmendPositionProtectionRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_SPOTS_REQ:
                    return CreateSubscribeForSpotsRequest(messageArgs as SpotsRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_SPOTS_REQ:
                    return CreateUnsubscribeFromSpotsRequest(messageArgs as SpotsRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_TRADER_REQ:
                    return CreateTraderRequest(messageArgs as TraderRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_TRADER_UPDATE_EVENT:
                    return CreateTraderUpdatedEvent(messageArgs as TraderUpdatedEventMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_GET_CTID_PROFILE_BY_TOKEN_REQ:
                    return CreateCtidProfileRequest(messageArgs as CtidProfileRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_BY_ID_REQ:
                    return CreateSymbolByIdRequest(messageArgs as SymbolByIdRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_FOR_CONVERSION_REQ:
                    return CreateSymbolsForConversionRequest(messageArgs as SymbolsForConversionRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_CATEGORY_REQ:
                    return CreateSymbolCategoryListRequest(messageArgs as SymbolCategoryListRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_CHANGED_EVENT:
                    return CreateSymbolChangedEvent(messageArgs as SymbolChangedEventMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_EXPECTED_MARGIN_REQ:
                    return CreateExpectedMarginRequest(messageArgs as ExpectedMarginRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_LIVE_TRENDBAR_REQ:
                    return CreateSubscribeForLiveTrendbarRequest(messageArgs as LiveTrendbarRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_LIVE_TRENDBAR_REQ:
                    return CreateUnsubscribeForLiveTrendbarRequest(messageArgs as LiveTrendbarRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_DEPTH_QUOTES_REQ:
                    return CreateSubscribeForDepthQuotesRequest(messageArgs as DepthQuotesRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_DEPTH_QUOTES_REQ:
                    return CreateUnsubscribeForDepthQuotesRequest(messageArgs as DepthQuotesRequestMessageArgs);

                case (int)ProtoOAPayloadType.PROTO_OA_ACCOUNT_LOGOUT_REQ:
                    return CreateAccountLogoutRequest(messageArgs as AccountLogoutRequestMessageArgs);

                default:
                    throw new InvalidOperationException("Unknown message payload type");
            }
        }

        public static ProtoMessage CreateMessage(uint payloadType, ByteString payload = null, string clientMsgId = null)
        {
            var messageBuilder = ProtoMessage.CreateBuilder();

            messageBuilder.PayloadType = payloadType;

            if (payload != null)
            {
                messageBuilder.SetPayload(payload);
            }

            if (clientMsgId != null)
            {
                messageBuilder.SetClientMsgId(clientMsgId);
            }

            return messageBuilder.Build();
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

        public static ProtoMessage CreateHeartbeatEvent(HeartbeatEventMessageArgs messageArgs)
        {
            return CreateMessage((uint)ProtoPayloadType.HEARTBEAT_EVENT, ProtoHeartbeatEvent.CreateBuilder().Build().ToByteString(),
                messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateVersionRequest(VersionRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAVersionReq.CreateBuilder();

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAppAuthorizationRequest(AppAuthorizationRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAApplicationAuthReq.CreateBuilder();

            messageBuilder.SetClientId(messageArgs.ClientId);

            messageBuilder.SetClientSecret(messageArgs.ClientSecret);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAccountAuthorizationRequest(AccountAuthorizationRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAAccountAuthReq.CreateBuilder();

            messageBuilder.SetAccessToken(messageArgs.Token);

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAssetListRequest(AssetListRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAAssetListReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_REQ, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAssetClassListRequest(AssetClassListRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAAssetClassListReq.CreateBuilder();
            
            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            
            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_REQ, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateDealsListRequest(DealsListRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOADealListReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);

            messageBuilder.SetFromTimestamp(messageArgs.From.ToUnixTimeMilliseconds());

            messageBuilder.SetToTimestamp(messageArgs.To.ToUnixTimeMilliseconds());
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateCashflowHistoryRequest(CashflowHistoryRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOACashFlowHistoryListReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);

            messageBuilder.SetFromTimestamp(messageArgs.From.ToUnixTimeMilliseconds());

            messageBuilder.SetToTimestamp(messageArgs.To.ToUnixTimeMilliseconds());
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAccountListRequest(AccountListRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAGetAccountListByAccessTokenReq.CreateBuilder();

            messageBuilder.SetAccessToken(messageArgs.Token);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolsListRequest(SymbolsListRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOASymbolsListReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateTrendbarsRequest(TrendbarsRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAGetTrendbarsReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            messageBuilder.SetSymbolId(messageArgs.SymbolId);
            messageBuilder.SetFromTimestamp(messageArgs.From.ToUnixTimeMilliseconds());
            messageBuilder.SetToTimestamp(messageArgs.To.ToUnixTimeMilliseconds());
            messageBuilder.SetPeriod(messageArgs.Period);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateTickDataRequest(TickDataRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAGetTickDataReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            messageBuilder.SetSymbolId(messageArgs.SymbolId);
            messageBuilder.SetType(messageArgs.QuoteType);
            messageBuilder.SetFromTimestamp(messageArgs.From.ToUnixTimeMilliseconds());
            messageBuilder.SetToTimestamp(messageArgs.To.ToUnixTimeMilliseconds());
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateOrderRequest(OrderRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOANewOrderReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            messageBuilder.SetSymbolId(messageArgs.SymbolId);
            messageBuilder.SetOrderType(messageArgs.OrderType);
            messageBuilder.SetTradeSide(messageArgs.TradeSide);
            messageBuilder.SetVolume(messageArgs.Volume);
            
            if (!string.IsNullOrEmpty(messageArgs.Comment))
            {
                messageBuilder.SetComment(messageArgs.Comment);
            }

            if (!string.IsNullOrEmpty(messageArgs.Label))
            {
                messageBuilder.SetLabel(messageArgs.Label);
            }

            switch (messageArgs.OrderType)
            {
                case ProtoOAOrderType.MARKET:
                case ProtoOAOrderType.MARKET_RANGE:
                    MarketOrderRequestMessageArgs marketOrderMessageArgs = messageArgs as MarketOrderRequestMessageArgs;

                    if (marketOrderMessageArgs.RelativeStopLoss.HasValue)
                    {
                        messageBuilder.SetRelativeStopLoss(marketOrderMessageArgs.RelativeStopLoss.Value);
                    }

                    if (marketOrderMessageArgs.RelativeTakeProfit.HasValue)
                    {
                        messageBuilder.SetRelativeTakeProfit(marketOrderMessageArgs.RelativeTakeProfit.Value);
                    }

                    if (marketOrderMessageArgs.PositionId.HasValue)
                    {
                        messageBuilder.SetPositionId(marketOrderMessageArgs.PositionId.Value);
                    }

                    if (marketOrderMessageArgs.OrderType == ProtoOAOrderType.MARKET_RANGE)
                    {
                        MarketRangeOrderRequestMessageArgs marketRangeOrderMessageArgs = messageArgs as MarketRangeOrderRequestMessageArgs;

                        messageBuilder.SetBaseSlippagePrice(marketRangeOrderMessageArgs.BaseSlippagePrice);
                        messageBuilder.SetSlippageInPoints(marketRangeOrderMessageArgs.SlippageInPoints);
                    }

                    break;

                case ProtoOAOrderType.LIMIT:
                case ProtoOAOrderType.STOP:
                case ProtoOAOrderType.STOP_LIMIT:
                    PendingOrderRequestMessageArgs pendingOrderMessageArgs = messageArgs as PendingOrderRequestMessageArgs;

                    if (pendingOrderMessageArgs.ExpirationTime.HasValue)
                    {
                        messageBuilder.SetExpirationTimestamp(pendingOrderMessageArgs.ExpirationTime.Value.ToUnixTimeMilliseconds());
                    }

                    if (pendingOrderMessageArgs.StopLossInPrice.HasValue)
                    {
                        messageBuilder.SetStopLoss(pendingOrderMessageArgs.StopLossInPrice.Value);
                    }

                    if (pendingOrderMessageArgs.TakeProfitInPrice.HasValue)
                    {
                        messageBuilder.SetTakeProfit(pendingOrderMessageArgs.TakeProfitInPrice.Value);
                    }

                    if (pendingOrderMessageArgs.OrderType == ProtoOAOrderType.LIMIT)
                    {
                        messageBuilder.SetLimitPrice(pendingOrderMessageArgs.Price);
                    }
                    else
                    {
                        messageBuilder.SetStopPrice(pendingOrderMessageArgs.Price);

                        if (pendingOrderMessageArgs.OrderType == ProtoOAOrderType.STOP_LIMIT)
                        {
                            StopLimitOrderRequestMessageArgs stopLimitOrderMessageArgs = pendingOrderMessageArgs as StopLimitOrderRequestMessageArgs;

                            messageBuilder.SetSlippageInPoints(stopLimitOrderMessageArgs.SlippageInPoints);
                        }
                    }

                    break;
            }

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateCancelOrderRequest(CancelOrderRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOACancelOrderReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            messageBuilder.SetOrderId(messageArgs.OrderId);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateClosePositionRequest(ClosePositionRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAClosePositionReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            messageBuilder.SetPositionId(messageArgs.PositionId);
            messageBuilder.SetVolume(messageArgs.Volume);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAmendPositionProtectionRequest(AmendPositionProtectionRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAAmendPositionSLTPReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            messageBuilder.SetPositionId(messageArgs.PositionId);
            
            if (messageArgs.StopLossPrice.HasValue)
            {
                messageBuilder.SetStopLoss(messageArgs.StopLossPrice.Value);
            }

            if (messageArgs.TakeProfitPrice.HasValue)
            {
                messageBuilder.SetTakeProfit(messageArgs.TakeProfitPrice.Value);
            }

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAmendPendingOrderRequest(AmendPendingOrderRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAAmendOrderReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            messageBuilder.SetOrderId(messageArgs.OrderId);
            
            if (messageArgs.Price.HasValue)
            {
                switch (messageArgs.OrderType)
                {
                    case ProtoOAOrderType.LIMIT:
                        messageBuilder.SetLimitPrice(messageArgs.Price.Value);
                        break;

                    case ProtoOAOrderType.STOP:
                    case ProtoOAOrderType.STOP_LIMIT:
                        messageBuilder.SetStopPrice(messageArgs.Price.Value);
                        break;
                }
            }

            if (messageArgs.ExpirationTime.HasValue)
            {
                messageBuilder.SetExpirationTimestamp(messageArgs.ExpirationTime.Value.ToUnixTimeMilliseconds());
            }

            if (messageArgs.StopLossPrice.HasValue)
            {
                messageBuilder.SetStopLoss(messageArgs.StopLossPrice.Value);
            }

            if (messageArgs.TakeProfitPrice.HasValue)
            {
                messageBuilder.SetTakeProfit(messageArgs.TakeProfitPrice.Value);
            }

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSubscribeForSpotsRequest(SpotsRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOASubscribeSpotsReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);

            messageBuilder.AddRangeSymbolId(messageArgs.SymbolIds);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateUnsubscribeFromSpotsRequest(SpotsRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAUnsubscribeSpotsReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);

            messageBuilder.AddRangeSymbolId(messageArgs.SymbolIds);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateTraderRequest(TraderRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOATraderReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateTraderUpdatedEvent(TraderUpdatedEventMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOATraderUpdatedEvent.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateCtidProfileRequest(CtidProfileRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAGetCtidProfileByTokenReq.CreateBuilder();

            messageBuilder.SetAccessToken(messageArgs.Token);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolByIdRequest(SymbolByIdRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOASymbolByIdReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);

            messageBuilder.AddRangeSymbolId(messageArgs.SymbolIds);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolsForConversionRequest(SymbolsForConversionRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOASymbolsForConversionReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            messageBuilder.SetFirstAssetId(messageArgs.FirstAssetId);
            messageBuilder.SetLastAssetId(messageArgs.LastAssetId);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolCategoryListRequest(SymbolCategoryListRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOASymbolCategoryListReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);
            
            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolChangedEvent(SymbolChangedEventMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOASymbolChangedEvent.CreateBuilder();
            
            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);

            messageBuilder.AddRangeSymbolId(messageArgs.SymbolIds);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateExpectedMarginRequest(ExpectedMarginRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAExpectedMarginReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);

            messageBuilder.SetSymbolId(messageArgs.SymbolId);

            messageBuilder.AddRangeVolume(messageArgs.Volumes);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSubscribeForLiveTrendbarRequest(LiveTrendbarRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOASubscribeLiveTrendbarReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);

            messageBuilder.SetSymbolId(messageArgs.SymbolId);

            messageBuilder.SetPeriod(messageArgs.Period);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateUnsubscribeForLiveTrendbarRequest(LiveTrendbarRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAUnsubscribeLiveTrendbarReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);

            messageBuilder.SetSymbolId(messageArgs.SymbolId);

            messageBuilder.SetPeriod(messageArgs.Period);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateSubscribeForDepthQuotesRequest(DepthQuotesRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOASubscribeDepthQuotesReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);

            messageBuilder.AddRangeSymbolId(messageArgs.SymbolIds);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateUnsubscribeForDepthQuotesRequest(DepthQuotesRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAUnsubscribeDepthQuotesReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);

            messageBuilder.AddRangeSymbolId(messageArgs.SymbolIds);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        public static ProtoMessage CreateAccountLogoutRequest(AccountLogoutRequestMessageArgs messageArgs)
        {
            var messageBuilder = ProtoOAAccountLogoutReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(messageArgs.AccountId);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), messageArgs.ClientMessageId);
        }

        #endregion Creating new Proto messages with parameters specified
    }
}