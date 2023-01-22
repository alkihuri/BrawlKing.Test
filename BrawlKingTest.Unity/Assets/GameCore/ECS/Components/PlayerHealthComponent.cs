using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerHealthComponent : IHealthComponent
{
    public int Health;
    public int Armor;


    public void TakeDamage(int value)
    {
        Health -= value * Armor;
        Health = Mathf.Clamp(Health, 0, 100);
    }

    public void TakeHeal(int value)
    {
        TakeDamage(-value / Armor);
    }
}
