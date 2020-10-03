using System;
using System.IO;

namespace Connect.Protobuf.Streams
{
    public class StreamsContainer
    {
        #region Fields

        private readonly ObservableStream<ProtoOASpotEvent> _spotStream;

        private readonly ObservableStream<ProtoHeartbeatEvent> _heartbeatStream;

        private readonly ObservableStream<ProtoOAExecutionEvent> _executionStream;

        private readonly ObservableStream<ProtoMessage> _messageStream;

        private readonly ObservableStream<ProtoOADepthEvent> _depthQuotesStream;

        private readonly ObservableStream<ProtoOATrailingSLChangedEvent> _trailingSLChangedStream;

        private readonly ObservableStream<ProtoOATraderUpdatedEvent> _traderUpdateStream;

        private readonly ObservableStream<ProtoOAOrderErrorEvent> _orderErrorStream;

        private readonly ObservableStream<ProtoOAMarginChangedEvent> _marginChangeStream;

        private readonly ObservableStream<ProtoOAAccountsTokenInvalidatedEvent> _tokenInvalidatedStream;

        private readonly ObservableStream<ProtoOAClientDisconnectEvent> _clientDisconnectedStream;

        private readonly ObservableStream<ProtoOAErrorRes> _errorStream;

        private readonly ObservableStream<ProtoOASymbolChangedEvent> _symbolChangedStream;

        private readonly ObservableStream<StreamMessage<ProtoOAApplicationAuthRes>> _applicationAuthResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAAccountAuthRes>> _accountAuthorizationResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOADealListRes>> _dealListResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAAssetListRes>> _assetListResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAAssetClassListRes>> _assetClassListResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOACashFlowHistoryListRes>> _cashFlowHistoryListResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAExpectedMarginRes>> _expectedMarginResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAGetAccountListByAccessTokenRes>> _accountListResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAGetTickDataRes>> _tickDataResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAGetTrendbarsRes>> _trendbarsResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAReconcileRes>> _reconcileResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOASubscribeSpotsRes>> _subscribeSpotsResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOASubscribeDepthQuotesRes>> _subscribeDepthQuotesResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOASymbolsForConversionRes>> _symbolsForConversionResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOASymbolsListRes>> _symbolsListResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOASymbolByIdRes>> _symbolByIdResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOATraderRes>> _traderResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAUnsubscribeSpotsRes>> _unsubscribeSpotsResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAUnsubscribeDepthQuotesRes>> _unsubscribeDepthQuotesResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAVersionRes>> _versionResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAGetCtidProfileByTokenRes>> _ctidProfileResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOASymbolCategoryListRes>> _symbolCategoryListResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAAccountLogoutRes>> _accountLogoutResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOARefreshTokenRes>> _refreshTokenResponseStream;

        private readonly ObservableStream<ProtoOAAccountDisconnectEvent> _accountDisconnectEventStream;

        private readonly ObservableStream<StreamMessage<ProtoOAMarginCallListRes>> _marginCallListResponseStream;

        private readonly ObservableStream<StreamMessage<ProtoOAMarginCallUpdateRes>> _marginCallUpdateResponseStream;

        private readonly ObservableStream<ProtoOAMarginCallUpdateEvent> _marginCallUpdateEventStream;

        private readonly ObservableStream<ProtoOAMarginCallTriggerEvent> _marginCallTriggerEventStream;

        private readonly ObservableStream<Exception> _listenerExceptionStream;

        private readonly ObservableStream<Exception> _senderExceptionStream;

        private readonly ObservableStream<Exception> _heartbeatSendingExceptionStream;

        #endregion Fields

