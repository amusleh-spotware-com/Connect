using System;

namespace Connect.Protobuf.Helpers
{
    public class StreamsContainer
    {
        public StreamsContainer()
        {
            SpotStream = new ObservableStream<ProtoOASpotEvent>();

            HeartbeatStream = new ObservableStream<ProtoHeartbeatEvent>();

            ExecutionStream = new ObservableStream<ProtoOAExecutionEvent>();

            MessageStream = new ObservableStream<ProtoMessage>();

            DepthQuotesStream = new ObservableStream<ProtoOADepthEvent>();

            TrailingSLChangedStream = new ObservableStream<ProtoOATrailingSLChangedEvent>();

            TraderUpdateStream = new ObservableStream<ProtoOATraderUpdatedEvent>();

            OrderErrorStream = new ObservableStream<ProtoOAOrderErrorEvent>();

            MarginChangeStream = new ObservableStream<ProtoOAMarginChangedEvent>();

            TokenInvalidatedStream = new ObservableStream<ProtoOAAccountsTokenInvalidatedEvent>();

            ClientDisconnectedStream = new ObservableStream<ProtoOAClientDisconnectEvent>();

            ErrorStream = new ObservableStream<ProtoOAErrorRes>();

            SymbolChangedStream = new ObservableStream<ProtoOASymbolChangedEvent>();

            ApplicationAuthResponseStream = new ObservableStream<StreamMessage<ProtoOAApplicationAuthRes>>();

            AccountAuthorizationResponseStream = new ObservableStream<StreamMessage<ProtoOAAccountAuthRes>>();

            DealListResponseStream = new ObservableStream<StreamMessage<ProtoOADealListRes>>();

            AssetListResponseStream = new ObservableStream<StreamMessage<ProtoOAAssetListRes>>();

            AssetClassListResponseStream = new ObservableStream<StreamMessage<ProtoOAAssetClassListRes>>();

            CashFlowHistoryListResponseStream = new ObservableStream<StreamMessage<ProtoOACashFlowHistoryListRes>>();

            ExpectedMarginResponseStream = new ObservableStream<StreamMessage<ProtoOAExpectedMarginRes>>();

            AccountListResponseStream = new ObservableStream<StreamMessage<ProtoOAGetAccountListByAccessTokenRes>>();

            TickDataResponseStream = new ObservableStream<StreamMessage<ProtoOAGetTickDataRes>>();

            TrendbarsResponseStream = new ObservableStream<StreamMessage<ProtoOAGetTrendbarsRes>>();

            ReconcileResponseStream = new ObservableStream<StreamMessage<ProtoOAReconcileRes>>();

            SubscribeSpotsResponseStream = new ObservableStream<StreamMessage<ProtoOASubscribeSpotsRes>>();

            SubscribeDepthQuotesResponseStream = new ObservableStream<StreamMessage<ProtoOASubscribeDepthQuotesRes>>();

            SymbolsForConversionResponseStream = new ObservableStream<StreamMessage<ProtoOASymbolsForConversionRes>>();

            SymbolsListResponseStream = new ObservableStream<StreamMessage<ProtoOASymbolsListRes>>();

            SymbolByIdResponseStream = new ObservableStream<StreamMessage<ProtoOASymbolByIdRes>>();

            TraderResponseStream = new ObservableStream<StreamMessage<ProtoOATraderRes>>();

            UnsubscribeSpotsResponseStream = new ObservableStream<StreamMessage<ProtoOAUnsubscribeSpotsRes>>();

            UnsubscribeDepthQuotesResponseStream = new ObservableStream<StreamMessage<ProtoOAUnsubscribeDepthQuotesRes>>();

            VersionResponseStream = new ObservableStream<StreamMessage<ProtoOAVersionRes>>();

            CtidProfileResponseStream = new ObservableStream<StreamMessage<ProtoOAGetCtidProfileByTokenRes>>();

            SymbolCategoryListResponseStream = new ObservableStream<StreamMessage<ProtoOASymbolCategoryListRes>>();

            AccountLogoutResponseStream = new ObservableStream<StreamMessage<ProtoOAAccountLogoutRes>>();

            ListenerExceptionStream = new ObservableStream<Exception>();

            SenderExceptionStream = new ObservableStream<Exception>();

            HeartbeatSendingExceptionStream = new ObservableStream<Exception>();
        }

