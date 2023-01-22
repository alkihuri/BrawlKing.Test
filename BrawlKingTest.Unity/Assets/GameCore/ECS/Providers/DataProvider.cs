using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DataProvider : MonoSinglethon<DataProvider>
{
    [SerializeField] GameObject _payer;
    [SerializeField] GameObject _npc;

    public GameObject PlayerGameObject { get => _payer = Instantiate(_payer); }
    public GameObject NpcGameObject { get => _npc = Instantiate(_npc); }

    public CharacterController PlayerCharacterController { get => _payer.GetComponent<CharacterController>(); }
    public NavMeshAgent NpcNavigation { get => _npc.GetComponent<NavMeshAgent>(); }


}