        public StreamsContainer()
        {
            _spotStream = new ObservableStream<ProtoOASpotEvent>();

            _heartbeatStream = new ObservableStream<ProtoHeartbeatEvent>();

            _executionStream = new ObservableStream<ProtoOAExecutionEvent>();

            _messageStream = new ObservableStream<ProtoMessage>();

            _depthQuotesStream = new ObservableStream<ProtoOADepthEvent>();

            _trailingSLChangedStream = new ObservableStream<ProtoOATrailingSLChangedEvent>();

            _traderUpdateStream = new ObservableStream<ProtoOATraderUpdatedEvent>();

            _orderErrorStream = new ObservableStream<ProtoOAOrderErrorEvent>();

            _marginChangeStream = new ObservableStream<ProtoOAMarginChangedEvent>();

            _tokenInvalidatedStream = new ObservableStream<ProtoOAAccountsTokenInvalidatedEvent>();

            _clientDisconnectedStream = new ObservableStream<ProtoOAClientDisconnectEvent>();

            _errorStream = new ObservableStream<ProtoOAErrorRes>();

            _symbolChangedStream = new ObservableStream<ProtoOASymbolChangedEvent>();

            _applicationAuthResponseStream = new ObservableStream<StreamMessage<ProtoOAApplicationAuthRes>>();

            _accountAuthorizationResponseStream = new ObservableStream<StreamMessage<ProtoOAAccountAuthRes>>();

            _dealListResponseStream = new ObservableStream<StreamMessage<ProtoOADealListRes>>();

            _assetListResponseStream = new ObservableStream<StreamMessage<ProtoOAAssetListRes>>();

            _assetClassListResponseStream = new ObservableStream<StreamMessage<ProtoOAAssetClassListRes>>();

            _cashFlowHistoryListResponseStream = new ObservableStream<StreamMessage<ProtoOACashFlowHistoryListRes>>();

            _expectedMarginResponseStream = new ObservableStream<StreamMessage<ProtoOAExpectedMarginRes>>();

            _accountListResponseStream = new ObservableStream<StreamMessage<ProtoOAGetAccountListByAccessTokenRes>>();

            _tickDataResponseStream = new ObservableStream<StreamMessage<ProtoOAGetTickDataRes>>();

            _trendbarsResponseStream = new ObservableStream<StreamMessage<ProtoOAGetTrendbarsRes>>();

            _reconcileResponseStream = new ObservableStream<StreamMessage<ProtoOAReconcileRes>>();

            _subscribeSpotsResponseStream = new ObservableStream<StreamMessage<ProtoOASubscribeSpotsRes>>();

            _subscribeDepthQuotesResponseStream = new ObservableStream<StreamMessage<ProtoOASubscribeDepthQuotesRes>>();

            _symbolsForConversionResponseStream = new ObservableStream<StreamMessage<ProtoOASymbolsForConversionRes>>();

            _symbolsListResponseStream = new ObservableStream<StreamMessage<ProtoOASymbolsListRes>>();

            _symbolByIdResponseStream = new ObservableStream<StreamMessage<ProtoOASymbolByIdRes>>();

            _traderResponseStream = new ObservableStream<StreamMessage<ProtoOATraderRes>>();

            _unsubscribeSpotsResponseStream = new ObservableStream<StreamMessage<ProtoOAUnsubscribeSpotsRes>>();

            _unsubscribeDepthQuotesResponseStream = new ObservableStream<StreamMessage<ProtoOAUnsubscribeDepthQuotesRes>>();

            _versionResponseStream = new ObservableStream<StreamMessage<ProtoOAVersionRes>>();

            _ctidProfileResponseStream = new ObservableStream<StreamMessage<ProtoOAGetCtidProfileByTokenRes>>();

            _symbolCategoryListResponseStream = new ObservableStream<StreamMessage<ProtoOASymbolCategoryListRes>>();

            _accountLogoutResponseStream = new ObservableStream<StreamMessage<ProtoOAAccountLogoutRes>>();

            _refreshTokenResponseStream = new ObservableStream<StreamMessage<ProtoOARefreshTokenRes>>();

            _accountDisconnectEventStream = new ObservableStream<ProtoOAAccountDisconnectEvent>();

            _marginCallListResponseStream = new ObservableStream<StreamMessage<ProtoOAMarginCallListRes>>();

            _marginCallUpdateResponseStream = new ObservableStream<StreamMessage<ProtoOAMarginCallUpdateRes>>();

            _marginCallUpdateEventStream = new ObservableStream<ProtoOAMarginCallUpdateEvent>();

            _marginCallTriggerEventStream = new ObservableStream<ProtoOAMarginCallTriggerEvent>();

            _listenerExceptionStream = new ObservableStream<Exception>();

            _senderExceptionStream = new ObservableStream<Exception>();

            _heartbeatSendingExceptionStream = new ObservableStream<Exception>();
        }

