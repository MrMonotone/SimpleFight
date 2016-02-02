using UnityEngine;
using Entitas;
using Entitas.Unity.VisualDebugging;

public class GameManager : MonoBehaviour
{

    Systems systems;

    void Start()
    {
        systems = createSystems(Pools.pool);
        systems.Initialize();
    }

    void Update()
    {
        systems.Execute();
    }

    Systems createSystems(Pool pool)
    {
#if (UNITY_EDITOR)
        return new DebugSystems()
#else
        return new Systems()
#endif

            // Initialize
            .Add(pool.CreateCreatePlayerSystem())

            // Input
            .Add(pool.CreateInputSystem())

            // Update
            .Add(pool.CreateHealthSystem())
            .Add(pool.CreateFightSystem());

            // Destroy
    }
}