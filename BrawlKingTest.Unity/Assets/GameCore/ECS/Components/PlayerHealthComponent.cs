using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerHealthComponent : IHealthComponent
{
    public int Healt;


    public void TakeDamage(int value)
    {
        Healt -= value;
        Healt = Mathf.Clamp(Healt, 0, 100);
    }

    public void TakeHeal(int value)
    {
        TakeDamage(-value);
    }
}
