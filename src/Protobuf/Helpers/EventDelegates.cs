using System;

namespace Connect.Protobuf
{
    public delegate void ExecutionEventHandler(Client client, ProtoOAExecutionEvent e);

    public delegate void SpotEventHandler(Client client, ProtoOASpotEvent e);

    public delegate void DepthQuotesEvnetHandler(Client client, ProtoOADepthEvent e);

    public delegate void ErrorHandler(Client client, ProtoOAErrorRes e);

    public delegate void HeartbeatEventHandler(Client client, ProtoHeartbeatEvent e);

    public delegate void OrderErrorEventHandler(Client client, ProtoOAOrderErrorEvent e);

    public delegate void MarginChangedEventHandler(Client client, ProtoOAMarginChangedEvent e);

    public delegate void ClientDisconnectedEventHandler(Client client, ProtoOAClientDisconnectEvent e);

    public delegate void TraderUpdatedEventHandler(Client client, ProtoOATraderUpdatedEvent e);

    public delegate void TrailingSLChangedEventHandler(Client client, ProtoOATrailingSLChangedEvent e);

    public delegate void AccountsTokenInvalidatedEventHandler(Client client, ProtoOAAccountsTokenInvalidatedEvent e);

    public delegate void ApplicationAuthResponseEventHandler(Client client, ProtoOAApplicationAuthRes e, string clientMsgId);

    public delegate void AccountAuthorizationResponseEventHandler(Client client, ProtoOAAccountAuthRes e, string clientMsgId);

    public delegate void DealListResponseEventHandler(Client client, ProtoOADealListRes e, string clientMsgId);

    public delegate void AssetListResponseEventHandler(Client client, ProtoOAAssetListRes e, string clientMsgId);

    public delegate void AssetClassListResponseEventHandler(Client client, ProtoOAAssetClassListRes e, string clientMsgId);

    public delegate void CashFlowHistoryListResponseEventHandler(Client client, ProtoOACashFlowHistoryListRes e, string clientMsgId);

    public delegate void ExpectedMarginResponseEventHandler(Client client, ProtoOAExpectedMarginRes e, string clientMsgId);

    public delegate void AccountListResponseEventHandler(Client client, ProtoOAGetAccountListByAccessTokenRes e, string clientMsgId);

    public delegate void TickDataResponseEventHandler(Client client, ProtoOAGetTickDataRes e, string clientMsgId);

    public delegate void TrendbarsResponseEventHandler(Client client, ProtoOAGetTrendbarsRes e, string clientMsgId);

    public delegate void ReconcileResponseEventHandler(Client client, ProtoOAReconcileRes e, string clientMsgId);

    public delegate void SubscribeSpotsResponseEventHandler(Client client, ProtoOASubscribeSpotsRes e, string clientMsgId);

    public delegate void SubscribeDepthQuotesResponseEventHandler(Client client, ProtoOASubscribeDepthQuotesRes e, string clientMsgId);

    public delegate void SymbolsForConversionResponseEventHandler(Client client, ProtoOASymbolsForConversionRes e, string clientMsgId);

    public delegate void SymbolsListResponseEventHandler(Client client, ProtoOASymbolsListRes e, string clientMsgId);

    public delegate void SymbolByIdResponseEventHandler(Client client, ProtoOASymbolByIdRes e, string clientMsgId);

    public delegate void SymbolChangedEventHandler(Client client, ProtoOASymbolChangedEvent e);

    public delegate void TraderResponseEventHandler(Client client, ProtoOATraderRes e, string clientMsgId);

    public delegate void UnsubscribeSpotsResponseEventHandler(Client client, ProtoOAUnsubscribeSpotsRes e, string clientMsgId);

    public delegate void UnsubscribeDepthQuotesResponseEventHandler(Client client, ProtoOAUnsubscribeDepthQuotesRes e, string clientMsgId);

    public delegate void VersionResponseEventHandler(Client client, ProtoOAVersionRes e, string clientMsgId);

    public delegate void CtidProfileResponseEventHandler(Client client, ProtoOAGetCtidProfileByTokenRes e, string clientMsgId);

    public delegate void SymbolCategoryListResponseEventHandler(Client client, ProtoOASymbolCategoryListRes e, string clientMsgId);

    public delegate void MessageReceivedEventHandler(Client client, ProtoMessage e);

    public delegate void ExceptionEventHandler(Client client, Exception ex);

    public delegate void AccountLogoutResponseEventHandler(Client client, ProtoOAAccountLogoutRes e, string clientMsgId);
}