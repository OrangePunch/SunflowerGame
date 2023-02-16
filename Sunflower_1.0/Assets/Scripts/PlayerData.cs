using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public float Seeds;
    public float Enemies;

    public PlayerData Clone()
    {
        var json = JsonUtility.ToJson(this);
        return JsonUtility.FromJson<PlayerData>(json);
    }
}
