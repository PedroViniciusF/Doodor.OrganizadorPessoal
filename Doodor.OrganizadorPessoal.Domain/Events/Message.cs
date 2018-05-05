using Flunt.Notifications;
using System;

namespace Doodor.OrganizadorPessoal.Domain.Events
{
    public class Message : Notifiable
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }       
    }
}
