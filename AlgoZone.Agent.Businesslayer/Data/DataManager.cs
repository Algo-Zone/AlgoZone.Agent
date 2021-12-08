using System;
using AlgoZone.Agent.Datalayer.RabbitMQ;
using AlgoZone.Core.EventData;

namespace AlgoZone.Agent.Businesslayer.Data
{
    public class DataManager : IDataManager
    {
        #region Fields

        private readonly RabbitMqDal _dal;

        #endregion

        #region Constructors

        public DataManager()
        {
            _dal = new RabbitMqDal("localhost");
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public void StartCollectingOrderBookEventData(Action<SymbolOrderBookEventData> orderBookEventHandler)
        {
            return;
        }

        /// <inheritdoc />
        public void StartCollectingTickEventData(Action<SymbolTickEventData> tickEventHandler)
        {
            try
            {
                _dal.Subscribe(tickEventHandler);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong. Please try again later. {e}");
            }
        }

        #endregion
    }
}