using Leopotam.Ecs;
using UnityEngine;

public class NpcHealthSystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<NpcHealthComponent> _healthFilter = null;

    public void Init()
    {
        foreach (var i in _healthFilter)
        {
            ref var health = ref _healthFilter.Get1(i);
            health.Health = 100;
            health.Armor = 100;
        }
    }

    public void Run()
    {
        foreach (var i in _healthFilter)
        {
            ref var health = ref _healthFilter.Get1(i);
            Debug.Log(health.Health);
            if (health.Health < 1)
            {
                health.Health = 100;
                
            }
        }
    }
}
