﻿using Leopotam.Ecs;

public class PlayerHealthSystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<PlayerHealthComponent> _healthFilter = null;

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
            if(health.Health<100)
            {
                ///Die!;
            }
        }
    }
}
