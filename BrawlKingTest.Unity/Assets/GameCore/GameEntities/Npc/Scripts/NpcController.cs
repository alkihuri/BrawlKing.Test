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


    public void NpcInnit(GameObject target)
    {
        Navigation = GetComponent<NavMeshAgent>();
        Target = target;
        StartCoroutine(FollowTarget());
    }

    

     
     IEnumerator FollowTarget()
    {
        while(true)
        {
            Navigation.SetDestination(Target.transform.position);
            yield return new WaitForSeconds(2f);
        }
    } 
}
