using Leopotam.Ecs;

public class PlayerHealthSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<PlayerHealthComponent> _healthFilter = null;
     
    public void Run()
    {
        foreach (var i in _healthFilter)
        { 
            ref var health = ref _healthFilter.Get1(i);  
        }
    }
}
