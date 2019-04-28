using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf
{
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

    public delegate void TickDataResponseEventHandler(object sender, ProtoOAGetTickDataRes e, string clientMsgId);

    public delegate void TrendbarsResponseEventHandler(object sender, ProtoOAGetTrendbarsRes e, string clientMsgId);

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
}
