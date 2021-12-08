using AlgoZone.Agent.Businesslayer.Agent;

namespace AlgoZone.Agent.Businesslayer.Dispatcher
{
    public interface IDispatchManager
    {
        #region Methods

        void AddInstance(string symbol, IAgentInstance agent);

        IAgentInstance GetInstance(string symbol);

        #endregion
    }
}