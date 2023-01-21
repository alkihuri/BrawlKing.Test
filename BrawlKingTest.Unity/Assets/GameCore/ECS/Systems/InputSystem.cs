using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class InputSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<MoveDirectionComponent,RotateDirectionComponent> _inputHandlerFilter = null;

    private float _vertical;
    private float _horizontal;

    private float _mouseX;
    private float _mouseY;

    public float Vertical { get => _vertical; set => _vertical = value; }
    public float Horizontal { get => _horizontal; set => _horizontal = value; }
    public float MouseX { get => _mouseX; set => _mouseX = value; }
    public float MouseY { get => _mouseY; set => _mouseY = value; }

    public void Run()
    {
        InputDataHandle();
        foreach (var i in _inputHandlerFilter)
        {
            ref var direction = ref _inputHandlerFilter.Get1(i);
            ref var rotation = ref _inputHandlerFilter.Get2(i);

            direction.MoveDirection.x = Vertical;
            direction.MoveDirection.z = Horizontal;
             
            rotation.RotateDirection.x = MouseX;
            rotation.RotateDirection.z = MouseY;
        }
    }

    private void InputDataHandle()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
    }
}
