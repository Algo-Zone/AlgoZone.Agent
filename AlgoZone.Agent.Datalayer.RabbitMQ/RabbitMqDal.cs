using System;
using AlgoZone.Core.EventData;
using EasyNetQ;

namespace AlgoZone.Agent.Datalayer.RabbitMQ
{
    public class RabbitMqDal : IDisposable
    {
        #region Fields

        private readonly IBus _bus;

        #endregion

        #region Constructors

        public RabbitMqDal(string hostname)
        {
            _bus = RabbitHutch.CreateBus($"host={hostname}");
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public void Dispose()
        {
            _bus.Dispose();
        }

        public void Subscribe<TEventData>(Action<TEventData> eventHandler)
            where TEventData : IEventData
        {
            _bus.PubSub.Subscribe(Guid.NewGuid().ToString(), eventHandler);
        }

        #endregion
    }
}