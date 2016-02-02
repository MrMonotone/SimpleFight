using Entitas;

public class CreatePlayerSystem : IInitializeSystem, ISetPool
{
    Pool pool;

    public void SetPool(Pool pool)
    {
        this.pool = pool;
    }

    public void Initialize()
    {
        this.pool.CreateEntity()
            .IsFighting(true)
            .AddHealth(100);
    }
}
