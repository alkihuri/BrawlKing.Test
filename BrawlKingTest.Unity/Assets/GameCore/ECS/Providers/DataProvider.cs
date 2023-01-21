using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProvider : MonoSinglethon<DataProvider>
{
    [SerializeField] GameObject _payer;

    public GameObject Payer { get => _payer = Instantiate(_payer); set => _payer = value; }

    public CharacterController CharacterController { get => GameObject.FindObjectOfType<CharacterController>(); }
}
