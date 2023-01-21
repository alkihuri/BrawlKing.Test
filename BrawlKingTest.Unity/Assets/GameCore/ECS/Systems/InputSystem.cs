using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class InputSystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<DirectionComponent> _inputHandlerFilter = null;
    private float _vertical;
    private float _horizontal;

    public float Vertical { get => _vertical; set => _vertical = value; }
    public float Horizontal { get => _horizontal; set => _horizontal = value; }

    public void Init()
    {
        Debug.Log("Иннициализация системы ввода жи есть");
    }

    public void Run()
    {
        InputDataHandle(); 
        foreach (var i in _inputHandlerFilter)
        {
            ref var direction = ref _inputHandlerFilter.Get1(i);
            direction.MoveDirection.x = Vertical;
            direction.MoveDirection.z = Horizontal;
        }
    }

    private void InputDataHandle()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal  = Input.GetAxis("Horizontal");
    }
}
