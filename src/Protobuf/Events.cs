using Connect.Common;
using System;

namespace Connect.Protobuf
{
    public class Events
    {
        #region Delegates

        public delegate void ApplicationAuthResponseEventHandler(object sender, ProtoOAApplicationAuthRes e);

        public delegate void ExecutionEventHandler(object sender, ProtoOAExecutionEvent e);

        public delegate void SpotEventHandler(object sender, ProtoOASpotEvent e);

        public delegate void ErrorHandler(object sender, ProtoOAErrorRes e);

        public delegate void ExceptionHandler(object sender, Exception ex);

        public delegate void HeartbeatEventHandler(object sender, ProtoHeartbeatEvent e);

        public delegate void AccountAuthorizationResponseEventHandler(object sender, ProtoOAAccountAuthRes e);

        public delegate void ClientDisconnectedEventHandler(object sender, ProtoOAClientDisconnectEvent e);

        public delegate void DealListResponseEventHandler(object sender, ProtoOADealListRes e);

        public delegate void AssetListResponseEventHandler(object sender, ProtoOAAssetListRes e);

        public delegate void AccountsTokenInvalidatedEventHandler(object sender, ProtoOAAccountsTokenInvalidatedEvent e);

        public delegate void CashFlowHistoryListResponseEventHandler(object sender, ProtoOACashFlowHistoryListRes e);

        public delegate void ExpectedMarginResponseEventHandler(object sender, ProtoOAExpectedMarginRes e);

        public delegate void GetAccountListByAccessTokenResponseEventHandler(object sender, ProtoOAGetAccountListByAccessTokenRes e);

        public delegate void GetTickDataResponseEventHandler(object sender, ProtoOAGetTickDataRes e);

        public delegate void GetTrendbarsResponseEventHandler(object sender, ProtoOAGetTrendbarsRes e);

        public delegate void MarginChangedEventHandler(object sender, ProtoOAMarginChangedEvent e);

        public delegate void OrderErrorEventHandler(object sender, ProtoOAOrderErrorEvent e);

        public delegate void ReconcileResponseEventHandler(object sender, ProtoOAReconcileRes e);

        public delegate void SubscribeSpotsResponseEventHandler(object sender, ProtoOASubscribeSpotsRes e);

        public delegate void SymbolsForConversionResponseEventHandler(object sender, ProtoOASymbolsForConversionRes e);

        public delegate void SymbolsListResponseEventHandler(object sender, ProtoOASymbolsListRes e);

        public delegate void SymbolByIdResponseEventHandler(object sender, ProtoOASymbolByIdRes e);

        public delegate void SymbolChangedEventHandler(object sender, ProtoOASymbolChangedEvent e);

        public delegate void TraderResponseEventHandler(object sender, ProtoOATraderRes e);

        public delegate void TraderUpdatedEventHandler(object sender, ProtoOATraderUpdatedEvent e);

        public delegate void TrailingSLChangedEventHandler(object sender, ProtoOATrailingSLChangedEvent e);

        public delegate void UnsubscribeSpotsResponseEventHandler(object sender, ProtoOAUnsubscribeSpotsRes e);

        public delegate void VersionResponseEventHandler(object sender, ProtoOAVersionRes e);

        #endregion Delegates

        #region Events

        public event ApplicationAuthResponseEventHandler ApplicationAuthResponseEvent;

        public event ExecutionEventHandler ExecutionEvent;

        public event SpotEventHandler SpotEvent;

        public event ErrorHandler ErrorEvent;

        public event ExceptionHandler ListenerStoppedEvent;

        public event ExceptionHandler HeartbeatSendingStoppedEvent;

        public event HeartbeatEventHandler HeartbeatEvent;

        public event AccountAuthorizationResponseEventHandler AccountAuthorizationResponseEvent;

        public event ClientDisconnectedEventHandler ClientDisconnectedEvent;

        public event DealListResponseEventHandler DealListResponseEvent;

        public event AssetListResponseEventHandler AssetListResponseEvent;

        public event AccountsTokenInvalidatedEventHandler AccountsTokenInvalidatedEvent;

        public event CashFlowHistoryListResponseEventHandler CashFlowHistoryListResponseEvent;

        public event ExpectedMarginResponseEventHandler ExpectedMarginResponseEvent;

        public event GetAccountListByAccessTokenResponseEventHandler GetAccountListByAccessTokenResponseEvent;

        public event GetTickDataResponseEventHandler GetTickDataResponseEvent;

        public event GetTrendbarsResponseEventHandler GetTrendbarsResponseEvent;

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

        #endregion Events

        #region Methods

        public void OnExecution(object sender, ProtoOAExecutionEvent e)
        {
            ExecutionEvent?.Invoke(sender, e);
        }

        public void OnSpot(object sender, ProtoOASpotEvent spotEvent)
        {
            SpotEvent?.Invoke(sender, spotEvent);
        }

