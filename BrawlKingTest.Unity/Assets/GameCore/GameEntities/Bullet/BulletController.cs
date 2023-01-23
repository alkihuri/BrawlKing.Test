using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private IGun _gun;
    private Rigidbody _rigidBody;

    public IGun Gun { get => _gun; set => _gun = value; }

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void InnitBulet(IGun gun)
    {
        _gun = gun;
    }
     
}
