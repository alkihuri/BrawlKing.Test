using Leopotam.Ecs;
using DG.Tweening;
using UnityEngine;

public class CollisionSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<CollistionComponent> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var collision = ref _filter.Get1(i);

            if (collision.Reciever == null)
                return;


            Debug.Log("Коллизия!" + collision.Reciever.name);
            collision.Reciever.GetComponent<IHealthComponent>().TakeDamage(10);
            collision.Reciever.transform.DOShakeScale(1);

        }
    }
}