using System.Collections.Generic;
using AlgoZone.Agent.Businesslayer.Agent;

namespace AlgoZone.Agent.Businesslayer.Dispatcher
{
    public class DispatchManager : IDispatchManager
    {
        #region Fields

        private readonly IDictionary<string, IAgentInstance> _agents;

        #endregion

        #region Constructors

        public DispatchManager()
        {
            _agents = new Dictionary<string, IAgentInstance>();
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public void AddInstance(string symbol, IAgentInstance agent)
        {
            _agents.Add(symbol, agent);
        }

        /// <inheritdoc />
        public IAgentInstance GetInstance(string symbol)
        {
            return !_agents.ContainsKey(symbol) ? null : _agents[symbol];
        }

        #endregion
    }
}