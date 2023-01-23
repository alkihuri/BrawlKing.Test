using Leopotam.Ecs;
using UnityEngine;
using DG.Tweening;

public class PlayerShootingSystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<GunComponent,PlayerDataComponent> _shootFilter = null;


    public void Init()
    {
        foreach (var i in _shootFilter)
        {
            ref var gunComponent = ref _shootFilter.Get1(i);
            ref var holder = ref _shootFilter.Get2(i);
            gunComponent.gun = new SimpleGun();
            gunComponent.gun.GunBinding(holder);
        }
    }
    public void Run()
    {
        foreach (var i in _shootFilter)
        {
            ref var gunComponent = ref _shootFilter.Get1(i);
            ref var holder = ref _shootFilter.Get2(i);
            if (gunComponent.IsShoot)
            {
                gunComponent.gun.DoAttack();
                holder.Player.transform.DOShakeScale(0.1f);
            }
        }
    } 
}
