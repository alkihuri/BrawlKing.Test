using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartSystem : IEcsInitSystem
{
    EcsWorld _world = null;
    public void Init()
    {
        var player = _world.NewEntity();
        ref var ojectData = ref player.Get<ObjectDataComponent>();
        ref var movable = ref player.Get<MovableComponent>();
        var direction = player.Get<MoveDirectionComponent>();
        var rotation = player.Get<RotateDirectionComponent>();
        var shooting = player.Get<GunComponent>();
        var health = player.Get<PlayerHealthComponent>();



        ojectData.Player = DataProvider.Instance.Payer;
        movable.CharacterController = DataProvider.Instance.CharacterController;
    }
}
