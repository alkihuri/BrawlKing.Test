using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ECSStarter : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    #region MonoBehToEcsMapping
    private void Awake      () => EventSettings();
    private void Start      () => OnEcsStart?.Invoke();
    private void Update     () => OnEcsOn?.Invoke();
    private void OnDestroy  () => OnEcsStop?.Invoke();
    #endregion

    #region EventsLayer
    public UnityEvent OnEcsStart = new UnityEvent();
    public UnityEvent OnEcsOn = new UnityEvent();
    public UnityEvent OnEcsStop = new UnityEvent();
    #endregion

    private void EventSettings()
    {
        OnEcsStart.AddListener(EcsStart); 
        OnEcsStop.AddListener(EcsDestroy);
        OnEcsOn.AddListener(EcsOn);
    }
    private void EcsStart()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);  

        _systems
             .Add(new GameStartSystem())
             .Add(new InputSystem())
             .Add(new MovementSystem());
        _systems.Init();
    } 

    
    private void EcsOn()
    {  
            _systems.Run();
    }



    private void EcsDestroy()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}
