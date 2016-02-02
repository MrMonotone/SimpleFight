using Entitas;
using UnityEngine;


public class InputSystem : IExecuteSystem, ISetPool
{
    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.F))
            _pool.fightingEntity.AddDamageTaken(0);
    }
}
