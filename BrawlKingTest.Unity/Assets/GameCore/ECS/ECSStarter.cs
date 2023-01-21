using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECSStarter : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;
    #region MonoBehToEcsMapping
    void Start()=> EcsStart(); 
    void Update() => _systems.Run();
    private void OnDestroy() => EcsDestroy();
     
    #endregion
    private void EcsStart()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        _systems.Init();
    }
    private void EcsDestroy()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}