        #region Streams

        public ObservableStream<ProtoOASpotEvent> SpotStream { get; }

        public ObservableStream<ProtoHeartbeatEvent> HeartbeatStream { get; }

        public ObservableStream<ProtoOAExecutionEvent> ExecutionStream { get; }

        public ObservableStream<ProtoMessage> MessageStream { get; }

        public ObservableStream<ProtoOADepthEvent> DepthQuotesStream { get; }

        public ObservableStream<ProtoOATrailingSLChangedEvent> TrailingSLChangedStream { get; }

        public ObservableStream<ProtoOATraderUpdatedEvent> TraderUpdateStream { get; }

        public ObservableStream<ProtoOAOrderErrorEvent> OrderErrorStream { get; }

        public ObservableStream<ProtoOAMarginChangedEvent> MarginChangeStream { get; }

        public ObservableStream<ProtoOAAccountsTokenInvalidatedEvent> TokenInvalidatedStream { get; }

        public ObservableStream<ProtoOAClientDisconnectEvent> ClientDisconnectedStream { get; }

        public ObservableStream<ProtoOAErrorRes> ErrorStream { get; }

        public ObservableStream<ProtoOASymbolChangedEvent> SymbolChangedStream { get; }

        public ObservableStream<StreamMessage<ProtoOAApplicationAuthRes>> ApplicationAuthResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOAAccountAuthRes>> AccountAuthorizationResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOADealListRes>> DealListResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOAAssetListRes>> AssetListResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOAAssetClassListRes>> AssetClassListResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOACashFlowHistoryListRes>> CashFlowHistoryListResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOAExpectedMarginRes>> ExpectedMarginResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOAGetAccountListByAccessTokenRes>> AccountListResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOAGetTickDataRes>> TickDataResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOAGetTrendbarsRes>> TrendbarsResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOAReconcileRes>> ReconcileResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOASubscribeSpotsRes>> SubscribeSpotsResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOASubscribeDepthQuotesRes>> SubscribeDepthQuotesResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOASymbolsForConversionRes>> SymbolsForConversionResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOASymbolsListRes>> SymbolsListResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOASymbolByIdRes>> SymbolByIdResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOATraderRes>> TraderResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOAUnsubscribeSpotsRes>> UnsubscribeSpotsResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOAUnsubscribeDepthQuotesRes>> UnsubscribeDepthQuotesResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOAVersionRes>> VersionResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOAGetCtidProfileByTokenRes>> CtidProfileResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOASymbolCategoryListRes>> SymbolCategoryListResponseStream { get; }

        public ObservableStream<StreamMessage<ProtoOAAccountLogoutRes>> AccountLogoutResponseStream { get; }

        public ObservableStream<Exception> ListenerExceptionStream { get; }

        public ObservableStream<Exception> SenderExceptionStream { get; }

        public ObservableStream<Exception> HeartbeatSendingExceptionStream { get; }

        #endregion Streams

        #region Streams incoming data handling methods

        internal void OnApplicationAuthResponse(ProtoOAApplicationAuthRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAApplicationAuthRes>(e, clientMsgId);

            ApplicationAuthResponseStream.OnNext(streamMessage);
        }

        internal void OnSubscribeDepthQuotesResponse(ProtoOASubscribeDepthQuotesRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOASubscribeDepthQuotesRes>(e, clientMsgId);

            SubscribeDepthQuotesResponseStream.OnNext(streamMessage);
        }

        internal void OnUnsubscribeDepthQuotesResponse(ProtoOAUnsubscribeDepthQuotesRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAUnsubscribeDepthQuotesRes>(e, clientMsgId);

            UnsubscribeDepthQuotesResponseStream.OnNext(streamMessage);
        }

        internal void OnAccountAuthorizationResponse(ProtoOAAccountAuthRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAAccountAuthRes>(e, clientMsgId);

            AccountAuthorizationResponseStream.OnNext(streamMessage);
        }

