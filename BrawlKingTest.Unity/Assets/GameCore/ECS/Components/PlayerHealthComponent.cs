using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerHealthComponent : IHealthComponent
{
    public float Health;
    public float Armor;


    public void TakeDamage(float value)
    {
        Health -= value * Armor;
        Health = Mathf.Clamp(Health, 0, 100);
    }

    public void TakeHeal(float value)
    {
        TakeDamage(-value / Armor);
    }
}
