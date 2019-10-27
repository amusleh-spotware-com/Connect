using Connect.Protobuf.Models.Parameters;
using Connect.Protobuf.Models.Parameters.Abstractions;
using Google.ProtocolBuffers;
using System;

namespace Connect.Protobuf.Factories
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

        public static ProtoMessage CreateMessage(IParameters parameters)
        {
            switch (parameters.PayloadType)
            {
                case (int)ProtoPayloadType.PING_REQ:
                    return CreatePingRequest(parameters as PingRequestParameters);

                case (int)ProtoPayloadType.HEARTBEAT_EVENT:
                    return CreateHeartbeatEvent(parameters as HeartbeatEventParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_VERSION_REQ:
                    return CreateVersionRequest(parameters as VersionRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_APPLICATION_AUTH_REQ:
                    return CreateAppAuthorizationRequest(parameters as AppAuthorizationRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_ACCOUNT_AUTH_REQ:
                    return CreateAccountAuthorizationRequest(parameters as AccountAuthorizationRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_REQ:
                    return CreateAssetListRequest(parameters as AssetListRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_ASSET_CLASS_LIST_REQ:
                    return CreateAssetClassListRequest(parameters as AssetClassListRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_DEAL_LIST_REQ:
                    return CreateDealsListRequest(parameters as DealsListRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_CASH_FLOW_HISTORY_LIST_REQ:
                    return CreateCashflowHistoryRequest(parameters as CashflowHistoryRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_GET_ACCOUNTS_BY_ACCESS_TOKEN_REQ:
                    return CreateAccountListRequest(parameters as AccountListRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_LIST_REQ:
                    return CreateSymbolsListRequest(parameters as SymbolsListRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_GET_TRENDBARS_REQ:
                    return CreateTrendbarsRequest(parameters as TrendbarsRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_GET_TICKDATA_REQ:
                    return CreateTickDataRequest(parameters as TickDataRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_NEW_ORDER_REQ:
                    return CreateOrderRequest(parameters as OrderRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_CANCEL_ORDER_REQ:
                    return CreateCancelOrderRequest(parameters as CancelOrderRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_CLOSE_POSITION_REQ:
                    return CreateClosePositionRequest(parameters as ClosePositionRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_AMEND_ORDER_REQ:
                    return CreateAmendOrderRequest(parameters as AmendOrderRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_AMEND_POSITION_SLTP_REQ:
                    return CreateAmendPositionProtectionRequest(parameters as AmendPositionProtectionRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_SPOTS_REQ:
                    return CreateSubscribeForSpotsRequest(parameters as SpotsRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_SPOTS_REQ:
                    return CreateUnsubscribeFromSpotsRequest(parameters as SpotsRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_TRADER_REQ:
                    return CreateTraderRequest(parameters as TraderRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_TRADER_UPDATE_EVENT:
                    return CreateTraderUpdatedEvent(parameters as TraderUpdatedEventParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_GET_CTID_PROFILE_BY_TOKEN_REQ:
                    return CreateCtidProfileRequest(parameters as CtidProfileRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_BY_ID_REQ:
                    return CreateSymbolByIdRequest(parameters as SymbolByIdRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_FOR_CONVERSION_REQ:
                    return CreateSymbolsForConversionRequest(parameters as SymbolsForConversionRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_CATEGORY_REQ:
                    return CreateSymbolCategoryListRequest(parameters as SymbolCategoryListRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_CHANGED_EVENT:
                    return CreateSymbolChangedEvent(parameters as SymbolChangedEventParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_EXPECTED_MARGIN_REQ:
                    return CreateExpectedMarginRequest(parameters as ExpectedMarginRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_LIVE_TRENDBAR_REQ:
                    return CreateSubscribeForLiveTrendbarRequest(parameters as LiveTrendbarRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_LIVE_TRENDBAR_REQ:
                    return CreateUnsubscribeForLiveTrendbarRequest(parameters as LiveTrendbarRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_DEPTH_QUOTES_REQ:
                    return CreateSubscribeForDepthQuotesRequest(parameters as DepthQuotesRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_DEPTH_QUOTES_REQ:
                    return CreateUnsubscribeForDepthQuotesRequest(parameters as DepthQuotesRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_ACCOUNT_LOGOUT_REQ:
                    return CreateAccountLogoutRequest(parameters as AccountLogoutRequestParameters);

                case (int)ProtoOAPayloadType.PROTO_OA_RECONCILE_REQ:
                    return CreateReconcileRequest(parameters as ReconcileRequestParameters);

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

        public static ProtoMessage CreatePingRequest(PingRequestParameters parameters)
        {
            return CreateMessage((uint)ProtoPayloadType.PING_REQ,
                ProtoPingReq.CreateBuilder().SetTimestamp(parameters.Timestamp).Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateHeartbeatEvent(HeartbeatEventParameters parameters)
        {
            return CreateMessage((uint)ProtoPayloadType.HEARTBEAT_EVENT, ProtoHeartbeatEvent.CreateBuilder().Build().ToByteString(),
                parameters.ClientMessageId);
        }

        public static ProtoMessage CreateVersionRequest(VersionRequestParameters parameters)
        {
            var messageBuilder = ProtoOAVersionReq.CreateBuilder();

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateAppAuthorizationRequest(AppAuthorizationRequestParameters parameters)
        {
            var messageBuilder = ProtoOAApplicationAuthReq.CreateBuilder();

            messageBuilder.SetClientId(parameters.ClientId);

            messageBuilder.SetClientSecret(parameters.ClientSecret);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateAccountAuthorizationRequest(AccountAuthorizationRequestParameters parameters)
        {
            var messageBuilder = ProtoOAAccountAuthReq.CreateBuilder();

            messageBuilder.SetAccessToken(parameters.Token);

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateAssetListRequest(AssetListRequestParameters parameters)
        {
            var messageBuilder = ProtoOAAssetListReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_REQ, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateAssetClassListRequest(AssetClassListRequestParameters parameters)
        {
            var messageBuilder = ProtoOAAssetClassListReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            return CreateMessage((uint)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_REQ, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateDealsListRequest(DealsListRequestParameters parameters)
        {
            var messageBuilder = ProtoOADealListReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            messageBuilder.SetFromTimestamp(parameters.From.ToUnixTimeMilliseconds());

            messageBuilder.SetToTimestamp(parameters.To.ToUnixTimeMilliseconds());

            if (parameters.MaxRows.HasValue)
            {
                messageBuilder.SetMaxRows(parameters.MaxRows.Value);
            }

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateCashflowHistoryRequest(CashflowHistoryRequestParameters parameters)
        {
            var messageBuilder = ProtoOACashFlowHistoryListReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            messageBuilder.SetFromTimestamp(parameters.From.ToUnixTimeMilliseconds());

            messageBuilder.SetToTimestamp(parameters.To.ToUnixTimeMilliseconds());

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateAccountListRequest(AccountListRequestParameters parameters)
        {
            var messageBuilder = ProtoOAGetAccountListByAccessTokenReq.CreateBuilder();

            messageBuilder.SetAccessToken(parameters.Token);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolsListRequest(SymbolsListRequestParameters parameters)
        {
            var messageBuilder = ProtoOASymbolsListReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateTrendbarsRequest(TrendbarsRequestParameters parameters)
        {
            var messageBuilder = ProtoOAGetTrendbarsReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);
            messageBuilder.SetSymbolId(parameters.SymbolId);
            messageBuilder.SetFromTimestamp(parameters.From.ToUnixTimeMilliseconds());
            messageBuilder.SetToTimestamp(parameters.To.ToUnixTimeMilliseconds());
            messageBuilder.SetPeriod(parameters.Period);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateTickDataRequest(TickDataRequestParameters parameters)
        {
            var messageBuilder = ProtoOAGetTickDataReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);
            messageBuilder.SetSymbolId(parameters.SymbolId);
            messageBuilder.SetType(parameters.QuoteType);
            messageBuilder.SetFromTimestamp(parameters.From.ToUnixTimeMilliseconds());
            messageBuilder.SetToTimestamp(parameters.To.ToUnixTimeMilliseconds());

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateOrderRequest(OrderRequestParameters parameters)
        {
            var messageBuilder = ProtoOANewOrderReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);
            messageBuilder.SetSymbolId(parameters.SymbolId);
            messageBuilder.SetOrderType(parameters.OrderType);
            messageBuilder.SetTradeSide(parameters.TradeSide);
            messageBuilder.SetVolume(parameters.Volume);

            if (parameters.TimeInForce.HasValue)
            {
                messageBuilder.SetTimeInForce(parameters.TimeInForce.Value);
            }

            if (!string.IsNullOrEmpty(parameters.Comment))
            {
                messageBuilder.SetComment(parameters.Comment);
            }

            if (!string.IsNullOrEmpty(parameters.Label))
            {
                messageBuilder.SetLabel(parameters.Label);
            }

            if (parameters.GuaranteedStopLoss.HasValue)
            {
                messageBuilder.SetGuaranteedStopLoss(parameters.GuaranteedStopLoss.Value);
            }

            switch (parameters.OrderType)
            {
                case ProtoOAOrderType.MARKET:
                case ProtoOAOrderType.MARKET_RANGE:
                    MarketOrderRequestParameters marketOrderParameters = parameters as MarketOrderRequestParameters;

                    if (marketOrderParameters.RelativeStopLoss.HasValue)
                    {
                        messageBuilder.SetRelativeStopLoss(marketOrderParameters.RelativeStopLoss.Value);

                        if (marketOrderParameters.TrailingStopLoss.HasValue)
                        {
                            messageBuilder.SetTrailingStopLoss(marketOrderParameters.TrailingStopLoss.Value);
                        }
                    }

                    if (marketOrderParameters.RelativeTakeProfit.HasValue)
                    {
                        messageBuilder.SetRelativeTakeProfit(marketOrderParameters.RelativeTakeProfit.Value);
                    }

                    if (marketOrderParameters.PositionId.HasValue)
                    {
                        messageBuilder.SetPositionId(marketOrderParameters.PositionId.Value);
                    }

                    if (marketOrderParameters.OrderType == ProtoOAOrderType.MARKET_RANGE)
                    {
                        MarketRangeOrderRequestParameters marketRangeOrderParameters = parameters as MarketRangeOrderRequestParameters;

                        messageBuilder.SetBaseSlippagePrice(marketRangeOrderParameters.BaseSlippagePrice);
                        messageBuilder.SetSlippageInPoints(marketRangeOrderParameters.SlippageInPoints);
                    }

                    break;

                case ProtoOAOrderType.LIMIT:
                case ProtoOAOrderType.STOP:
                case ProtoOAOrderType.STOP_LIMIT:
                    PendingOrderRequestParameters pendingOrderParameters = parameters as PendingOrderRequestParameters;

                    if (pendingOrderParameters.ExpirationTime.HasValue)
                    {
                        messageBuilder.SetExpirationTimestamp(pendingOrderParameters.ExpirationTime.Value.ToUnixTimeMilliseconds());
                    }

                    if (pendingOrderParameters.StopLossInPrice.HasValue)
                    {
                        messageBuilder.SetStopLoss(pendingOrderParameters.StopLossInPrice.Value);

                        if (pendingOrderParameters.TrailingStopLoss.HasValue)
                        {
                            messageBuilder.SetTrailingStopLoss(pendingOrderParameters.TrailingStopLoss.Value);
                        }
                    }

                    if (pendingOrderParameters.TakeProfitInPrice.HasValue)
                    {
                        messageBuilder.SetTakeProfit(pendingOrderParameters.TakeProfitInPrice.Value);
                    }

                    if (pendingOrderParameters.OrderType == ProtoOAOrderType.LIMIT)
                    {
                        messageBuilder.SetLimitPrice(pendingOrderParameters.Price);
                    }
                    else
                    {
                        messageBuilder.SetStopPrice(pendingOrderParameters.Price);

                        if (pendingOrderParameters.StopTriggerMethod.HasValue)
                        {
                            messageBuilder.SetStopTriggerMethod(pendingOrderParameters.StopTriggerMethod.Value);
                        }

                        if (pendingOrderParameters.OrderType == ProtoOAOrderType.STOP_LIMIT)
                        {
                            StopLimitOrderRequestParameters stopLimitOrderParameters = pendingOrderParameters as StopLimitOrderRequestParameters;

                            messageBuilder.SetSlippageInPoints(stopLimitOrderParameters.SlippageInPoints);
                        }
                    }

                    break;
            }

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateCancelOrderRequest(CancelOrderRequestParameters parameters)
        {
            var messageBuilder = ProtoOACancelOrderReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);
            messageBuilder.SetOrderId(parameters.OrderId);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateClosePositionRequest(ClosePositionRequestParameters parameters)
        {
            var messageBuilder = ProtoOAClosePositionReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);
            messageBuilder.SetPositionId(parameters.PositionId);
            messageBuilder.SetVolume(parameters.Volume);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateAmendPositionProtectionRequest(AmendPositionProtectionRequestParameters parameters)
        {
            var messageBuilder = ProtoOAAmendPositionSLTPReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);
            messageBuilder.SetPositionId(parameters.PositionId);

            if (parameters.StopLossPrice.HasValue)
            {
                messageBuilder.SetStopLoss(parameters.StopLossPrice.Value);

                if (parameters.TrailingStopLoss.HasValue)
                {
                    messageBuilder.SetTrailingStopLoss(parameters.TrailingStopLoss.Value);
                }

                if (parameters.StopLossTriggerMethod.HasValue)
                {
                    messageBuilder.SetStopLossTriggerMethod(parameters.StopLossTriggerMethod.Value);
                }
            }

            if (parameters.TakeProfitPrice.HasValue)
            {
                messageBuilder.SetTakeProfit(parameters.TakeProfitPrice.Value);
            }

            if (parameters.GuaranteedStopLoss.HasValue)
            {
                messageBuilder.SetGuaranteedStopLoss(parameters.GuaranteedStopLoss.Value);
            }

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateAmendOrderRequest(AmendOrderRequestParameters parameters)
        {
            var messageBuilder = ProtoOAAmendOrderReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);
            messageBuilder.SetOrderId(parameters.OrderId);

            if (parameters.Volume.HasValue)
            {
                messageBuilder.SetVolume(parameters.Volume.Value);
            }

            switch (parameters.OrderType)
            {
                case ProtoOAOrderType.LIMIT:
                    if (parameters.Price.HasValue)
                    {
                        messageBuilder.SetLimitPrice(parameters.Price.Value);
                    }
                    break;

                case ProtoOAOrderType.STOP:
                case ProtoOAOrderType.STOP_LIMIT:
                    if (parameters.Price.HasValue)
                    {
                        messageBuilder.SetStopPrice(parameters.Price.Value);
                    }

                    if (parameters.StopTriggerMethod.HasValue)
                    {
                        messageBuilder.SetStopTriggerMethod(parameters.StopTriggerMethod.Value);
                    }

                    if (parameters.OrderType == ProtoOAOrderType.STOP_LIMIT && parameters.SlippageInPoints.HasValue)
                    {
                        messageBuilder.SetSlippageInPoints(parameters.SlippageInPoints.Value);
                    }
                    break;
            }

            if (parameters.ExpirationTime.HasValue)
            {
                messageBuilder.SetExpirationTimestamp(parameters.ExpirationTime.Value.ToUnixTimeMilliseconds());
            }

            if (parameters.StopLossPrice.HasValue)
            {
                messageBuilder.SetStopLoss(parameters.StopLossPrice.Value);

                if (parameters.TrailingStopLoss.HasValue)
                {
                    messageBuilder.SetTrailingStopLoss(parameters.TrailingStopLoss.Value);
                }
            }

            if (parameters.TakeProfitPrice.HasValue)
            {
                messageBuilder.SetTakeProfit(parameters.TakeProfitPrice.Value);
            }

            if (parameters.GuaranteedStopLoss.HasValue)
            {
                messageBuilder.SetGuaranteedStopLoss(parameters.GuaranteedStopLoss.Value);
            }

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateSubscribeForSpotsRequest(SpotsRequestParameters parameters)
        {
            var messageBuilder = ProtoOASubscribeSpotsReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            messageBuilder.AddRangeSymbolId(parameters.SymbolIds);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateUnsubscribeFromSpotsRequest(SpotsRequestParameters parameters)
        {
            var messageBuilder = ProtoOAUnsubscribeSpotsReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            messageBuilder.AddRangeSymbolId(parameters.SymbolIds);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateTraderRequest(TraderRequestParameters parameters)
        {
            var messageBuilder = ProtoOATraderReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateTraderUpdatedEvent(TraderUpdatedEventParameters parameters)
        {
            var messageBuilder = ProtoOATraderUpdatedEvent.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateCtidProfileRequest(CtidProfileRequestParameters parameters)
        {
            var messageBuilder = ProtoOAGetCtidProfileByTokenReq.CreateBuilder();

            messageBuilder.SetAccessToken(parameters.Token);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolByIdRequest(SymbolByIdRequestParameters parameters)
        {
            var messageBuilder = ProtoOASymbolByIdReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            messageBuilder.AddRangeSymbolId(parameters.SymbolIds);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolsForConversionRequest(SymbolsForConversionRequestParameters parameters)
        {
            var messageBuilder = ProtoOASymbolsForConversionReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);
            messageBuilder.SetFirstAssetId(parameters.FirstAssetId);
            messageBuilder.SetLastAssetId(parameters.LastAssetId);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolCategoryListRequest(SymbolCategoryListRequestParameters parameters)
        {
            var messageBuilder = ProtoOASymbolCategoryListReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateSymbolChangedEvent(SymbolChangedEventParameters parameters)
        {
            var messageBuilder = ProtoOASymbolChangedEvent.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            messageBuilder.AddRangeSymbolId(parameters.SymbolIds);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateExpectedMarginRequest(ExpectedMarginRequestParameters parameters)
        {
            var messageBuilder = ProtoOAExpectedMarginReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            messageBuilder.SetSymbolId(parameters.SymbolId);

            messageBuilder.AddRangeVolume(parameters.Volumes);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateSubscribeForLiveTrendbarRequest(LiveTrendbarRequestParameters parameters)
        {
            var messageBuilder = ProtoOASubscribeLiveTrendbarReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            messageBuilder.SetSymbolId(parameters.SymbolId);

            messageBuilder.SetPeriod(parameters.Period);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateUnsubscribeForLiveTrendbarRequest(LiveTrendbarRequestParameters parameters)
        {
            var messageBuilder = ProtoOAUnsubscribeLiveTrendbarReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            messageBuilder.SetSymbolId(parameters.SymbolId);

            messageBuilder.SetPeriod(parameters.Period);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateSubscribeForDepthQuotesRequest(DepthQuotesRequestParameters parameters)
        {
            var messageBuilder = ProtoOASubscribeDepthQuotesReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            messageBuilder.AddRangeSymbolId(parameters.SymbolIds);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateUnsubscribeForDepthQuotesRequest(DepthQuotesRequestParameters parameters)
        {
            var messageBuilder = ProtoOAUnsubscribeDepthQuotesReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            messageBuilder.AddRangeSymbolId(parameters.SymbolIds);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateAccountLogoutRequest(AccountLogoutRequestParameters parameters)
        {
            var messageBuilder = ProtoOAAccountLogoutReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        public static ProtoMessage CreateReconcileRequest(ReconcileRequestParameters parameters)
        {
            var messageBuilder = ProtoOAReconcileReq.CreateBuilder();

            messageBuilder.SetCtidTraderAccountId(parameters.AccountId);

            return CreateMessage((uint)messageBuilder.PayloadType, messageBuilder.Build().ToByteString(), parameters.ClientMessageId);
        }

        #endregion Creating new Proto messages with parameters specified
    }
}