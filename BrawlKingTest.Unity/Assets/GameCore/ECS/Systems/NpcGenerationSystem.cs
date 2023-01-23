using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcGenerationSystem : IEcsInitSystem, IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<AiMovableComponent, NpcPoolDataComponent> _npcPoolFilter = null;

    private readonly EcsFilter<PlayerDataComponent> _character = null;

    private int _npcCounter;
    private List<GameObject> _npcList;
    private GameObject _target;

    public int NpcCounter { get => _npcCounter; set => _npcCounter = value; }
    public List<GameObject> NpcList { get => _npcList; set => _npcList = value; }
    public GameObject Target { get => _target; set => _target = value; }

    public void Init()
    {
        NpcCounter = 0;

        foreach (var i in _npcPoolFilter)
            NpcList = _npcPoolFilter.Get2(i).NpcList = new System.Collections.Generic.List<GameObject>();


    }

    public void Run()
    {

        foreach (var i in _npcPoolFilter)
        {
            var npcNavigation = _npcPoolFilter.Get1(i).AiNavigation;
            var MaxNpc = _npcPoolFilter.Get2(i).MaxNpc;
            var npc = _npcPoolFilter.Get2(i).Npc;

            if (NpcCounter < MaxNpc)
            {
                NpcList.Add(SpawnNpc(npc, npcNavigation));
            }

        }
    }

    private GameObject SpawnNpc(GameObject npc, NavMeshAgent navigation)
    {
        if (Target == null)
        {
            foreach (var i in _character)
            {
                Target = _character.Get1(i).Player;
            }
        }

        var newNpc = GameObject.Instantiate(npc);
        newNpc.transform.position = new Vector3(Random.Range(-150, 150), 2, Random.Range(-150, 150));
        newNpc.AddComponent<CollisionHandler>(); /// for Ecs collisions :) 
        var npcController = newNpc.AddComponent<NpcController>();
        npcController.NpcAiInnit(Target);
        
        npcController.NpcTypeInnit(
            NpcCounter % 2 == 0 
            ? 
            new NpcFastAndWeakType() 
            : 
            new NpcSlowAndStrongType()) 
            ;

        NpcCounter++;
        return newNpc;
    }
}
