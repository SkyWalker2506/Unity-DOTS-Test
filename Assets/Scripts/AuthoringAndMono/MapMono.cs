using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class MapMono : MonoBehaviour
{
    public float2 FieldDimensions;
    public int MaxSoldierCount;
    public GameObject Soldier;
    public uint RandomSeed;
}

public class MapBaker : Baker<MapMono>
{
    public override void Bake(MapMono authoring)
    {
        var entity = GetEntity(authoring.Soldier, TransformUsageFlags.Dynamic);
        AddComponent(entity,new MapProperties
        {
           FieldDimensions = authoring.FieldDimensions,
           MaxSoldierCount = authoring.MaxSoldierCount,
           Soldier = entity
        });
        AddComponent(entity,new MapRandom
        {
            Value = Random.CreateFromIndex(authoring.RandomSeed)
        });
    }
}
