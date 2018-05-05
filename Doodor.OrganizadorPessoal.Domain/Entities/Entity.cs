using Flunt.Notifications;
using System;
using System.ComponentModel.DataAnnotations;

namespace Doodor.OrganizadorPessoal.Domain.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            UltimaAlteracao = DateTime.Now;
        }
        /// <summary>
        /// Id único da propriedade
        /// </summary>
        [Key]
        public Guid Id { get; protected set; }        
        public DateTime UltimaAlteracao { get; set; }
    }
}
