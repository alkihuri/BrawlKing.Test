using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NpcPoolDataComponent
{
    public int MaxNpc;
    public GameObject Npc;
    public List<GameObject> NpcList; 
}