        internal void OnDealListResponse(ProtoOADealListRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOADealListRes>(e, clientMsgId);

            DealListResponseStream.OnNext(streamMessage);
        }

        internal void OnAssetListResponse(ProtoOAAssetListRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAAssetListRes>(e, clientMsgId);

            AssetListResponseStream.OnNext(streamMessage);
        }

        internal void OnAssetClassListResponse(ProtoOAAssetClassListRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAAssetClassListRes>(e, clientMsgId);

            AssetClassListResponseStream.OnNext(streamMessage);
        }

        internal void OnCashFlowHistoryListResponse(ProtoOACashFlowHistoryListRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOACashFlowHistoryListRes>(e, clientMsgId);

            CashFlowHistoryListResponseStream.OnNext(streamMessage);
        }

        internal void OnExpectedMarginResponse(ProtoOAExpectedMarginRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAExpectedMarginRes>(e, clientMsgId);

            ExpectedMarginResponseStream.OnNext(streamMessage);
        }

        internal void OnAccountListResponse(ProtoOAGetAccountListByAccessTokenRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAGetAccountListByAccessTokenRes>(e, clientMsgId);

            AccountListResponseStream.OnNext(streamMessage);
        }

        internal void OnTickDataResponse(ProtoOAGetTickDataRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAGetTickDataRes>(e, clientMsgId);

            TickDataResponseStream.OnNext(streamMessage);
        }

        internal void OnTrendbarsResponse(ProtoOAGetTrendbarsRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAGetTrendbarsRes>(e, clientMsgId);

            TrendbarsResponseStream.OnNext(streamMessage);
        }

        internal void OnReconcileResponse(ProtoOAReconcileRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAReconcileRes>(e, clientMsgId);

            ReconcileResponseStream.OnNext(streamMessage);
        }

        internal void OnSubscribeSpotsResponse(ProtoOASubscribeSpotsRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOASubscribeSpotsRes>(e, clientMsgId);

            SubscribeSpotsResponseStream.OnNext(streamMessage);
        }

        internal void OnSymbolsForConversionResponse(ProtoOASymbolsForConversionRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOASymbolsForConversionRes>(e, clientMsgId);

            SymbolsForConversionResponseStream.OnNext(streamMessage);
        }

        internal void OnSymbolsListResponse(ProtoOASymbolsListRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOASymbolsListRes>(e, clientMsgId);

            SymbolsListResponseStream.OnNext(streamMessage);
        }

        internal void OnSymbolByIdResponse(ProtoOASymbolByIdRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOASymbolByIdRes>(e, clientMsgId);

            SymbolByIdResponseStream.OnNext(streamMessage);
        }

        internal void OnTraderResponse(ProtoOATraderRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOATraderRes>(e, clientMsgId);

            TraderResponseStream.OnNext(streamMessage);
        }

        internal void OnUnsubscribeSpotsResponse(ProtoOAUnsubscribeSpotsRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAUnsubscribeSpotsRes>(e, clientMsgId);

            UnsubscribeSpotsResponseStream.OnNext(streamMessage);
        }

        internal void OnVersionResponse(ProtoOAVersionRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAVersionRes>(e, clientMsgId);

            VersionResponseStream.OnNext(streamMessage);
        }

        internal void OnCtidProfileResponse(ProtoOAGetCtidProfileByTokenRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAGetCtidProfileByTokenRes>(e, clientMsgId);

            CtidProfileResponseStream.OnNext(streamMessage);
        }

        internal void OnSymbolCategoryListResponse(ProtoOASymbolCategoryListRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOASymbolCategoryListRes>(e, clientMsgId);

            SymbolCategoryListResponseStream.OnNext(streamMessage);
        }

        internal void OnAccountLogoutResponse(ProtoOAAccountLogoutRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAAccountLogoutRes>(e, clientMsgId);

            AccountLogoutResponseStream.OnNext(streamMessage);
        }

