using Connect.Common;
using System;

namespace Connect.Trading
{
    public class Events
    {
        #region Delegates

        public delegate void AuthorizedHandler(object sender);

        public delegate void ExecutionEventHandler(object sender, ProtoOAExecutionEvent e);

        public delegate void SpotEventHandler(object sender, ProtoOASpotEvent e);

        public delegate void ErrorHandler(object sender, EventArgs.ErrorEventArgs e);

        public delegate void ExceptionHandler(object sender, Exception ex);

        #endregion Delegates

        #region Events

        public event AuthorizedHandler AuthorizedEvent;

        public event ExecutionEventHandler ExecutionEvent;

        public event ExecutionEventHandler MarketOrderOpenedEvent;

        public event ExecutionEventHandler ProtectionCanceledEvent;

        public event ExecutionEventHandler MarketRangeOrderOpenedEvent;

        public event ExecutionEventHandler LimitOrderPlacedEvent;

        public event ExecutionEventHandler LimitOrderCanceledEvent;

        public event ExecutionEventHandler LimitOrderAmendedEvent;

        public event ExecutionEventHandler LimitOrderFilledEvent;

        public event ExecutionEventHandler LimitOrderCancelRejectedEvent;

        public event ExecutionEventHandler StopOrderPlacedEvent;

        public event ExecutionEventHandler StopOrderCanceledEvent;

        public event ExecutionEventHandler StopOrderAmendedEvent;

        public event ExecutionEventHandler StopOrderFilledEvent;

        public event ExecutionEventHandler PositionClosedEvent;

        public event ExecutionEventHandler PositionAmendedEvent;

        public event SpotEventHandler SpotEvent;

        public event ErrorHandler ErrorEvent;

        public event ExecutionEventHandler StopLimitOrderPlacedEvent;

        public event ExecutionEventHandler StopLimitOrderAmendedEvent;

        public event ExecutionEventHandler StopLimitOrderCanceledEvent;

        public event ExecutionEventHandler ProtectionCancelRejectedEvent;

        public event ExecutionEventHandler StopOrderCancelRejectedEvent;

        public event ExecutionEventHandler StopLimitOrderCancelRejectedEvent;

        public event ExecutionEventHandler LimitOrderExpiredEvent;

        public event ExecutionEventHandler StopOrderExpiredEvent;

        public event ExecutionEventHandler StopLimitOrderExpiredEvent;

        public event ExecutionEventHandler StopLimitOrderFilledEvent;

        public event ExecutionEventHandler LimitOrderRejectedEvent;

        public event ExecutionEventHandler MarketOrderRejectedEvent;

        public event ExecutionEventHandler MarketRangeOrderRejectedEvent;

        public event ExecutionEventHandler ProtectionRejectedEvent;

        public event ExecutionEventHandler StopOrderRejectedEvent;

        public event ExecutionEventHandler StopLimitOrderRejectedEvent;

        public event ExceptionHandler ListenerStoppedEvent;

        public event ExceptionHandler HeartbeatSendingStoppedEvent;

        #endregion Events

        #region Methods

        public void OnExecutionEvent(object sender, ProtoOAExecutionEvent executionEvent)
        {
            ExecutionEvent?.Invoke(sender, executionEvent);

            switch (executionEvent.ExecutionType)
            {
                case ProtoOAExecutionType.OA_ORDER_ACCEPTED:
                    {
                        OnOrderAccepted(sender, executionEvent);

                        break;
                    }
                case ProtoOAExecutionType.OA_ORDER_AMENDED:
                    {
                        OnOrderAmended(sender, executionEvent);

                        break;
                    }
                case ProtoOAExecutionType.OA_ORDER_CANCELLED:
                    {
                        OnOrderCanceled(sender, executionEvent);

                        break;
                    }
                case ProtoOAExecutionType.OA_ORDER_CANCEL_REJECTED:
                    {
                        OnOrderCancelRejected(sender, executionEvent);

                        break;
                    }
                case ProtoOAExecutionType.OA_ORDER_EXPIRED:
                    {
                        OnOrderExpired(sender, executionEvent);

                        break;
                    }
                case ProtoOAExecutionType.OA_ORDER_FILLED:
                    {
                        OnOrderFilled(sender, executionEvent);

                        break;
                    }
                case ProtoOAExecutionType.OA_ORDER_REJECTED:
                    {
                        OnOrderRejected(sender, executionEvent);

                        break;
                    }
                default:
                    break;
            }
        }

