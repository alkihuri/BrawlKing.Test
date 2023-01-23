using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private IGun _gun;
    private Rigidbody _rigidBody;
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void InnitBulet(IGun gun)
    {
        _gun = gun;
    }
     
}