        #region Streams

        public IObservableStream<ProtoOASpotEvent> SpotStream => _spotStream;

        public IObservableStream<ProtoHeartbeatEvent> HeartbeatStream => _heartbeatStream;

        public IObservableStream<ProtoOAExecutionEvent> ExecutionStream => _executionStream;

        public IObservableStream<ProtoMessage> MessageStream => _messageStream;

        public IObservableStream<ProtoOADepthEvent> DepthQuotesStream => _depthQuotesStream;

        public IObservableStream<ProtoOATrailingSLChangedEvent> TrailingSLChangedStream => _trailingSLChangedStream;

        public IObservableStream<ProtoOATraderUpdatedEvent> TraderUpdateStream => _traderUpdateStream;

        public IObservableStream<ProtoOAOrderErrorEvent> OrderErrorStream => _orderErrorStream;

        public IObservableStream<ProtoOAMarginChangedEvent> MarginChangeStream => _marginChangeStream;

        public IObservableStream<ProtoOAAccountsTokenInvalidatedEvent> TokenInvalidatedStream => _tokenInvalidatedStream;

        public IObservableStream<ProtoOAClientDisconnectEvent> ClientDisconnectedStream => _clientDisconnectedStream;

        public IObservableStream<ProtoOAErrorRes> ErrorStream => _errorStream;

        public IObservableStream<ProtoOASymbolChangedEvent> SymbolChangedStream => _symbolChangedStream;

        public IObservableStream<StreamMessage<ProtoOAApplicationAuthRes>> ApplicationAuthResponseStream => _applicationAuthResponseStream;

        public IObservableStream<StreamMessage<ProtoOAAccountAuthRes>> AccountAuthorizationResponseStream => _accountAuthorizationResponseStream;

        public IObservableStream<StreamMessage<ProtoOADealListRes>> DealListResponseStream => _dealListResponseStream;

        public IObservableStream<StreamMessage<ProtoOAAssetListRes>> AssetListResponseStream => _assetListResponseStream;

        public IObservableStream<StreamMessage<ProtoOAAssetClassListRes>> AssetClassListResponseStream => _assetClassListResponseStream;

        public IObservableStream<StreamMessage<ProtoOACashFlowHistoryListRes>> CashFlowHistoryListResponseStream => _cashFlowHistoryListResponseStream;

        public IObservableStream<StreamMessage<ProtoOAExpectedMarginRes>> ExpectedMarginResponseStream => _expectedMarginResponseStream;

        public IObservableStream<StreamMessage<ProtoOAGetAccountListByAccessTokenRes>> AccountListResponseStream => _accountListResponseStream;

        public IObservableStream<StreamMessage<ProtoOAGetTickDataRes>> TickDataResponseStream => _tickDataResponseStream;

        public IObservableStream<StreamMessage<ProtoOAGetTrendbarsRes>> TrendbarsResponseStream => _trendbarsResponseStream;

        public IObservableStream<StreamMessage<ProtoOAReconcileRes>> ReconcileResponseStream => _reconcileResponseStream;

        public IObservableStream<StreamMessage<ProtoOASubscribeSpotsRes>> SubscribeSpotsResponseStream => _subscribeSpotsResponseStream;

        public IObservableStream<StreamMessage<ProtoOASubscribeDepthQuotesRes>> SubscribeDepthQuotesResponseStream => _subscribeDepthQuotesResponseStream;

        public IObservableStream<StreamMessage<ProtoOASymbolsForConversionRes>> SymbolsForConversionResponseStream => _symbolsForConversionResponseStream;

