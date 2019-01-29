using Connect.Common;
using System;

namespace Connect.Protobuf
{
    public class Events
    {
        #region Delegates

        public delegate void ExecutionEventHandler(object sender, ProtoOAExecutionEvent e);

        public delegate void SpotEventHandler(object sender, ProtoOASpotEvent e);

        public delegate void ErrorHandler(object sender, ProtoOAErrorRes e);

        public delegate void HeartbeatEventHandler(object sender, ProtoHeartbeatEvent e);

        public delegate void OrderErrorEventHandler(object sender, ProtoOAOrderErrorEvent e);

        public delegate void MarginChangedEventHandler(object sender, ProtoOAMarginChangedEvent e);

        public delegate void ClientDisconnectedEventHandler(object sender, ProtoOAClientDisconnectEvent e);

        public delegate void TraderUpdatedEventHandler(object sender, ProtoOATraderUpdatedEvent e);

        public delegate void TrailingSLChangedEventHandler(object sender, ProtoOATrailingSLChangedEvent e);

        public delegate void AccountsTokenInvalidatedEventHandler(object sender, ProtoOAAccountsTokenInvalidatedEvent e);

        public delegate void ApplicationAuthResponseEventHandler(object sender, ProtoOAApplicationAuthRes e, string clientMsgId);

        public delegate void AccountAuthorizationResponseEventHandler(object sender, ProtoOAAccountAuthRes e, string clientMsgId);

        public delegate void DealListResponseEventHandler(object sender, ProtoOADealListRes e, string clientMsgId);

        public delegate void AssetListResponseEventHandler(object sender, ProtoOAAssetListRes e, string clientMsgId);

        public delegate void CashFlowHistoryListResponseEventHandler(object sender, ProtoOACashFlowHistoryListRes e, string clientMsgId);

        public delegate void ExpectedMarginResponseEventHandler(object sender, ProtoOAExpectedMarginRes e, string clientMsgId);

        public delegate void AccountListResponseEventHandler(object sender, ProtoOAGetAccountListByAccessTokenRes e, string clientMsgId);

        public delegate void GetTickDataResponseEventHandler(object sender, ProtoOAGetTickDataRes e, string clientMsgId);

        public delegate void GetTrendbarsResponseEventHandler(object sender, ProtoOAGetTrendbarsRes e, string clientMsgId);

        public delegate void ReconcileResponseEventHandler(object sender, ProtoOAReconcileRes e, string clientMsgId);

        public delegate void SubscribeSpotsResponseEventHandler(object sender, ProtoOASubscribeSpotsRes e, string clientMsgId);

        public delegate void SymbolsForConversionResponseEventHandler(object sender, ProtoOASymbolsForConversionRes e, string clientMsgId);

        public delegate void SymbolsListResponseEventHandler(object sender, ProtoOASymbolsListRes e, string clientMsgId);

        public delegate void SymbolByIdResponseEventHandler(object sender, ProtoOASymbolByIdRes e, string clientMsgId);

        public delegate void SymbolChangedEventHandler(object sender, ProtoOASymbolChangedEvent e);

        public delegate void TraderResponseEventHandler(object sender, ProtoOATraderRes e, string clientMsgId);

        public delegate void UnsubscribeSpotsResponseEventHandler(object sender, ProtoOAUnsubscribeSpotsRes e, string clientMsgId);

        public delegate void VersionResponseEventHandler(object sender, ProtoOAVersionRes e, string clientMsgId);

        public delegate void CtidProfileResponseEventHandler(object sender, ProtoOAGetCtidProfileByTokenRes e, string clientMsgId);

        public delegate void SymbolCategoryListResponseEventHandler(object sender, ProtoOASymbolCategoryListRes e, string clientMsgId);

        public delegate void MessageReceivedEventHandler(object sender, ProtoMessage e);

        public delegate void HeartbeatSendingExceptionEventHandler(object sender, Exception ex);

        public delegate void ListenerExceptionEventHandler(object sender, Exception ex);

        #endregion Delegates

        #region Events

        public event ApplicationAuthResponseEventHandler ApplicationAuthResponseEvent;

        public event ExecutionEventHandler ExecutionEvent;

        public event SpotEventHandler SpotEvent;

        public event ErrorHandler ErrorEvent;

        public event ListenerExceptionEventHandler ListenerExceptionEvent;

        public event HeartbeatSendingExceptionEventHandler HeartbeatSendingExceptionEvent;

        public event HeartbeatEventHandler HeartbeatEvent;

        public event AccountAuthorizationResponseEventHandler AccountAuthorizationResponseEvent;

        public event ClientDisconnectedEventHandler ClientDisconnectedEvent;

        public event DealListResponseEventHandler DealListResponseEvent;

        public event AssetListResponseEventHandler AssetListResponseEvent;

        public event AccountsTokenInvalidatedEventHandler AccountsTokenInvalidatedEvent;

        public event CashFlowHistoryListResponseEventHandler CashFlowHistoryListResponseEvent;