        public void OnOrderAccepted(object sender, ProtoOAExecutionEvent executionEvent)
        {
            switch (executionEvent.Order.OrderType)
            {
                case ProtoOAOrderType.OA_LIMIT:
                    {
                        LimitOrderPlacedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_STOP:
                    {
                        StopOrderPlacedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_STOP_LIMIT:
                    {
                        StopLimitOrderPlacedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                default:
                    break;
            }
        }

        public void OnOrderAmended(object sender, ProtoOAExecutionEvent executionEvent)
        {
            switch (executionEvent.Order.OrderType)
            {
                case ProtoOAOrderType.OA_LIMIT:
                    {
                        LimitOrderAmendedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_PROTECTION:
                    {
                        PositionAmendedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_STOP:
                    {
                        StopOrderAmendedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_STOP_LIMIT:
                    {
                        StopLimitOrderAmendedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                default:
                    break;
            }
        }

        public void OnOrderCanceled(object sender, ProtoOAExecutionEvent executionEvent)
        {
            switch (executionEvent.Order.OrderType)
            {
                case ProtoOAOrderType.OA_LIMIT:
                    {
                        LimitOrderCanceledEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_PROTECTION:
                    {
                        ProtectionCanceledEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_STOP:
                    {
                        StopOrderCanceledEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_STOP_LIMIT:
                    {
                        StopLimitOrderCanceledEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                default:
                    break;
            }
        }

        public void OnOrderCancelRejected(object sender, ProtoOAExecutionEvent executionEvent)
        {
            switch (executionEvent.Order.OrderType)
            {
                case ProtoOAOrderType.OA_LIMIT:
                    {
                        LimitOrderCancelRejectedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_PROTECTION:
                    {
                        ProtectionCancelRejectedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_STOP:
                    {
                        StopOrderCancelRejectedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_STOP_LIMIT:
                    {
                        StopLimitOrderCancelRejectedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                default:
                    break;
            }
        }

        public void OnOrderExpired(object sender, ProtoOAExecutionEvent executionEvent)
        {
            switch (executionEvent.Order.OrderType)
            {
                case ProtoOAOrderType.OA_LIMIT:
                    {
                        LimitOrderExpiredEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_STOP:
                    {
                        StopOrderExpiredEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_STOP_LIMIT:
                    {
                        StopLimitOrderExpiredEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                default:
                    break;
            }
        }

        public void OnOrderFilled(object sender, ProtoOAExecutionEvent executionEvent)
        {
            switch (executionEvent.Order.OrderType)
            {
                case ProtoOAOrderType.OA_LIMIT:
                    {
                        LimitOrderFilledEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_MARKET:
                    {
                        if (!executionEvent.Order.ClosingOrder)
                        {
                            MarketOrderOpenedEvent?.Invoke(sender, executionEvent);
                        }
                        else
                        {
                            PositionClosedEvent?.Invoke(sender, executionEvent);
                        }

                        break;
                    }
                case ProtoOAOrderType.OA_MARKET_RANGE:
                    {
                        if (!executionEvent.Order.ClosingOrder)
                        {
                            MarketRangeOrderOpenedEvent?.Invoke(sender, executionEvent);
                        }
                        else
                        {
                            PositionClosedEvent?.Invoke(sender, executionEvent);
                        }

                        break;
                    }
                case ProtoOAOrderType.OA_STOP:
                    {
                        StopOrderFilledEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_STOP_LIMIT:
                    {
                        StopLimitOrderFilledEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                default:
                    break;
            }
        }

        public void OnOrderRejected(object sender, ProtoOAExecutionEvent executionEvent)
        {
            switch (executionEvent.Order.OrderType)
            {
                case ProtoOAOrderType.OA_LIMIT:
                    {
                        LimitOrderRejectedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_MARKET:
                    {
                        MarketOrderRejectedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_MARKET_RANGE:
                    {
                        MarketRangeOrderRejectedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_PROTECTION:
                    {
                        ProtectionRejectedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_STOP:
                    {
                        StopOrderRejectedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                case ProtoOAOrderType.OA_STOP_LIMIT:
                    {
                        StopLimitOrderRejectedEvent?.Invoke(sender, executionEvent);

                        break;
                    }
                default:
                    break;
            }
        }

        public void OnSpotEvent(object sender, ProtoOASpotEvent spotEvent)
        {
            SpotEvent?.Invoke(sender, spotEvent);
        }

        public void OnError(object sender, ProtoErrorRes errorRes)
        {
            ErrorCode errorCode = ErrorCode.None;

            Enum.TryParse(errorRes.ErrorCode, true, out errorCode);

            EventArgs.ErrorEventArgs errorEventArgs = new EventArgs.ErrorEventArgs()
            {
                Description = errorRes.Description,
                ErrorCode = errorCode
            };

            ErrorEvent?.Invoke(sender, errorEventArgs);
        }

        public void OnAuthorized(object sender)
        {
            AuthorizedEvent?.Invoke(sender);
        }

        public void OnListenerStopped(object sender, Exception ex)
        {
            ListenerStoppedEvent?.Invoke(sender, ex);
        }

        public void OnHeartbeatSendingStopped(object sender, Exception ex)
        {
            HeartbeatSendingStoppedEvent?.Invoke(sender, ex);
        }

        #endregion Methods
    }
}