        public IObservableStream<StreamMessage<ProtoOASymbolsListRes>> SymbolsListResponseStream => _symbolsListResponseStream;

        public IObservableStream<StreamMessage<ProtoOASymbolByIdRes>> SymbolByIdResponseStream => _symbolByIdResponseStream;

        public IObservableStream<StreamMessage<ProtoOATraderRes>> TraderResponseStream => _traderResponseStream;

        public IObservableStream<StreamMessage<ProtoOAUnsubscribeSpotsRes>> UnsubscribeSpotsResponseStream => _unsubscribeSpotsResponseStream;

        public IObservableStream<StreamMessage<ProtoOAUnsubscribeDepthQuotesRes>> UnsubscribeDepthQuotesResponseStream => _unsubscribeDepthQuotesResponseStream;

        public IObservableStream<StreamMessage<ProtoOAVersionRes>> VersionResponseStream => _versionResponseStream;

        public IObservableStream<StreamMessage<ProtoOAGetCtidProfileByTokenRes>> CtidProfileResponseStream => _ctidProfileResponseStream;

        public IObservableStream<StreamMessage<ProtoOASymbolCategoryListRes>> SymbolCategoryListResponseStream => _symbolCategoryListResponseStream;

        public IObservableStream<StreamMessage<ProtoOAAccountLogoutRes>> AccountLogoutResponseStream => _accountLogoutResponseStream;

        public IObservableStream<StreamMessage<ProtoOARefreshTokenRes>> RefreshTokenResponseStream => _refreshTokenResponseStream;

        public IObservableStream<ProtoOAAccountDisconnectEvent> AccountDisconnectEventStream => _accountDisconnectEventStream;

        public IObservableStream<StreamMessage<ProtoOAMarginCallListRes>> MarginCallListResponseStream => _marginCallListResponseStream;

        public IObservableStream<StreamMessage<ProtoOAMarginCallUpdateRes>> MarginCallUpdateResponseStream => _marginCallUpdateResponseStream;

        public IObservableStream<ProtoOAMarginCallUpdateEvent> MarginCallUpdateEventStream => _marginCallUpdateEventStream;

        public IObservableStream<ProtoOAMarginCallTriggerEvent> MarginCallTriggerEventStream => _marginCallTriggerEventStream;

        public IObservableStream<Exception> ListenerExceptionStream => _listenerExceptionStream;

        public IObservableStream<Exception> SenderExceptionStream => _senderExceptionStream;

        public IObservableStream<Exception> HeartbeatSendingExceptionStream => _heartbeatSendingExceptionStream;

        #endregion Streams

        #region Streams incoming data handling methods

        private void OnApplicationAuthResponse(ProtoOAApplicationAuthRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAApplicationAuthRes>(e, clientMsgId);

            _applicationAuthResponseStream.OnNext(streamMessage);
        }

        private void OnSubscribeDepthQuotesResponse(ProtoOASubscribeDepthQuotesRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOASubscribeDepthQuotesRes>(e, clientMsgId);

            _subscribeDepthQuotesResponseStream.OnNext(streamMessage);
        }

        private void OnUnsubscribeDepthQuotesResponse(ProtoOAUnsubscribeDepthQuotesRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAUnsubscribeDepthQuotesRes>(e, clientMsgId);

            _unsubscribeDepthQuotesResponseStream.OnNext(streamMessage);
        }

        private void OnAccountAuthorizationResponse(ProtoOAAccountAuthRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAAccountAuthRes>(e, clientMsgId);

            _accountAuthorizationResponseStream.OnNext(streamMessage);
        }

        private void OnDealListResponse(ProtoOADealListRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOADealListRes>(e, clientMsgId);

            _dealListResponseStream.OnNext(streamMessage);
        }

        private void OnAssetListResponse(ProtoOAAssetListRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAAssetListRes>(e, clientMsgId);

            _assetListResponseStream.OnNext(streamMessage);
        }

