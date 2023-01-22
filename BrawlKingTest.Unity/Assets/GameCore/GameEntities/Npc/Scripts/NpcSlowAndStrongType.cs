using UnityEngine;

public class NpcSlowAndStrongType : INpcType
{
    public float Speed => 2;

    public float Health => 200;

    public Color Color => Color.blue;
}