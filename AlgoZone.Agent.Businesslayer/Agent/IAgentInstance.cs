using AlgoZone.Core.EventData;

namespace AlgoZone.Agent.Businesslayer.Agent
{
    public interface IAgentInstance
    {
        #region Methods

        void Execute(IEventData eventData);

        #endregion
    }
}