        private void OnAssetClassListResponse(ProtoOAAssetClassListRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAAssetClassListRes>(e, clientMsgId);

            _assetClassListResponseStream.OnNext(streamMessage);
        }

        private void OnCashFlowHistoryListResponse(ProtoOACashFlowHistoryListRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOACashFlowHistoryListRes>(e, clientMsgId);

            _cashFlowHistoryListResponseStream.OnNext(streamMessage);
        }

        private void OnExpectedMarginResponse(ProtoOAExpectedMarginRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAExpectedMarginRes>(e, clientMsgId);

            _expectedMarginResponseStream.OnNext(streamMessage);
        }

        private void OnAccountListResponse(ProtoOAGetAccountListByAccessTokenRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAGetAccountListByAccessTokenRes>(e, clientMsgId);

            _accountListResponseStream.OnNext(streamMessage);
        }

        private void OnTickDataResponse(ProtoOAGetTickDataRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAGetTickDataRes>(e, clientMsgId);

            _tickDataResponseStream.OnNext(streamMessage);
        }

        private void OnTrendbarsResponse(ProtoOAGetTrendbarsRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAGetTrendbarsRes>(e, clientMsgId);

            _trendbarsResponseStream.OnNext(streamMessage);
        }

        private void OnReconcileResponse(ProtoOAReconcileRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAReconcileRes>(e, clientMsgId);

            _reconcileResponseStream.OnNext(streamMessage);
        }

        private void OnSubscribeSpotsResponse(ProtoOASubscribeSpotsRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOASubscribeSpotsRes>(e, clientMsgId);

            _subscribeSpotsResponseStream.OnNext(streamMessage);
        }

        private void OnSymbolsForConversionResponse(ProtoOASymbolsForConversionRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOASymbolsForConversionRes>(e, clientMsgId);

            _symbolsForConversionResponseStream.OnNext(streamMessage);
        }

        private void OnSymbolsListResponse(ProtoOASymbolsListRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOASymbolsListRes>(e, clientMsgId);

            _symbolsListResponseStream.OnNext(streamMessage);
        }

        private void OnSymbolByIdResponse(ProtoOASymbolByIdRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOASymbolByIdRes>(e, clientMsgId);

            _symbolByIdResponseStream.OnNext(streamMessage);
        }

        private void OnTraderResponse(ProtoOATraderRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOATraderRes>(e, clientMsgId);

            _traderResponseStream.OnNext(streamMessage);
        }

        private void OnUnsubscribeSpotsResponse(ProtoOAUnsubscribeSpotsRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAUnsubscribeSpotsRes>(e, clientMsgId);

            _unsubscribeSpotsResponseStream.OnNext(streamMessage);
        }

        private void OnVersionResponse(ProtoOAVersionRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAVersionRes>(e, clientMsgId);

            _versionResponseStream.OnNext(streamMessage);
        }

        private void OnCtidProfileResponse(ProtoOAGetCtidProfileByTokenRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAGetCtidProfileByTokenRes>(e, clientMsgId);

            _ctidProfileResponseStream.OnNext(streamMessage);
        }

        private void OnSymbolCategoryListResponse(ProtoOASymbolCategoryListRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOASymbolCategoryListRes>(e, clientMsgId);

            _symbolCategoryListResponseStream.OnNext(streamMessage);
        }

        private void OnAccountLogoutResponse(ProtoOAAccountLogoutRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAAccountLogoutRes>(e, clientMsgId);

            _accountLogoutResponseStream.OnNext(streamMessage);
        }

        private void OnRefreshTokenResponse(ProtoOARefreshTokenRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOARefreshTokenRes>(e, clientMsgId);

            _refreshTokenResponseStream.OnNext(streamMessage);
        }

        internal void OnListenerException(Exception exception) => _listenerExceptionStream.OnNext(exception);

        internal void OnSenderException(Exception exception) => _senderExceptionStream.OnNext(exception);

        internal void OnHeartbeatSendingException(Exception exception) => _heartbeatSendingExceptionStream.OnNext(exception);

