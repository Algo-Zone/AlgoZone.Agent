using System;
using System.Threading;
using AlgoZone.Agent.Businesslayer.Agent;
using AlgoZone.Agent.Businesslayer.Data;
using AlgoZone.Agent.Businesslayer.Dispatcher;

namespace AlgoZone.Agent
{
    public static class Program
    {
        
        private static readonly ManualResetEvent QuitEvent = new ManualResetEvent(false);
        #region Methods

        #region Static Methods

        public static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, eArgs) =>
            {
                QuitEvent.Set();
                eArgs.Cancel = true;
            };
            
            var dataManager = new DataManager();
            var dispatchManager = new DispatchManager();
            var agentManager = new AgentManager(dataManager, dispatchManager);
            agentManager.Start();
            
            QuitEvent.WaitOne();
        }

        #endregion

        #endregion
    }
}