        public event ExpectedMarginResponseEventHandler ExpectedMarginResponseEvent;

        public event AccountListResponseEventHandler AccountListResponseEvent;

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

        public event MessageReceivedEventHandler MessageReceivedEvent;

        public event CtidProfileResponseEventHandler CtidProfileResponseEvent;

        public event SymbolCategoryListResponseEventHandler SymbolCategoryListResponseEvent;

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

        public void OnApplicationAuthResponse(object sender, ProtoOAApplicationAuthRes e, string clientMsgId)
        {
            ApplicationAuthResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnListenerException(object sender, Exception ex)
        {
            ListenerExceptionEvent?.Invoke(sender, ex);
        }

        public void OnHeartbeatSendingException(object sender, Exception ex)
        {
            HeartbeatSendingExceptionEvent?.Invoke(sender, ex);
        }

        public void OnHeartbeat(object sender, ProtoHeartbeatEvent e)
        {
            HeartbeatEvent?.Invoke(sender, e);
        }

        public void OnAccountAuthorizationResponse(object sender, ProtoOAAccountAuthRes e, string clientMsgId)
        {
            AccountAuthorizationResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnClientDisconnected(object sender, ProtoOAClientDisconnectEvent e)
        {
            ClientDisconnectedEvent?.Invoke(sender, e);
        }

        public void OnDealListResponse(object sender, ProtoOADealListRes e, string clientMsgId)
        {
            DealListResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnAssetListResponse(object sender, ProtoOAAssetListRes e, string clientMsgId)
        {
            AssetListResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnAccountsTokenInvalidated(object sender, ProtoOAAccountsTokenInvalidatedEvent e)
        {
            AccountsTokenInvalidatedEvent?.Invoke(sender, e);
        }

        public void OnCashFlowHistoryListResponse(object sender, ProtoOACashFlowHistoryListRes e, string clientMsgId)
        {
            CashFlowHistoryListResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnExpectedMarginResponse(object sender, ProtoOAExpectedMarginRes e, string clientMsgId)
        {
            ExpectedMarginResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnAccountListResponse(object sender, ProtoOAGetAccountListByAccessTokenRes e, string clientMsgId)
        {
            AccountListResponseEvent.Invoke(sender, e, clientMsgId);
        }

        public void OnGetTickDataResponse(object sender, ProtoOAGetTickDataRes e, string clientMsgId)
        {
            GetTickDataResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnGetTrendbarsResponse(object sender, ProtoOAGetTrendbarsRes e, string clientMsgId)
        {
            GetTrendbarsResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnMarginChanged(object sender, ProtoOAMarginChangedEvent e)
        {
            MarginChangedEvent?.Invoke(sender, e);
        }

        public void OnOrderError(object sender, ProtoOAOrderErrorEvent e)
        {
            OrderErrorEvent?.Invoke(sender, e);
        }

        public void OnReconcileResponse(object sender, ProtoOAReconcileRes e, string clientMsgId)
        {
            ReconcileResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnSubscribeSpotsResponse(object sender, ProtoOASubscribeSpotsRes e, string clientMsgId)
        {
            SubscribeSpotsResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnSymbolsForConversionResponse(object sender, ProtoOASymbolsForConversionRes e, string clientMsgId)
        {
            SymbolsForConversionResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnSymbolsListResponse(object sender , ProtoOASymbolsListRes e, string clientMsgId)
        {
            SymbolsListResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnSymbolByIdResponse(object sender, ProtoOASymbolByIdRes e, string clientMsgId)
        {
            SymbolByIdResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnSymbolChanged(object sender, ProtoOASymbolChangedEvent e)
        {
            SymbolChangedEvent?.Invoke(sender, e);
        }

        public void OnTraderResponse(object sender, ProtoOATraderRes e, string clientMsgId)
        {
            TraderResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnTraderUpdated(object sender, ProtoOATraderUpdatedEvent e)
        {
            TraderUpdatedEvent?.Invoke(sender, e);
        }

        public void OnTrailingSLChanged(object sender, ProtoOATrailingSLChangedEvent e)
        {
            TrailingSLChangedEvent?.Invoke(sender, e);
        }

        public void OnUnsubscribeSpotsResponse(object sender, ProtoOAUnsubscribeSpotsRes e, string clientMsgId)
        {
            UnsubscribeSpotsResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnVersionResponse(object sender, ProtoOAVersionRes e, string clientMsgId)
        {
            VersionResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnCtidProfileResponse(object sender, ProtoOAGetCtidProfileByTokenRes e, string clientMsgId)
        {
            CtidProfileResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnSymbolCategoryListResponse(object sender, ProtoOASymbolCategoryListRes e, string clientMsgId)
        {
            SymbolCategoryListResponseEvent?.Invoke(sender, e, clientMsgId);
        }

        public void OnMessageReceived(object sender, ProtoMessage e)
        {
            MessageReceivedEvent?.Invoke(sender, e);
        }

        #endregion Methods
    }
}