using System;
using AlgoZone.Core.EventData;

namespace AlgoZone.Agent.Businesslayer.Agent.Instances
{
    public class TestAgent : IAgentInstance
    {
        #region Methods

        /// <inheritdoc />
        public void Execute(IEventData eventData)
        {
            var tick = (SymbolTickEventData)eventData;
            Console.WriteLine($"[{tick.Data.Symbol}] Tick: {tick.Data.BidPrice}:{tick.Data.AskPrice} {tick.Data.BidQuantity}:{tick.Data.AskQuantity}");
        }

        #endregion
    }
}