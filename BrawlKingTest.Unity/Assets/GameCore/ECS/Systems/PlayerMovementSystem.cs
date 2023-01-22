using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class PlayerMovementSystem : IEcsInitSystem, IEcsRunSystem
{
    private const int MAX_SPEED = 15;

    private readonly EcsWorld _world = null;
    private readonly EcsFilter<MovableComponent, MoveDirectionComponent, PlayerDataComponent> moveFilter = null;
    private float _speed;

    public float Speed { get => _speed; set => _speed = value; }

    private GameObject _player;

    public void Init()
    {
        foreach (var i in moveFilter)
        { 
            Speed = moveFilter.Get1(i).Speed;
            _player = moveFilter.Get3(i).Player;
        }
    }
    public void Run()
    {
        foreach (var i in moveFilter)
        {

            ref var characterController = ref moveFilter.Get1(i).CharacterController;
            var direction = moveFilter.Get2(i).MoveDirection;

            direction = _player.transform.TransformDirection(direction);
            characterController.SimpleMove(direction * Speed);

            if (characterController.velocity.magnitude > MAX_SPEED)
            {
                var vel = characterController.velocity;
                vel = characterController.velocity.normalized * MAX_SPEED;
            }
        }
    }
}

