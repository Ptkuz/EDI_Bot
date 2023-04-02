using Gurrex.Common.Interfaces.Entities;
using System.ComponentModel.DataAnnotations;

namespace Gurrex.Common.DAL.Entities
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public class Entity : IEntity
    {
        /// <summary>
        /// Id сущности
        /// </summary>
        [Key]
        public Guid Id { get; set; }
    }
}
