
using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FightSystem : IReactiveSystem, ISetPool {
    private Group group;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Fighting.OnEntityAddedOrRemoved();
        }
    }

    public void Execute(List<Entity> entities)
    {

        foreach (var e in group.GetEntities())
        {
            //Test
            if(e.hasHealth)
            {
                Debug.Log(e.health.value);
                if (e.hasDamageTaken)
                {
                    e.ReplaceDamageTaken(e.damageTaken.value + 10);
                }
                else
                {
                    e.AddDamageTaken(10);
                }
                Debug.Log(e.health.value);
            }
        }
    }

    public void SetPool(Pool pool)
    {
        group = pool.GetGroup(Matcher.AllOf(Matcher.Fighting));
    }
}
