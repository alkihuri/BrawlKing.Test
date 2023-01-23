using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class NpcController : MonoBehaviour
{

    [SerializeField] NavMeshAgent _navigation;
    [SerializeField] GameObject _target;
    private INpcType _thisType;

    public NavMeshAgent Navigation { get => _navigation; set => _navigation = value; }
    public GameObject Target { get => _target; set => _target = value; }
    public float Health { get; private set; }

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
        {
            var bullet = eteredStuff.GetComponent<BulletController>();

            transform.DOShakeScale(1);
            Health -= bullet.Gun.Damage;

            if(Health < 1)
                Respawn();
        }
    }

    private void Respawn()
    {
        Health = _thisType.Health;
        transform.position = new Vector3(Random.Range(-150, 150), 2, Random.Range(-150, 150));
        transform.DOShakeScale(2);
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
        _thisType = type;
        Navigation.speed = type.Speed;

        Health = type.Health;

        GetComponentInChildren<Renderer>().material.color = type.Color;
    }
}
