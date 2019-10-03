using System;

namespace Connect.Protobuf
{
    public class Events
    {
        #region Events

        public event ApplicationAuthResponseEventHandler ApplicationAuthResponseEvent;

        public event ExecutionEventHandler ExecutionEvent;

        public event SpotEventHandler SpotEvent;

        public event DepthQuotesEvnetHandler DepthQuotesEvent;

        public event SubscribeDepthQuotesResponseEventHandler SubscribeDepthQuotesResponseEvent;

        public event UnsubscribeDepthQuotesResponseEventHandler UnsubscribeDepthQuotesResponseEvent;

        public event ErrorHandler ErrorEvent;

        public event ListenerExceptionEventHandler ListenerExceptionEvent;

        public event HeartbeatSendingExceptionEventHandler HeartbeatSendingExceptionEvent;

        public event PingResponseEventHandler PingResponseEvent;

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

        internal void OnExecution(object sender, ProtoOAExecutionEvent e)
        {
            ExecutionEvent?.Invoke(sender, e);
        }

        internal void OnSpot(object sender, ProtoOASpotEvent spotEvent)
        {
            SpotEvent?.Invoke(sender, spotEvent);
        }

        internal void OnDepthQuotes(object sender, ProtoOADepthEvent depthEvent)
        {
            DepthQuotesEvent?.Invoke(sender, depthEvent);
        }

        internal void OnError(object sender, ProtoOAErrorRes e)
        {
            ErrorEvent?.Invoke(sender, e);
        }

        internal void OnApplicationAuthResponse(object sender, ProtoOAApplicationAuthRes e, string clientMsgId)
        {
            ApplicationAuthResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnSubscribeDepthQuotesResponse(object sender, ProtoOASubscribeDepthQuotesRes e, string clientMsgId)
        {
            SubscribeDepthQuotesResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnUnsubscribeDepthQuotesResponse(object sender, ProtoOAUnsubscribeDepthQuotesRes e, string clientMsgId)
        {
            UnsubscribeDepthQuotesResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnListenerException(object sender, Exception ex)
        {
            ListenerExceptionEvent?.Invoke(sender, ex);
        }

        internal void OnHeartbeatSendingException(object sender, Exception ex)
        {
            HeartbeatSendingExceptionEvent?.Invoke(sender, ex);
        }

        internal void OnPingResponse(object sender, ProtoPingRes e, string clientMsgId)
        {
            PingResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnHeartbeat(object sender, ProtoHeartbeatEvent e)
        {
            HeartbeatEvent?.Invoke(sender, e);
        }

        internal void OnAccountAuthorizationResponse(object sender, ProtoOAAccountAuthRes e, string clientMsgId)
        {
            AccountAuthorizationResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnClientDisconnected(object sender, ProtoOAClientDisconnectEvent e)
        {
            ClientDisconnectedEvent?.Invoke(sender, e);
        }

        internal void OnDealListResponse(object sender, ProtoOADealListRes e, string clientMsgId)
        {
            DealListResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnAssetListResponse(object sender, ProtoOAAssetListRes e, string clientMsgId)
        {
            AssetListResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnAssetClassListResponse(object sender, ProtoOAAssetClassListRes e, string clientMsgId)
        {
            AssetClassListResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnAccountsTokenInvalidated(object sender, ProtoOAAccountsTokenInvalidatedEvent e)
        {
            AccountsTokenInvalidatedEvent?.Invoke(sender, e);
        }

        internal void OnCashFlowHistoryListResponse(object sender, ProtoOACashFlowHistoryListRes e, string clientMsgId)
        {
            CashFlowHistoryListResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnExpectedMarginResponse(object sender, ProtoOAExpectedMarginRes e, string clientMsgId)
        {
            ExpectedMarginResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnAccountListResponse(object sender, ProtoOAGetAccountListByAccessTokenRes e, string clientMsgId)
        {
            AccountListResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnTickDataResponse(object sender, ProtoOAGetTickDataRes e, string clientMsgId)
        {
            TickDataResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnTrendbarsResponse(object sender, ProtoOAGetTrendbarsRes e, string clientMsgId)
        {
            TrendbarsResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnMarginChanged(object sender, ProtoOAMarginChangedEvent e)
        {
            MarginChangedEvent?.Invoke(sender, e);
        }

        internal void OnOrderError(object sender, ProtoOAOrderErrorEvent e)
        {
            OrderErrorEvent?.Invoke(sender, e);
        }

        internal void OnReconcileResponse(object sender, ProtoOAReconcileRes e, string clientMsgId)
        {
            ReconcileResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnSubscribeSpotsResponse(object sender, ProtoOASubscribeSpotsRes e, string clientMsgId)
        {
            SubscribeSpotsResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnSymbolsForConversionResponse(object sender, ProtoOASymbolsForConversionRes e, string clientMsgId)
        {
            SymbolsForConversionResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnSymbolsListResponse(object sender, ProtoOASymbolsListRes e, string clientMsgId)
        {
            SymbolsListResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnSymbolByIdResponse(object sender, ProtoOASymbolByIdRes e, string clientMsgId)
        {
            SymbolByIdResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnSymbolChanged(object sender, ProtoOASymbolChangedEvent e)
        {
            SymbolChangedEvent?.Invoke(sender, e);
        }

        internal void OnTraderResponse(object sender, ProtoOATraderRes e, string clientMsgId)
        {
            TraderResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnTraderUpdated(object sender, ProtoOATraderUpdatedEvent e)
        {
            TraderUpdatedEvent?.Invoke(sender, e);
        }

        internal void OnTrailingSLChanged(object sender, ProtoOATrailingSLChangedEvent e)
        {
            TrailingSLChangedEvent?.Invoke(sender, e);
        }

        internal void OnUnsubscribeSpotsResponse(object sender, ProtoOAUnsubscribeSpotsRes e, string clientMsgId)
        {
            UnsubscribeSpotsResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnVersionResponse(object sender, ProtoOAVersionRes e, string clientMsgId)
        {
            VersionResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnCtidProfileResponse(object sender, ProtoOAGetCtidProfileByTokenRes e, string clientMsgId)
        {
            CtidProfileResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnSymbolCategoryListResponse(object sender, ProtoOASymbolCategoryListRes e, string clientMsgId)
        {
            SymbolCategoryListResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnAccountLogoutResponse(object sender, ProtoOAAccountLogoutRes e, string clientMsgId)
        {
            AccountLogoutResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        internal void OnMessageReceived(object sender, ProtoMessage e)
        {
            MessageReceivedEvent?.Invoke(sender, e);
        }

        #endregion Invoking Methods
    }
}