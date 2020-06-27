using System;

namespace Connect.Protobuf
{
    public class EventsContainer
    {
        #region Fields

        private readonly Client _client;

        #endregion;

        public EventsContainer(Client client) => _client = client;

        #region Events

        public event ApplicationAuthResponseEventHandler ApplicationAuthResponseEvent;

        public event ExecutionEventHandler ExecutionEvent;

        public event SpotEventHandler SpotEvent;

        public event DepthQuotesEvnetHandler DepthQuotesEvent;

        public event SubscribeDepthQuotesResponseEventHandler SubscribeDepthQuotesResponseEvent;

        public event UnsubscribeDepthQuotesResponseEventHandler UnsubscribeDepthQuotesResponseEvent;

        public event ErrorHandler ErrorEvent;

        public event ExceptionEventHandler ListenerExceptionEvent;

        public event ExceptionEventHandler SenderExceptionEvent;

        public event ExceptionEventHandler HeartbeatSendingExceptionEvent;

        public event HeartbeatEventHandler HeartbeatEvent;

        public event AccountAuthorizationResponseEventHandler AccountAuthorizationResponseEvent;

        public event ClientDisconnectedEventHandler ClientDisconnectedEvent;

        public event DealListResponseEventHandler DealListResponseEvent;

        public event AssetListResponseEventHandler AssetListResponseEvent;

        public event AssetClassListResponseEventHandler AssetClassListResponseEvent;

        public event AccountsTokenInvalidatedEventHandler AccountsTokenInvalidatedEvent;

        public event CashFlowHistoryListResponseEventHandler CashFlowHistoryListResponseEvent;

        public event ExpectedMarginResponseEventHandler ExpectedMarginResponseEvent;

        public event AccountListResponseEventHandler AccountListResponseEvent;

        public event TickDataResponseEventHandler TickDataResponseEvent;

        public event TrendbarsResponseEventHandler TrendbarsResponseEvent;

        public event MarginChangedEventHandler MarginChangedEvent;

        public event OrderErrorEventHandler OrderErrorEvent;

        public event ReconcileResponseEventHandler ReconcileResponseEvent;

        public event SubscribeSpotsResponseEventHandler SubscribeSpotsResponseEvent;

        public event SymbolsForConversionResponseEventHandler SymbolsForConversionResponseEvent;

        public event SymbolsListResponseEventHandler SymbolsListResponseEvent;

        public event SymbolByIdResponseEventHandler SymbolByIdResponseEvent;

        public event SymbolChangedEventHandler SymbolChangedEvent;

        public event TraderResponseEventHandler TraderResponseEvent;

        public event TraderUpdatedEventHandler TraderUpdatedEvent;

        public event TrailingSLChangedEventHandler TrailingSLChangedEvent;

        public event UnsubscribeSpotsResponseEventHandler UnsubscribeSpotsResponseEvent;

        public event VersionResponseEventHandler VersionResponseEvent;

        public event MessageReceivedEventHandler MessageReceivedEvent;

        public event CtidProfileResponseEventHandler CtidProfileResponseEvent;

        public event SymbolCategoryListResponseEventHandler SymbolCategoryListResponseEvent;

        public event AccountLogoutResponseEventHandler AccountLogoutResponseEvent;

        #endregion Events

        #region Invoking Methods

        internal void OnExecution(ProtoOAExecutionEvent e)
        {
            ExecutionEvent?.Invoke(_client, e);
        }

        internal void OnSpot(ProtoOASpotEvent spotEvent)
        {
            SpotEvent?.Invoke(_client, spotEvent);
        }

        internal void OnDepthQuotes(ProtoOADepthEvent depthEvent)
        {
            DepthQuotesEvent?.Invoke(_client, depthEvent);
        }

        internal void OnError(ProtoOAErrorRes e)
        {
            ErrorEvent?.Invoke(_client, e);
        }

