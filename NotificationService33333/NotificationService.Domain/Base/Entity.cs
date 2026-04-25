using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.Base;

public abstract class Entity<TId> where TId : struct, IEquatable<TId>
{
    public TId Id { get; }
    protected Entity(TId id) => Id = id;
    protected Entity() { }
}
