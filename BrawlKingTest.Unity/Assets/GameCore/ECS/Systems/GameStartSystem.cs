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
        var ojectData = player.Get<ObjectDataComponent>();
        var movable = player.Get<MovableComponent>();
        var direction = player.Get<DirectionComponent>();

        ojectData.Player = DataProvider.Instance.Payer; 
        movable.CharacterController = DataProvider.Instance.CharacterController;
    }
}
