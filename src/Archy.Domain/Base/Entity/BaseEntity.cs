using System;

namespace Archy.Domain.Base.Entity;

public class BaseEntity
{
    public required Guid Id {get; init;}
    public required string Name {get; init;}
}
