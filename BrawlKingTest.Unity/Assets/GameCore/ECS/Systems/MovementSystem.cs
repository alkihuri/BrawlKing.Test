using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class MovementSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<ObjectDataComponent, MovableComponent, DirectionComponent> moveFilter = null;



    public void Run()
    {
        foreach (var i in moveFilter)
        {

            ref var gameobject = ref moveFilter.Get1(i).Player;
            ref var characterController = ref moveFilter.Get2(i).CharacterController;
            ref var direction = ref moveFilter.Get3(i).MoveDirection; 
            characterController.SimpleMove(direction);
        }
    }
}