        internal void OnApplicationAuthResponse(ProtoOAApplicationAuthRes e, string clientMsgId)
        {
            ApplicationAuthResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnSubscribeDepthQuotesResponse(ProtoOASubscribeDepthQuotesRes e, string clientMsgId)
        {
            SubscribeDepthQuotesResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnUnsubscribeDepthQuotesResponse(ProtoOAUnsubscribeDepthQuotesRes e, string clientMsgId)
        {
            UnsubscribeDepthQuotesResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal bool OnListenerException(Exception ex)
        {
            var handler = ListenerExceptionEvent;

            if (handler == null)
            {
                return false;
            }
            else
            {
                handler.Invoke(_client, ex);

                return true;
            }
        }

        internal bool OnSenderException(Exception ex)
        {
            var handler = SenderExceptionEvent;

            if (handler == null)
            {
                return false;
            }
            else
            {
                handler.Invoke(_client, ex);

                return true;
            }
        }

        internal bool OnHeartbeatSendingException(Exception ex)
        {
            var handler = HeartbeatSendingExceptionEvent;

            if (handler == null)
            {
                return false;
            }
            else
            {
                handler.Invoke(_client, ex);

                return true;
            }
        }

        internal void OnHeartbeat(ProtoHeartbeatEvent e)
        {
            HeartbeatEvent?.Invoke(_client, e);
        }

        internal void OnAccountAuthorizationResponse(ProtoOAAccountAuthRes e, string clientMsgId)
        {
            AccountAuthorizationResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnClientDisconnected(ProtoOAClientDisconnectEvent e)
        {
            ClientDisconnectedEvent?.Invoke(_client, e);
        }

        internal void OnDealListResponse(ProtoOADealListRes e, string clientMsgId)
        {
            DealListResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnAssetListResponse(ProtoOAAssetListRes e, string clientMsgId)
        {
            AssetListResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnAssetClassListResponse(ProtoOAAssetClassListRes e, string clientMsgId)
        {
            AssetClassListResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnAccountsTokenInvalidated(ProtoOAAccountsTokenInvalidatedEvent e)
        {
            AccountsTokenInvalidatedEvent?.Invoke(_client, e);
        }

        internal void OnCashFlowHistoryListResponse(ProtoOACashFlowHistoryListRes e, string clientMsgId)
        {
            CashFlowHistoryListResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnExpectedMarginResponse(ProtoOAExpectedMarginRes e, string clientMsgId)
        {
            ExpectedMarginResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnAccountListResponse(ProtoOAGetAccountListByAccessTokenRes e, string clientMsgId)
        {
            AccountListResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnTickDataResponse(ProtoOAGetTickDataRes e, string clientMsgId)
        {
            TickDataResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnTrendbarsResponse(ProtoOAGetTrendbarsRes e, string clientMsgId)
        {
            TrendbarsResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnMarginChanged(ProtoOAMarginChangedEvent e)
        {
            MarginChangedEvent?.Invoke(_client, e);
        }

        internal void OnOrderError(ProtoOAOrderErrorEvent e)
        {
            OrderErrorEvent?.Invoke(_client, e);
        }

        internal void OnReconcileResponse(ProtoOAReconcileRes e, string clientMsgId)
        {
            ReconcileResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnSubscribeSpotsResponse(ProtoOASubscribeSpotsRes e, string clientMsgId)
        {
            SubscribeSpotsResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnSymbolsForConversionResponse(ProtoOASymbolsForConversionRes e, string clientMsgId)
        {
            SymbolsForConversionResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnSymbolsListResponse(ProtoOASymbolsListRes e, string clientMsgId)
        {
            SymbolsListResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnSymbolByIdResponse(ProtoOASymbolByIdRes e, string clientMsgId)
        {
            SymbolByIdResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnSymbolChanged(ProtoOASymbolChangedEvent e)
        {
            SymbolChangedEvent?.Invoke(_client, e);
        }

        internal void OnTraderResponse(ProtoOATraderRes e, string clientMsgId)
        {
            TraderResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnTraderUpdated(ProtoOATraderUpdatedEvent e)
        {
            TraderUpdatedEvent?.Invoke(_client, e);
        }

        internal void OnTrailingSLChanged(ProtoOATrailingSLChangedEvent e)
        {
            TrailingSLChangedEvent?.Invoke(_client, e);
        }

        internal void OnUnsubscribeSpotsResponse(ProtoOAUnsubscribeSpotsRes e, string clientMsgId)
        {
            UnsubscribeSpotsResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnVersionResponse(ProtoOAVersionRes e, string clientMsgId)
        {
            VersionResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnCtidProfileResponse(ProtoOAGetCtidProfileByTokenRes e, string clientMsgId)
        {
            CtidProfileResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnSymbolCategoryListResponse(ProtoOASymbolCategoryListRes e, string clientMsgId)
        {
            SymbolCategoryListResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnAccountLogoutResponse(ProtoOAAccountLogoutRes e, string clientMsgId)
        {
            AccountLogoutResponseEvent?.Invoke(_client, e, clientMsgId);
        }

        internal void OnMessageReceived(ProtoMessage e)
        {
            MessageReceivedEvent?.Invoke(_client, e);
        }

        internal void InvokeMessageEvent(byte[] data)
        {
            var protoMessage = ProtoMessage.Parser.ParseFrom(data);

            var payload = protoMessage.Payload;

            OnMessageReceived(protoMessage);

            switch (protoMessage.PayloadType)
            {
                case (int)ProtoOAPayloadType.ProtoOaErrorRes:
                    {
                        var protoErrorRes = ProtoOAErrorRes.Parser.ParseFrom(payload);

                        OnError(protoErrorRes);

                        break;
                    }
                case (int)ProtoPayloadType.HeartbeatEvent:
                    {
                        var protoHeartbeatEvent = ProtoHeartbeatEvent.Parser.ParseFrom(payload);

                        OnHeartbeat(protoHeartbeatEvent);

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

                        OnClientDisconnected(protoOAClientDisconnect);

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

                        OnAccountsTokenInvalidated(protoOAAccountsTokenInvalidatedEvent);

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

                        OnExecution(protoOAExecutionEvent);

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

                        OnMarginChanged(protoOAMarginChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaOrderErrorEvent:
                    {
                        var protoOAOrderErrorEvent = ProtoOAOrderErrorEvent.Parser.ParseFrom(payload);

                        OnOrderError(protoOAOrderErrorEvent);

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

                        OnSpot(protoOASpotEvent);

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

                        OnSymbolChanged(protoOASymbolChangedEvent);

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

                        OnTraderUpdated(protoOATraderUpdatedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaTrailingSlChangedEvent:
                    {
                        var protoOATrailingSLChangedEvent = ProtoOATrailingSLChangedEvent.Parser.ParseFrom(payload);

                        OnTrailingSLChanged(protoOATrailingSLChangedEvent);

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

                        OnDepthQuotes(depthEvent);

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

        #endregion Invoking Methods
    }
}