using System;
using AlgoZone.Core.EventData;

namespace AlgoZone.Agent.Businesslayer.Data
{
    public interface IDataManager
    {
        #region Methods

        void StartCollectingOrderBookEventData(Action<SymbolOrderBookEventData> orderBookEventHandler);

        void StartCollectingTickEventData(Action<SymbolTickEventData> tickEventHandler);

        #endregion
    }
}