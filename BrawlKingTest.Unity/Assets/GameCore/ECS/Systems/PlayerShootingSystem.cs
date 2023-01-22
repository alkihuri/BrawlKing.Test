using Leopotam.Ecs;
using UnityEngine;

public class PlayerShootingSystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<GunComponent> _shootFilter = null;



    public void Run()
    {
        foreach (var i in _shootFilter)
        {
            ref var gunComponent = ref _shootFilter.Get1(i);
            Debug.Log(gunComponent.IsShoot);
            if (gunComponent.IsShoot)
            {
                DoAttack(gunComponent.gun);
            }
        }
    }


    public void DoAttack(IGun gun)
    {
        gun.DoAttack();
    }

    public void Init()
    {
        foreach (var i in _shootFilter)
        {
            ref var gunComponent = ref _shootFilter.Get1(i);
            gunComponent.gun = new SimpleGun();
        }
    }
}
