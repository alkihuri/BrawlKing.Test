using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class CollisionHandler : MonoBehaviour
{
    public EcsWorld World { get; set; }


    private void OnTriggerEnter(Collider other)
    {
        if (World == null)
            World = DataProvider.Instance.EcsWorld;
         

        ref var hitComponet = ref World.NewEntity().Get<CollistionComponent>();

        hitComponet.Reciever = other.transform.gameObject;
        hitComponet.Sender = gameObject;


    }
}
