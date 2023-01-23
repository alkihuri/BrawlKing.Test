using Leopotam.Ecs;
using DG.Tweening;
using UnityEngine;

public class CollisionSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<CollistionComponent> _filter = null;

    private readonly EcsFilter<NpcHealthComponent, NpcDataComponent> _npcFilter = null;


    private readonly EcsFilter<PlayerHealthComponent, PlayerDataComponent> _playerHealthFilter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var collision = ref _filter.Get1(i);
            if (collision.Reciever != null && collision.Sender != null)
            {
                var reciever = collision.Reciever;
                var sender = collision.Sender;
                if (reciever.tag != sender.tag)
                {
                    ref var entity = ref _filter.GetEntity(i);

                    if (reciever.tag.Equals("Player"))
                    {
                        foreach (var j in _playerHealthFilter)
                        {
                            ref var data = ref _playerHealthFilter.Get1(j);
                            data.Health--;
                        }
                        //Debug.Log(health.Health);
                    }



                    if (reciever.tag.Equals("NPC"))
                    {


                        foreach (var j in _npcFilter)
                        {
                            ref var npchealth = ref _npcFilter.Get1(j);
                            npchealth.TakeDamage(1);
                        }



                        collision.Reciever.transform.DOShakeScale(1).OnComplete(() => Respawn(reciever));


                    }


                    if (entity.Has<CollistionComponent>())
                        entity.Del<CollistionComponent>();
                }
            }




        }
    }

    private void Respawn(GameObject collosion)
    {
        collosion.transform.position = new Vector3(-199, 3, 5);

        foreach (var i in _playerHealthFilter)
        {
            ref var data = ref _playerHealthFilter.Get2(i);
            data.Scores++;
        }
    }
}


