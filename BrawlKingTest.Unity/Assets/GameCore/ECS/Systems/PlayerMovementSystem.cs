using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class PlayerMovementSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<MovableComponent, MoveDirectionComponent> moveFilter = null;



    public void Run()
    {
        foreach (var i in moveFilter)
        {

            ref var characterController = ref moveFilter.Get1(i).CharacterController;
            ref var direction = ref moveFilter.Get2(i).MoveDirection; 
            characterController.SimpleMove(direction);
        }
    }
}
