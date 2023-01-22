using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{

    [SerializeField] NavMeshAgent _navigation;
    [SerializeField] GameObject _target;

    public NavMeshAgent Navigation { get => _navigation; set => _navigation = value; }
    public GameObject Target { get => _target; set => _target = value; }


    public void NpcAiInnit(GameObject target)
    {
        Navigation = GetComponent<NavMeshAgent>();
        Target = target;
        StartCoroutine(FollowTarget());
    }


    private void OnTriggerEnter(Collider other)
    {
        var eteredStuff = other.gameObject;

        if (eteredStuff.GetComponent<BulletController>())
            transform.position = new Vector3(Random.Range(-150, 150), 2, Random.Range(-150, 150));
    }

    private IEnumerator FollowTarget()
    {
        while (true)
        {
            Navigation.SetDestination(Target.transform.position);
            yield return new WaitForSeconds(2f);
        }
    }

    internal void NpcTypeInnit(INpcType type)
    {
        Navigation.speed = type.Speed;

        GetComponentInChildren<Renderer>().material.color = type.Color;
    }
}