        private void OnMarginCallUpdateResponse(ProtoOAMarginCallUpdateRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAMarginCallUpdateRes>(e, clientMsgId);

            _marginCallUpdateResponseStream.OnNext(streamMessage);
        }

        private void OnMarginCallListResponse(ProtoOAMarginCallListRes e, string clientMsgId)
        {
            var streamMessage = new StreamMessage<ProtoOAMarginCallListRes>(e, clientMsgId);

            _marginCallListResponseStream.OnNext(streamMessage);
        }

        internal void InvokeMessageStream(byte[] data)
        {
            var protoMessage = ProtoMessage.Parser.ParseFrom(data);

            var payload = protoMessage.Payload;

            _messageStream.OnNext(protoMessage);

            switch (protoMessage.PayloadType)
            {
                case (int)ProtoOAPayloadType.ProtoOaErrorRes:
                    {
                        var message = ProtoOAErrorRes.Parser.ParseFrom(payload);

                        _errorStream.OnNext(message);

                        break;
                    }
                case (int)ProtoPayloadType.HeartbeatEvent:
                    {
                        var message = ProtoHeartbeatEvent.Parser.ParseFrom(payload);

                        _heartbeatStream.OnNext(message);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAccountAuthRes:
                    {
                        var message = ProtoOAAccountAuthRes.Parser.ParseFrom(payload);

                        OnAccountAuthorizationResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaApplicationAuthRes:
                    {
                        var message = ProtoOAApplicationAuthRes.Parser.ParseFrom(payload);

                        OnApplicationAuthResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaClientDisconnectEvent:
                    {
                        var message = ProtoOAClientDisconnectEvent.Parser.ParseFrom(payload);

                        _clientDisconnectedStream.OnNext(message);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaDealListRes:
                    {
                        var message = ProtoOADealListRes.Parser.ParseFrom(payload);

                        OnDealListResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAssetListRes:
                    {
                        var message = ProtoOAAssetListRes.Parser.ParseFrom(payload);

                        OnAssetListResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAssetClassListRes:
                    {
                        var message = ProtoOAAssetClassListRes.Parser.ParseFrom(payload);

                        OnAssetClassListResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAccountsTokenInvalidatedEvent:
                    {
                        var message = ProtoOAAccountsTokenInvalidatedEvent.Parser.ParseFrom(payload);

                        _tokenInvalidatedStream.OnNext(message);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaCashFlowHistoryListRes:
                    {
                        var message = ProtoOACashFlowHistoryListRes.Parser.ParseFrom(payload);

                        OnCashFlowHistoryListResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaExecutionEvent:
                    {
                        var message = ProtoOAExecutionEvent.Parser.ParseFrom(payload);

                        _executionStream.OnNext(message);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaExpectedMarginRes:
                    {
                        var message = ProtoOAExpectedMarginRes.Parser.ParseFrom(payload);

                        OnExpectedMarginResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaGetAccountsByAccessTokenRes:
                    {
                        var message = ProtoOAGetAccountListByAccessTokenRes.Parser.ParseFrom(payload);

                        OnAccountListResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaGetTickdataRes:
                    {
                        var message = ProtoOAGetTickDataRes.Parser.ParseFrom(payload);

                        OnTickDataResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaGetTrendbarsRes:
                    {
                        var message = ProtoOAGetTrendbarsRes.Parser.ParseFrom(payload);

                        OnTrendbarsResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaMarginChangedEvent:
                    {
                        var message = ProtoOAMarginChangedEvent.Parser.ParseFrom(payload);

                        _marginChangeStream.OnNext(message);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaOrderErrorEvent:
                    {
                        var message = ProtoOAOrderErrorEvent.Parser.ParseFrom(payload);

                        _orderErrorStream.OnNext(message);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaReconcileRes:
                    {
                        var message = ProtoOAReconcileRes.Parser.ParseFrom(payload);

                        OnReconcileResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSpotEvent:
                    {
                        var message = ProtoOASpotEvent.Parser.ParseFrom(payload);

                        _spotStream.OnNext(message);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSubscribeSpotsRes:
                    {
                        var message = ProtoOASubscribeSpotsRes.Parser.ParseFrom(payload);

                        OnSubscribeSpotsResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolsForConversionRes:
                    {
                        var message = ProtoOASymbolsForConversionRes.Parser.ParseFrom(payload);

                        OnSymbolsForConversionResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolsListRes:
                    {
                        var message = ProtoOASymbolsListRes.Parser.ParseFrom(payload);

                        OnSymbolsListResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolByIdRes:
                    {
                        var message = ProtoOASymbolByIdRes.Parser.ParseFrom(payload);

                        OnSymbolByIdResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolChangedEvent:
                    {
                        var message = ProtoOASymbolChangedEvent.Parser.ParseFrom(payload);

                        _symbolChangedStream.OnNext(message);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaTraderRes:
                    {
                        var message = ProtoOATraderRes.Parser.ParseFrom(payload);

                        OnTraderResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaTraderUpdateEvent:
                    {
                        var message = ProtoOATraderUpdatedEvent.Parser.ParseFrom(payload);

                        _traderUpdateStream.OnNext(message);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaTrailingSlChangedEvent:
                    {
                        var message = ProtoOATrailingSLChangedEvent.Parser.ParseFrom(payload);

                        _trailingSLChangedStream.OnNext(message);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaUnsubscribeSpotsRes:
                    {
                        var message = ProtoOAUnsubscribeSpotsRes.Parser.ParseFrom(payload);

                        OnUnsubscribeSpotsResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaVersionRes:
                    {
                        var message = ProtoOAVersionRes.Parser.ParseFrom(payload);

                        OnVersionResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaGetCtidProfileByTokenRes:
                    {
                        var message = ProtoOAGetCtidProfileByTokenRes.Parser.ParseFrom(payload);

                        OnCtidProfileResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolCategoryRes:
                    {
                        var message = ProtoOASymbolCategoryListRes.Parser.ParseFrom(payload);

                        OnSymbolCategoryListResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaDepthEvent:
                    {
                        var message = ProtoOADepthEvent.Parser.ParseFrom(payload);

                        _depthQuotesStream.OnNext(message);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSubscribeDepthQuotesRes:
                    {
                        var message = ProtoOASubscribeDepthQuotesRes.Parser.ParseFrom(payload);

                        OnSubscribeDepthQuotesResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaUnsubscribeDepthQuotesRes:
                    {
                        var message = ProtoOAUnsubscribeDepthQuotesRes.Parser.ParseFrom(payload);

                        OnUnsubscribeDepthQuotesResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAccountLogoutRes:
                    {
                        var message = ProtoOAAccountLogoutRes.Parser.ParseFrom(payload);

                        OnAccountLogoutResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaRefreshTokenRes:
                    {
                        var message = ProtoOARefreshTokenRes.Parser.ParseFrom(payload);

                        OnRefreshTokenResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAccountDisconnectEvent:
                    {
                        var message = ProtoOAAccountDisconnectEvent.Parser.ParseFrom(payload);

                        _accountDisconnectEventStream.OnNext(message);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaMarginCallListRes:
                    {
                        var message = ProtoOAMarginCallListRes.Parser.ParseFrom(payload);

                        OnMarginCallListResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaMarginCallUpdateRes:
                    {
                        var message = ProtoOAMarginCallUpdateRes.Parser.ParseFrom(payload);

                        OnMarginCallUpdateResponse(message, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaMarginCallUpdateEvent:
                    {
                        var message = ProtoOAMarginCallUpdateEvent.Parser.ParseFrom(payload);

                        _marginCallUpdateEventStream.OnNext(message);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaMarginCallTriggerEvent:
                    {
                        var message = ProtoOAMarginCallTriggerEvent.Parser.ParseFrom(payload);

                        _marginCallTriggerEventStream.OnNext(message);

                        break;
                    }
                default:
                    break;
            }
        }




        #endregion Streams incoming data handling methods
    }
}