        internal void InvokeMessageStream(byte[] data)
        {
            var protoMessage = ProtoMessage.Parser.ParseFrom(data);

            var payload = protoMessage.Payload;

            MessageStream.OnNext(protoMessage);

            switch (protoMessage.PayloadType)
            {
                case (int)ProtoOAPayloadType.ProtoOaErrorRes:
                    {
                        var protoErrorRes = ProtoOAErrorRes.Parser.ParseFrom(payload);

                        ErrorStream.OnNext(protoErrorRes);

                        break;
                    }
                case (int)ProtoPayloadType.HeartbeatEvent:
                    {
                        var protoHeartbeatEvent = ProtoHeartbeatEvent.Parser.ParseFrom(payload);

                        HeartbeatStream.OnNext(protoHeartbeatEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAccountAuthRes:
                    {
                        var protoOAAccountAuthRes = ProtoOAAccountAuthRes.Parser.ParseFrom(payload);

                        OnAccountAuthorizationResponse(protoOAAccountAuthRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaApplicationAuthRes:
                    {
                        var protoOAApplicationAuthRes = ProtoOAApplicationAuthRes.Parser.ParseFrom(payload);

                        OnApplicationAuthResponse(protoOAApplicationAuthRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaClientDisconnectEvent:
                    {
                        var protoOAClientDisconnect = ProtoOAClientDisconnectEvent.Parser.ParseFrom(payload);

                        ClientDisconnectedStream.OnNext(protoOAClientDisconnect);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaDealListRes:
                    {
                        var protoOADealListRes = ProtoOADealListRes.Parser.ParseFrom(payload);

                        OnDealListResponse(protoOADealListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAssetListRes:
                    {
                        var protoOAAssetListRes = ProtoOAAssetListRes.Parser.ParseFrom(payload);

                        OnAssetListResponse(protoOAAssetListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAssetClassListRes:
                    {
                        var protoOAAssetClassListRes = ProtoOAAssetClassListRes.Parser.ParseFrom(payload);

                        OnAssetClassListResponse(protoOAAssetClassListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAccountsTokenInvalidatedEvent:
                    {
                        var protoOAAccountsTokenInvalidatedEvent = ProtoOAAccountsTokenInvalidatedEvent.Parser.ParseFrom(payload);

                        TokenInvalidatedStream.OnNext(protoOAAccountsTokenInvalidatedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaCashFlowHistoryListRes:
                    {
                        var protoOACashFlowHistoryListRes = ProtoOACashFlowHistoryListRes.Parser.ParseFrom(payload);

                        OnCashFlowHistoryListResponse(protoOACashFlowHistoryListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaExecutionEvent:
                    {
                        var protoOAExecutionEvent = ProtoOAExecutionEvent.Parser.ParseFrom(payload);

                        ExecutionStream.OnNext(protoOAExecutionEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaExpectedMarginRes:
                    {
                        var protoOAExpectedMarginRes = ProtoOAExpectedMarginRes.Parser.ParseFrom(payload);

                        OnExpectedMarginResponse(protoOAExpectedMarginRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaGetAccountsByAccessTokenRes:
                    {
                        var protoOAGetAccountListByAccessTokenRes = ProtoOAGetAccountListByAccessTokenRes.Parser.ParseFrom(
                            payload);

                        OnAccountListResponse(protoOAGetAccountListByAccessTokenRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaGetTickdataRes:
                    {
                        var protoOAGetTickDataRes = ProtoOAGetTickDataRes.Parser.ParseFrom(payload);

                        OnTickDataResponse(protoOAGetTickDataRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaGetTrendbarsRes:
                    {
                        var protoOAGetTrendbarsRes = ProtoOAGetTrendbarsRes.Parser.ParseFrom(payload);

                        OnTrendbarsResponse(protoOAGetTrendbarsRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaMarginChangedEvent:
                    {
                        var protoOAMarginChangedEvent = ProtoOAMarginChangedEvent.Parser.ParseFrom(payload);

                        MarginChangeStream.OnNext(protoOAMarginChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaOrderErrorEvent:
                    {
                        var protoOAOrderErrorEvent = ProtoOAOrderErrorEvent.Parser.ParseFrom(payload);

                        OrderErrorStream.OnNext(protoOAOrderErrorEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaReconcileRes:
                    {
                        var protoOAReconcileRes = ProtoOAReconcileRes.Parser.ParseFrom(payload);

                        OnReconcileResponse(protoOAReconcileRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSpotEvent:
                    {
                        var protoOASpotEvent = ProtoOASpotEvent.Parser.ParseFrom(payload);

                        SpotStream.OnNext(protoOASpotEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSubscribeSpotsRes:
                    {
                        var protoOASubscribeSpotsRes = ProtoOASubscribeSpotsRes.Parser.ParseFrom(payload);

                        OnSubscribeSpotsResponse(protoOASubscribeSpotsRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolsForConversionRes:
                    {
                        var protoOASymbolsForConversionRes = ProtoOASymbolsForConversionRes.Parser.ParseFrom(payload);

                        OnSymbolsForConversionResponse(protoOASymbolsForConversionRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolsListRes:
                    {
                        var protoOASymbolsListRes = ProtoOASymbolsListRes.Parser.ParseFrom(payload);

                        OnSymbolsListResponse(protoOASymbolsListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolByIdRes:
                    {
                        var protoOASymbolByIdRes = ProtoOASymbolByIdRes.Parser.ParseFrom(payload);

                        OnSymbolByIdResponse(protoOASymbolByIdRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolChangedEvent:
                    {
                        var protoOASymbolChangedEvent = ProtoOASymbolChangedEvent.Parser.ParseFrom(payload);

                        SymbolChangedStream.OnNext(protoOASymbolChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaTraderRes:
                    {
                        var protoOATraderRes = ProtoOATraderRes.Parser.ParseFrom(payload);

                        OnTraderResponse(protoOATraderRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaTraderUpdateEvent:
                    {
                        var protoOATraderUpdatedEvent = ProtoOATraderUpdatedEvent.Parser.ParseFrom(payload);

                        TraderUpdateStream.OnNext(protoOATraderUpdatedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaTrailingSlChangedEvent:
                    {
                        var protoOATrailingSLChangedEvent = ProtoOATrailingSLChangedEvent.Parser.ParseFrom(payload);

                        TrailingSLChangedStream.OnNext(protoOATrailingSLChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaUnsubscribeSpotsRes:
                    {
                        var protoOAUnsubscribeSpotsRes = ProtoOAUnsubscribeSpotsRes.Parser.ParseFrom(payload);

                        OnUnsubscribeSpotsResponse(protoOAUnsubscribeSpotsRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaVersionRes:
                    {
                        var protoOAVersionRes = ProtoOAVersionRes.Parser.ParseFrom(payload);

                        OnVersionResponse(protoOAVersionRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaGetCtidProfileByTokenRes:
                    {
                        var ctidProfileRes = ProtoOAGetCtidProfileByTokenRes.Parser.ParseFrom(payload);

                        OnCtidProfileResponse(ctidProfileRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolCategoryRes:
                    {
                        var symbolCategoryListRes = ProtoOASymbolCategoryListRes.Parser.ParseFrom(payload);

                        OnSymbolCategoryListResponse(symbolCategoryListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaDepthEvent:
                    {
                        var depthEvent = ProtoOADepthEvent.Parser.ParseFrom(payload);

                        DepthQuotesStream.OnNext(depthEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSubscribeDepthQuotesRes:
                    {
                        var subscribeDepthQuotesRes = ProtoOASubscribeDepthQuotesRes.Parser.ParseFrom(payload);

                        OnSubscribeDepthQuotesResponse(subscribeDepthQuotesRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaUnsubscribeDepthQuotesRes:
                    {
                        var unsubscribeDepthQuotesRes = ProtoOAUnsubscribeDepthQuotesRes.Parser.ParseFrom(payload);

                        OnUnsubscribeDepthQuotesResponse(unsubscribeDepthQuotesRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAccountLogoutRes:
                    {
                        var accountLogoutRes = ProtoOAAccountLogoutRes.Parser.ParseFrom(payload);

                        OnAccountLogoutResponse(accountLogoutRes, protoMessage.ClientMsgId);

                        break;
                    }
                default:
                    break;
            }
        }

        #endregion Streams incoming data handling methods
    }
}