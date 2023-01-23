using UnityEngine;

public struct NpcHealthComponent : IHealthComponent
{
    public float Health;
    public float Armor;


    public void TakeDamage(float value)
    {
        Debug.Log(Health);
        Health -= value * Armor;
        Health = Mathf.Clamp(Health, 0, 100);
    }

    public void TakeHeal(float value)
    {
        TakeDamage(-value / Armor);
    }
}