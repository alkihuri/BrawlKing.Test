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
        OnEcsOn.AddListener(EcsOn);
        OnEcsStop.AddListener(EcsDestroy);
    }
    private void EcsStart()
    {
        _world = new EcsWorld();
        DataProvider.Instance.EcsWorld = _world;
        _systems = new EcsSystems(_world);

        _systems
             .Add(new GameStartSystem())
             .Add(new InputSystem())
             .Add(new PlayerMovementSystem())
             .Add(new PlayerRotateSystem())
             .Add(new PlayerShootingSystem())
             .Add(new PlayerHealthSystem())
             .Add(new NpcGenerationSystem())
             .Add(new UISystem())
             .Add(new CollisionSystem()); 
             ;

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
