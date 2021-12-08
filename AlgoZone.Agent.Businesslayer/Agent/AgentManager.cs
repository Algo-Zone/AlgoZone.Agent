using AlgoZone.Agent.Businesslayer.Agent.Instances;
using AlgoZone.Agent.Businesslayer.Data;
using AlgoZone.Agent.Businesslayer.Dispatcher;
using AlgoZone.Core.EventData;

namespace AlgoZone.Agent.Businesslayer.Agent
{
    public class AgentManager : IAgentManager
    {
        #region Fields

        private readonly IDataManager _dataManager;

        private readonly IDispatchManager _dispatchManager;

        #endregion

        #region Constructors

        public AgentManager(IDataManager dataManager, IDispatchManager dispatchManager)
        {
            _dataManager = dataManager;
            _dispatchManager = dispatchManager;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public void Start()
        {
            _dataManager.StartCollectingTickEventData(TickEventDataProcessor);
            _dataManager.StartCollectingOrderBookEventData(OrderBookEventDataProcessor);
        }

        private void OrderBookEventDataProcessor(SymbolOrderBookEventData eventData) { }

        private void TickEventDataProcessor(SymbolTickEventData eventData)
        {
            var agentInstance = _dispatchManager.GetInstance(eventData.Data.Symbol);
            if (agentInstance == null)
            {
                _dispatchManager.AddInstance(eventData.Data.Symbol, new TestAgent());
                return;
            }
            
            agentInstance.Execute(eventData);
        }

        #endregion
    }
}