        public void OnError(object sender, ProtoOAErrorRes e)
        {
            ErrorEvent?.Invoke(sender, e);
        }

        public void OnApplicationAuthResponse(object sender, ProtoOAApplicationAuthRes e)
        {
            ApplicationAuthResponseEvent?.Invoke(sender, e);
        }

        public void OnListenerStopped(object sender, Exception ex)
        {
            ListenerStoppedEvent?.Invoke(sender, ex);
        }

        public void OnHeartbeatSendingStopped(object sender, Exception ex)
        {
            HeartbeatSendingStoppedEvent?.Invoke(sender, ex);
        }

        public void OnHeartbeat(object sender, ProtoHeartbeatEvent e)
        {
            HeartbeatEvent?.Invoke(sender, e);
        }

        public void OnAccountAuthorizationResponse(object sender, ProtoOAAccountAuthRes e)
        {
            AccountAuthorizationResponseEvent?.Invoke(sender, e);
        }

        public void OnClientDisconnected(object sender, ProtoOAClientDisconnectEvent e)
        {
            ClientDisconnectedEvent?.Invoke(sender, e);
        }

        public void OnDealListResponse(object sender, ProtoOADealListRes e)
        {
            DealListResponseEvent?.Invoke(sender, e);
        }

        public void OnAssetListResponse(object sender, ProtoOAAssetListRes e)
        {
            AssetListResponseEvent?.Invoke(sender, e);
        }

        public void OnAccountsTokenInvalidated(object sender, ProtoOAAccountsTokenInvalidatedEvent e)
        {
            AccountsTokenInvalidatedEvent?.Invoke(sender, e);
        }

        public void OnCashFlowHistoryListResponse(object sender, ProtoOACashFlowHistoryListRes e)
        {
            CashFlowHistoryListResponseEvent?.Invoke(sender, e);
        }

        public void OnExpectedMarginResponse(object sender, ProtoOAExpectedMarginRes e)
        {
            ExpectedMarginResponseEvent?.Invoke(sender, e);
        }

        public void OnGetAccountListByAccessTokenResponse(object sender, ProtoOAGetAccountListByAccessTokenRes e)
        {
            GetAccountListByAccessTokenResponseEvent.Invoke(sender, e);
        }

        public void OnGetTickDataResponse(object sender, ProtoOAGetTickDataRes e)
        {
            GetTickDataResponseEvent?.Invoke(sender, e);
        }

        public void OnGetTrendbarsResponse(object sender, ProtoOAGetTrendbarsRes e)
        {
            GetTrendbarsResponseEvent?.Invoke(sender, e);
        }

        public void OnMarginChanged(object sender, ProtoOAMarginChangedEvent e)
        {
            MarginChangedEvent?.Invoke(sender, e);
        }

        public void OnOrderError(object sender, ProtoOAOrderErrorEvent e)
        {
            OrderErrorEvent?.Invoke(sender, e);
        }

        public void OnReconcileResponse(object sender, ProtoOAReconcileRes e)
        {
            ReconcileResponseEvent?.Invoke(sender, e);
        }

        public void OnSubscribeSpotsResponse(object sender, ProtoOASubscribeSpotsRes e)
        {
            SubscribeSpotsResponseEvent?.Invoke(sender, e);
        }

        public void OnSymbolsForConversionResponse(object sender, ProtoOASymbolsForConversionRes e)
        {
            SymbolsForConversionResponseEvent?.Invoke(sender, e);
        }

        public void OnSymbolsListResponse(object sender , ProtoOASymbolsListRes e)
        {
            SymbolsListResponseEvent?.Invoke(sender, e);
        }

        public void OnSymbolByIdResponse(object sender, ProtoOASymbolByIdRes e)
        {
            SymbolByIdResponseEvent?.Invoke(sender, e);
        }

        public void OnSymbolChanged(object sender, ProtoOASymbolChangedEvent e)
        {
            SymbolChangedEvent?.Invoke(sender, e);
        }

        public void OnTraderResponse(object sender, ProtoOATraderRes e)
        {
            TraderResponseEvent?.Invoke(sender, e);
        }

        public void OnTraderUpdated(object sender, ProtoOATraderUpdatedEvent e)
        {
            TraderUpdatedEvent?.Invoke(sender, e);
        }

        public void OnTrailingSLChanged(object sender, ProtoOATrailingSLChangedEvent e)
        {
            TrailingSLChangedEvent?.Invoke(sender, e);
        }

        public void OnUnsubscribeSpotsResponse(object sender, ProtoOAUnsubscribeSpotsRes e)
        {
            UnsubscribeSpotsResponseEvent?.Invoke(sender, e);
        }

        public void OnVersionResponse(object sender, ProtoOAVersionRes e)
        {
            VersionResponseEvent?.Invoke(sender, e);
        }

        #endregion Methods
    }
}