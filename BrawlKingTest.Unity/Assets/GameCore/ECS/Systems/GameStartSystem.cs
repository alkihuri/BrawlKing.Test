using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartSystem : IEcsInitSystem
{
    EcsWorld _world = null;
    public void Init()
    {
        PlayerEntityInnit();
        NpcEntityInnit();
    }

    private void NpcEntityInnit()
    {
        var npc = _world.NewEntity();
        ref var npcData = ref npc.Get<NpcDataComponent>();
        ref var npcNavigation = ref npc.Get<AiMovableComponent>();
        ref var npcPool = ref npc.Get<NpcPoolDataComponent>();

        npcPool.MaxNpc = 100;
        npcData.Npc = DataProvider.Instance.NpcGameObject;
        npcData.Npc.transform.position = new Vector3(-100, 100, 100);
        npcPool.Npc = npcData.Npc;
        npcNavigation.AiNavigation = DataProvider.Instance.NpcNavigation;
        npcNavigation.Speed = 5;
    }

    private void PlayerEntityInnit()
    {
        var player = _world.NewEntity();
        ref var ojectData = ref player.Get<PlayerDataComponent>();
        ref var movable = ref player.Get<MovableComponent>();
        var direction = player.Get<MoveDirectionComponent>();
        var rotation = player.Get<RotateDirectionComponent>();
        var shooting = player.Get<GunComponent>();
        var health = player.Get<PlayerHealthComponent>();



        ojectData.Player = DataProvider.Instance.PlayerGameObject;
        movable.CharacterController = DataProvider.Instance.PlayerCharacterController;
        movable.Speed = 2;
    }
}
