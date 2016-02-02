using System;
using System.Collections.Generic;
using Entitas;

public class HealthSystem : IReactiveSystem, ISetPool
{
    private Group _group;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.DamageTaken.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in _group.GetEntities())
        {
            e.ReplaceHealth(e.health.value - e.damageTaken.value);
            e.RemoveDamageTaken();
        }
    }

    public void SetPool(Pool pool)
    {
        _group = pool.GetGroup(Matcher.AllOf(Matcher.DamageTaken));
    }
}
