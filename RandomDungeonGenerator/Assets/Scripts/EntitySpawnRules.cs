using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Spawn Rules", menuName ="Purgatory/Entity/Create new spawn rules")]
public class EntitySpawnRules : ScriptableObject
{
    //public int maxEntityNumber = Mathf.Infinity;
    public SpawnRule[] spawnRules;
}
[System.Serializable]
public class SpawnRule
{
    public EntityScript entityScript;
    [HideInInspector] public string entityName;

    public int doorSpawn;
}
